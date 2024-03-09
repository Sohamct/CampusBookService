using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CampusBookService
{
    public class BookStoreService : IBookStoreService
    {
        private string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string assetsFolderPath = @"E:\WSD_Campusbook_Sharing\CampusBookService\UploadedImages\";
        private string SaveBookImage(byte[] bookImage)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = System.IO.Path.Combine(assetsFolderPath, fileName);
            System.IO.File.WriteAllBytes(filePath, bookImage);
            return filePath;
        }
        public BookStore InsertBook(BookStore book, string uname)
        {
            if (!PatronService.sessionTokens.ContainsKey(uname))
            {
                throw new FaultException("Please first login to the system");
            }
            if (IsBookExists(book.isbn))
            {
                throw new FaultException("Book Already exist with same isbn number!");
            }
            byte[] bookImageBytes = Convert.FromBase64String(book.bookimage);
            string imagePath = SaveBookImage(bookImageBytes);
            BookStore newBook = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO BookStore (isbn, bookname, authorname, ownerUsername, subject, description, branch, pages, bookImagePath, isAvailable, returnDate, borrowerUsername) " +
                        "VALUES (@isbn, @bookname, @authorname, @ownerUsername, @subject, @description, @branch, @pages, @bookImagePath, @isAvailable, @returnDate, @borrowerUsername)", conn);
                    cmd.Parameters.AddWithValue("@bookImagePath", imagePath);
                    cmd.Parameters.AddWithValue("@isbn", book.isbn);
                    cmd.Parameters.AddWithValue("@bookname", book.bookname);
                    cmd.Parameters.AddWithValue("@authorname", book.authorname);
                    cmd.Parameters.AddWithValue("@ownerUsername", book.ownerUsername);
                    cmd.Parameters.AddWithValue("@subject", book.subject);
                    cmd.Parameters.AddWithValue("@description", book.description);
                    cmd.Parameters.AddWithValue("@branch", book.branch);
                    cmd.Parameters.AddWithValue("@pages", book.pages);
                    cmd.Parameters.AddWithValue("@returnDate", book.returnDate);
                    cmd.Parameters.AddWithValue("@isAvailable", 1);
                    cmd.Parameters.AddWithValue("@borrowerUsername", DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                newBook = GetBookByIsbn(book.isbn, uname);
            }
            catch (Exception ex)
            {
                throw new FaultException("Error while adding new book: " + ex.Message);
            }
            
            return newBook;
        }
        public BookStore GetBookByIsbn(string isbn, string username)
        {
            if (!PatronService.sessionTokens.ContainsKey(username))
            {
                throw new FaultException("Please first login to the system");
            }
            BookStore book = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM BookStore WHERE isbn = @isbn", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        book = new BookStore
                        {
                            isbn = reader["isbn"].ToString(),
                            bookname = reader["bookname"].ToString(),
                            authorname = reader["authorname"].ToString(),
                            ownerUsername = reader["ownerUsername"].ToString(),
                            subject = reader["subject"].ToString(),
                            description = reader["description"].ToString(),
                            branch = reader["branch"].ToString(),
                            pages = Convert.ToInt32(reader["pages"]),
                            returnDate = Convert.ToDateTime(reader["returnDate"]),
                            isAvailable = Convert.ToBoolean(reader["isAvailable"]),
                            borrowerUsername = reader["borrowerUsername"].ToString(),
                            bookimage = reader["bookImagePath"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error while retrieving the book: " + ex.Message);
            }
            return book;
        }

        // Update book by ISBN
        public BookStore UpdateBookByIsbn(BookStore book, byte[] newBookImage, string username, string oldIsbn)
        {
            try
            {
                // Validate username and user session
                if (string.IsNullOrEmpty(username))
                {
                    throw new FaultException("Invalid username.");
                }
                if (!PatronService.sessionTokens.ContainsKey(username))
                {
                    throw new FaultException("Please first login to the system");
                }
                //if (book.isbn != oldIsbn)
                //{
                //    UpdateBookInBookRequestIfExist(oldIsbn, book.isbn);
                //}
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Connection = conn;
                    string updateQuery = "UPDATE BookStore SET " +
                        "bookname = @bookname, authorname = @authorname, " +
                        "subject = @subject, description = @description, branch = @branch, " +
                        "pages = @pages, returnDate = @returnDate ";

                    if (newBookImage != null && newBookImage.Length > 0)
                    {
                        string newImagePath = SaveBookImage(newBookImage);
                        updateQuery += ", bookImagePath = @bookImagePath ";
                        cmd.Parameters.AddWithValue("@bookImagePath", newImagePath);
                    }

                    if (book.isbn != oldIsbn)
                    {
                        updateQuery += ", isbn = @newIsbn ";
                        cmd.Parameters.Add("@newIsbn", SqlDbType.VarChar, 13).Value = book.isbn.Substring(0, Math.Min(book.isbn.Length, 13));
                    }

                    updateQuery += "WHERE isbn = @oldIsbn";
                    cmd.Parameters.AddWithValue("@oldIsbn", oldIsbn);

                    cmd.CommandText = updateQuery;
                    cmd.Parameters.AddWithValue("@bookname", book.bookname);
                    cmd.Parameters.AddWithValue("@authorname", book.authorname);
                    cmd.Parameters.AddWithValue("@subject", book.subject);
                    cmd.Parameters.AddWithValue("@description", book.description);
                    cmd.Parameters.AddWithValue("@branch", book.branch);
                    cmd.Parameters.AddWithValue("@pages", book.pages);
                    cmd.Parameters.AddWithValue("@returnDate", book.returnDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new FaultException("Failed to edit book: Book does not belong to the user or does not exist");
                    }
                }

                
            }
            catch (Exception ex)
            {
                throw new FaultException("Error while editing the book: " + ex.Message);
            }

            BookStore editedBook = GetBookByIsbn(book.isbn, username);
            return editedBook;
        }

        private bool IsBookExists(string isbn)
        {
            bool exists = true;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select COUNT(*) from BookStore where isbn=@isbn", conn);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                int count = (int)cmd.ExecuteScalar();
                exists = (count > 0);
            }
            return exists;
        }
        private void DeleteBookFromBookRequest(string isbn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BookRequest WHERE isbn=@isbn", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new FaultException("Error: No matching records found for deletion.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error while deleting book from BookRequest: " + ex.Message);
            }
        }

        // DELETE BOOK
        public void deleteBook(string isbn, string username)
        {
            try
            {
                if (!PatronService.sessionTokens.ContainsKey(username))
                {
                    throw new FaultException("Please first login to the system");
                }
                if (!IsBookExists(isbn))
                {
                    throw new FaultException("Error while deleting book: Book does not exist");
                }
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BookStore WHERE isbn = @isbn AND ownerUsername = @ownerUsername", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@ownerUsername", username);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new FaultException("Error while deleting book: Book does not belong to the user");
                    }
                }
                DeleteBookFromBookRequest(isbn);
            }
            catch (SqlException ex)
            {
                throw new FaultException($"Failed to delete book: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new FaultException($"An unexpected error occurred: {ex.Message}");
            }
        }

        public DataSet getBooks(string username)
        {
            if (!PatronService.sessionTokens.ContainsKey(username))
            {
                throw new FaultException("Please first login to the system");
            }
            DataSet dataset = new DataSet();
            try
            {
                using(SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from BookStore ORDER BY returnDate DESC", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException($"Failed to retrieve books: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new FaultException($"An unexpected error occurred: {ex.Message}");
            }
            return dataset;
        }

        public DataSet getBooksOfOwner(string username)
        {
            if (!PatronService.sessionTokens.ContainsKey(username))
            {
                throw new FaultException("Please first login to the system");
            }
            DataSet dataset = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from BookStore where ownerUsername=@OwnerUsername ORDER BY returnDate DESC", conn);
                    cmd.Parameters.AddWithValue("@OwnerUsername", username);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException($"Failed to retrieve books: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new FaultException($"An unexpected error occurred: {ex.Message}");
            }
            return dataset;
        }

        public DataSet GetBooksFromIsbns(List<string> isbnList, string username)
        {
            try
            {
                if (!PatronService.sessionTokens.ContainsKey(username))
                {
                    throw new FaultException("Please first login to the system");
                }

                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT * FROM BookStore WHERE isbn IN (");

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    for (int i = 0; i < isbnList.Count; i++)
                    {
                        string param = "@isbn" + i;
                        queryBuilder.Append(param);
                        cmd.Parameters.AddWithValue(param, isbnList[i]);
                        if (i < isbnList.Count - 1)
                        {
                            queryBuilder.Append(",");
                        }
                    }

                    queryBuilder.Append(")");

                    cmd.CommandText = queryBuilder.ToString();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error while fetching BorrowerBookDetails: " + ex.Message);
            }
        }


    }
}
