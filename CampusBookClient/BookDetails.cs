using CampusBookClient.CampusBook_BookRequestService_;
using CampusBookClient.CampusBook_BookStoreService;
using CampusBookClient.CampusBook_PatronService;
using CampusBookService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace CampusBookClient
{
    
    public partial class BookDetails : Form
    {
        private CampusBook_BookStoreService.IBookStoreService bookStoreService;
        private CampusBook_BookRequestService_.IBookRequestService bookRequestService;
        private CampusBook_PatronService.IPatronService patronService;
        private readonly string loggedInUsername;
        private DataRow bookRow;
        private BookStore bookStore;
        private bool isAccepted = false;
        private string RequestAcceptedUsername = "";
        private string Isbn, OwnerUsername, BookName, Subject, Branch, ReturnDate, IsAvailable, Description, Authorname, _Pages, BookImagePath;
        public BookDetails(DataRow bookRow, BookStore bs, string loggedInUsername)
        {
            InitializeComponent();
            bookStore = bs;
            bookStoreService = new BookStoreServiceClient();
            bookRequestService = new BookRequestServiceClient();
            patronService = new PatronServiceClient();
            this.bookRow = bookRow;
            if(bookStore != null)
            {
                PopulateBookDetailsFromBookStore();
            }
            else
            {
                PopulateBookDetailsFromBookRow();
            }
            this.loggedInUsername = loggedInUsername;
            if(loggedInUsername != this.OwnerUsername)
            {
                BookRequest br = bookRequestService.FetchRequestStatus(loggedInUsername, this.Isbn.ToString());
                requesterCombobox.Visible = false; AcceptOrReject.Visible = false;
                UpdateUI(br);
            }
            else
            {
                PopulateBookRequestInfo();
            }
            PopulateBookDetais();
        }
        private void PopulateBookDetailsFromBookStore() {
            this.Isbn = bookStore.isbn;
            this.OwnerUsername = bookStore.ownerUsername;
            this.BookName = bookStore.bookname;
            this.Authorname = bookStore.authorname;
            this._Pages = Convert.ToString(bookStore.pages);
            this.Subject = bookStore.subject;
            this.BookImagePath = bookStore.bookimage;
            this.ReturnDate = Convert.ToString(bookStore.returnDate);
            this.IsAvailable = (bookStore.isAvailable) ? "Available" : "Not Available";
            this.Description = bookStore.description;
            this.Branch = bookStore.branch;
        }
        private void PopulateBookDetailsFromBookRow()
        {
            this.Isbn = bookRow["isbn"].ToString();
            this.OwnerUsername = bookRow["ownerUsername"].ToString();
            this.BookName = bookRow["bookname"].ToString();
            this.Authorname = bookRow["authorname"].ToString();
            this._Pages = Convert.ToString(bookRow["pages"].ToString());
            this.Subject = bookRow["subject"].ToString();
            this.BookImagePath = bookRow["bookImagePath"].ToString();
            this.ReturnDate = Convert.ToString(bookRow["returnDate"].ToString());
            this.IsAvailable =  (Convert.ToBoolean(bookRow["isAvailable"])) ? "Available" : "Not Available";
            this.Description = bookRow["description"].ToString();
            this.Branch = bookRow["branch"].ToString();
        }

        private void PopulateBookRequestInfo()
        {
            try
            {
                requestStatus.Visible = false; requestStatus2.Visible = false;

                DataSet requestsDataSet = bookRequestService.fetchAllRequestsFromIsbn(this.OwnerUsername, this.Isbn.ToString());
                List<string> usernames = new List<string>();
                if (requestsDataSet.Tables.Count > 0)
                {
                    DataTable requestTable = requestsDataSet.Tables[0];
                    foreach (DataRow row in requestTable.Rows)
                    {
                        if (row["status"] != DBNull.Value && Convert.ToBoolean(row["status"]))
                        {
                            this.isAccepted = true;
                            this.RequestAcceptedUsername = row["requester"].ToString();
                            break;
                        }
                        usernames.Add(row["requester"].ToString());
                    }
                    AcceptOrReject.Text = "Accept";
                    AcceptOrReject.ForeColor = Color.Green;
                    requesterCombobox.Visible= true;
                }
                if (!this.isAccepted)
                {
                    DataSet resultFullName = patronService.GetPatronsFullNameByUsername(usernames.ToArray());
                    foreach (DataTable table in resultFullName.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string fname = row["firstname"].ToString();
                            string lname = row["lastname"].ToString();
                            string username = row["username"].ToString();
                            string data = fname + " " + lname + " (" + username + ")";
                            requesterCombobox.Items.Add(data);
                        }
                    }
                }
                else
                {
                    Patron pt = patronService.GetPatronByUsername(this.RequestAcceptedUsername);
                    AcceptedReqFullName.Text = "Request is Accepted: "+ pt.fname + " " + pt.lname + "(" + pt.uname + ")";
                    requesterCombobox.Visible = false;
                    AcceptOrReject.Text = "Reject";
                    AcceptOrReject.ForeColor = Color.Red;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void PopulateBookDetais()
        {
            Patron pt = patronService.GetPatronByUsername(this.OwnerUsername);

            bookName.Text = this.BookName;
            bookOwner.Text = pt.fname + " " + pt.lname +" ("+this.OwnerUsername+ ")";
            bookAuthor.Text = this.Authorname;
            subject.Text = this.Subject;
            branch.Text = this.Branch;
            pages.Text = this._Pages;
            returnDate.Text = DateTime.Parse(this.ReturnDate).ToShortDateString();
            isAvailable.Text = this.IsAvailable;
            description.Text = this.Description;
            isbn.Text = this.Isbn;

            string imagePath = this.BookImagePath;
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    bookImage.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading book image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No image available for this book.");
            }
            string ownerUsername = this.OwnerUsername;
            Console.WriteLine(ownerUsername);
            Console.WriteLine(loggedInUsername);
            bool isOwner = string.Equals(ownerUsername, loggedInUsername);
            editBtn.Visible = isOwner;
            deleteBtn.Visible = isOwner;
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            AddNewBook addNewBook = new AddNewBook(bookRow , bookStore, loggedInUsername);
            addNewBook.Show();
            this.Hide();
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string bookIsbn = this.Isbn; 
                    string username = loggedInUsername; 
                    if (string.IsNullOrEmpty(bookIsbn))
                    {
                        MessageBox.Show("ISBN is null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    await bookStoreService.deleteBookAsync(bookIsbn, username);

                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Home home = new Home(username);
                    home.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void RequestBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (requestStatus.Text == "Request")
                {
                    await bookRequestService.makeNewRequestAsync(loggedInUsername, this.Isbn);
                }
                else
                {
                    await bookRequestService.cancelRequestAsync(loggedInUsername, this.Isbn);
                }

                BookRequest br = await bookRequestService.FetchRequestStatusAsync(loggedInUsername, this.Isbn);

                UpdateUI(br);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUI(BookRequest br)
        {
            Console.WriteLine("UpdateUI");

            if (br == null)
            {
                requestStatus.Text = "Request";
                requestStatus.ForeColor = Color.Green;
                requestStatus2.Visible = false;
            }
            else if (br.status == null)
            {
                requestStatus.Text = "Cancel";
                requestStatus.ForeColor = Color.Red;
                requestStatus2.Visible = false;
            }
            else if (br.status == true)
            {
                requestStatus.Visible = false;
                requestStatus2.Text = "Request is Accepted !";
                requestStatus2.ForeColor = Color.Green;
            }
        }
        private void RemoveitemContainingSubstring(string username)
        {
            for(int i = requesterCombobox.Items.Count - 1; i >= 0; i--)
            {
                string item = requesterCombobox.Items[i].ToString();
                if (item.Contains(username))
                {
                    requesterCombobox.Items.RemoveAt(i);
                }
            }
            if(requesterCombobox.Items.Count == 0)
            {
                requesterCombobox.Visible = false;
                AcceptOrReject.Visible = false;
            }
        }

        private void AcceptOrRejectBtn_Clicked(object sender, EventArgs e)
        {
            if (isAccepted) // rejecting request
            {
                try
                {
                    Patron patron = patronService.GetPatronByUsername(RequestAcceptedUsername);
                    Console.WriteLine("GetPatronByUsername is called");
                    AcceptedReqFullName.Text = patron.fname + " " + patron.lname + "(" + patron.uname + ")";
                    AcceptOrReject.Text = "Reject";
                    AcceptOrReject.ForeColor = Color.Red;
                    // calling reject request
                    bookRequestService.rejectRequest(loggedInUsername, RequestAcceptedUsername, this.Isbn);
                    this.isAccepted = false;
                    AcceptedReqFullName.Text = "";
                    requesterCombobox.Visible = true;
                    AcceptOrReject.Text = "Accept";
                    AcceptOrReject.ForeColor = Color.Green;
                    RemoveitemContainingSubstring(RequestAcceptedUsername);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else // accepting request
            {
                int startInd = requesterCombobox.Text.IndexOf('(');
                int endInd = requesterCombobox.Text.IndexOf(')', startInd);

                if (startInd != -1 && endInd != -1)
                {
                    string borrowerUsername = requesterCombobox.Text.Substring(startInd + 1, endInd - startInd - 1);

                    if (string.IsNullOrEmpty(borrowerUsername))
                    {
                        MessageBox.Show("Please select a borrower to accept the request", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        Console.WriteLine(borrowerUsername);
                        Patron patron = patronService.GetPatronByUsername(borrowerUsername);
                        AcceptedReqFullName.Text = patron.fname + " " + patron.lname + "(" + patron.uname + ")";
                        AcceptOrReject.Text = "Accept";
                        AcceptOrReject.ForeColor = Color.Green;

                        // calling accept request
                        bookRequestService.acceptRequestAsync(loggedInUsername, borrowerUsername, this.Isbn);
                        requesterCombobox.Visible = false;
                        this.isAccepted = true;
                        this.RequestAcceptedUsername = borrowerUsername;
                        AcceptOrReject.Text = "Reject";
                        AcceptOrReject.ForeColor = Color.Red;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid format for borrower selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUsername);
            home.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            patronService.LogoutPatron(loggedInUsername);
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
