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
        private bool isAccepted;
        public BookDetails(DataRow bookRow, string loggedInUsername)
        {
            InitializeComponent();
            bookStoreService = new BookStoreServiceClient();
            bookRequestService = new BookRequestServiceClient();
            patronService = new PatronServiceClient();

            this.bookRow = bookRow;
            this.loggedInUsername = loggedInUsername;
            if(loggedInUsername != bookRow["ownerUsername"].ToString())
            {
                BookRequest br = bookRequestService.FetchRequestStatus(loggedInUsername, bookRow["isbn"].ToString());
                requesterCombobox.Visible = false; AcceptOrReject.Visible = false;
                UpdateUI(br);
            }
            else
            {
                PopulateBookRequestInfo();
                IsAcceptedOrNot();
            }
            PopulateBookDetais(bookRow);
        }
        private void IsAcceptedOrNot()
        {
            bookRequestService.FetchRequestStatus();
        }

        private void PopulateBookRequestInfo()
        {
            Console.WriteLine("PopulateBookRequestInfo ....");

            try
            {
                requestStatus.Visible = false; requestStatus2.Visible = false;

                DataSet requestsDataSet = bookRequestService.fetchAllRequestsFromIsbn(bookRow["ownerUsername"].ToString(), bookRow["isbn"].ToString());
                List<string> usernames = new List<string>();
                if (requestsDataSet.Tables.Count > 0)
                {
                    DataTable requestTable = requestsDataSet.Tables[0];
                    foreach (DataRow row in requestTable.Rows)
                    {
                        usernames.Add(row["requester"].ToString());
                    }
                }
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
                        // Console.WriteLine(data);
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void PopulateBookDetais(DataRow bookRow)
        {
            Console.WriteLine("PopulateBookDetais");
            bookName.Text = bookRow["bookname"].ToString();
            bookOwner.Text = bookRow["ownerUsername"].ToString();
            bookAuthor.Text = bookRow["authorname"].ToString();
            subject.Text = bookRow["subject"].ToString();
            branch.Text = bookRow["branch"].ToString();
            pages.Text = bookRow["pages"].ToString();
            returnDate.Text = DateTime.Parse(bookRow["returnDate"].ToString()).ToShortDateString();
            isAvailable.Text = (Convert.ToBoolean(bookRow["isAvailable"]) ? "Available" : "Not Available");
            description.Text = bookRow["description"].ToString();
            isbn.Text = bookRow["isbn"].ToString();

            string imagePath = bookRow["bookImagePath"].ToString();
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
            string ownerUsername = bookRow["ownerUsername"].ToString();
            Console.WriteLine(ownerUsername);
            Console.WriteLine(loggedInUsername);
            bool isOwner = string.Equals(ownerUsername, loggedInUsername);
            editBtn.Visible = isOwner;
            deleteBtn.Visible = isOwner;
            
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            AddNewBook addNewBook = new AddNewBook(bookRow ,loggedInUsername);
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
                    string bookIsbn = isbn?.Text; 
                    string username = loggedInUsername; 
                    if (string.IsNullOrEmpty(bookIsbn))
                    {
                        MessageBox.Show("ISBN is null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Console.WriteLine(bookIsbn);
                    Console.WriteLine(username);
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
                    await bookRequestService.makeNewRequestAsync(loggedInUsername, bookRow["isbn"].ToString());
                }
                else
                {
                    await bookRequestService.cancelRequestAsync(loggedInUsername, bookRow["isbn"].ToString());
                }

                BookRequest br = await bookRequestService.FetchRequestStatusAsync(loggedInUsername, bookRow["isbn"].ToString());

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
                requestStatus2.Text = "Accepted !";
                requestStatus2.ForeColor = Color.Green;
            }
        }

        private void AcceptOrRejectBtn_Clicked(object sender, EventArgs e)
        {
            int startInd = requesterCombobox.Text.IndexOf('(');
            int endInd = requesterCombobox.Text.IndexOf(')', startInd);
            string borrowerUsername = requesterCombobox.Text.Substring(startInd + 1, endInd - startInd - 1);

            if (string.IsNullOrEmpty(borrowerUsername))
            {
                MessageBox.Show("Please select a borrower to accept the request", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(requestStatus.Visible == false)
                {
                    // 
                }
                else
                {

                }
            }
        }
    }
}
