using CampusBookClient.CampusBook_PatronService;
using CampusBookClient.CampusBook_BookStoreService;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using CampusBookService;

namespace CampusBookClient
{
    public partial class Home : Form
    {
        private CampusBook_PatronService.IPatronService patronService;
        private CampusBook_BookStoreService.IBookStoreService bookStoreService;
        private string loggedInUsername;
        List<string> usernames;
        Dictionary<string, string> unameToFullName;
        public Home(string username)
        {
            usernames = new List<string>();
            unameToFullName = new Dictionary<string, string>();
            bookStoreService = new BookStoreServiceClient();
            patronService = new PatronServiceClient();
            this.loggedInUsername = username;
            InitializeComponent();
            Task.Run(async () => await Task.WhenAll(GetBooksAsync(), FetchOwnerDetails()));
        }
        private async Task GetBooksAsync()
        {
            try
            {
                DataSet result = await bookStoreService.getBooksAsync(loggedInUsername);
                if (result != null && result.Tables.Count > 0)
                {
                    DataTable table = result.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ListItem item = new ListItem(row, loggedInUsername);
                        Console.WriteLine(item.BookOwner);
                        usernames.Add(item.BookOwner);
                        AddItemToUI(item);
                    }
                }
                else
                {
                    MessageBox.Show("No books found for this user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving books: " + ex.Message);
            }
        }
        private Task FetchOwnerDetails()
        {
            try
            {
                DataSet ownerFullNames = patronService.GetPatronsFullNameByUsername(usernames.ToArray());
                foreach(DataTable table in ownerFullNames.Tables)
                {
                    string fname, lname, uname;
                    foreach(DataRow row in table.Rows)
                    {
                        fname = row["firstname"].ToString();
                        lname = row["lastname"].ToString();
                        uname = row["username"].ToString();
                        unameToFullName.Add(uname, fname + " " + lname);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while Fetching Owner Details: " + e.Message);
            }
            return Task.CompletedTask;
        }

        private void AddItemToUI(ListItem item)
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                    flowLayoutPanel1.Controls.Add(item);
                });
            }
            else
            {
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void AddNewBook_Clicked(object sender, EventArgs e)
        {
            AddNewBook addNewBookPage = new AddNewBook(null, this.loggedInUsername);
            addNewBookPage.Show();
            this.Hide();
        }

        private async void MyBooks_Clicked(object sender, EventArgs e)
        {
            try
            {
                await GetOwnerBooks();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting owner books: " + ex.Message);
            }
        }
        private async Task GetOwnerBooks()
        {
            try
            {
                DataSet result = await bookStoreService.getBooksOfOwnerAsync(this.loggedInUsername);
                if (result != null && result.Tables.Count > 0)
                {
                    List<DataRow> ownerBooks = ConvertDataSetToList(result);
                    OwnerBooks ownerBookForm = new OwnerBooks(ownerBooks, loggedInUsername);
                    this.Hide();
                    ownerBookForm.Show();

                }
                else
                {
                    MessageBox.Show("No books found for this user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving books: " + ex.Message);
            }
        }
        private List<DataRow> ConvertDataSetToList(DataSet dataset)
        {
            List<DataRow> dataList = new List<DataRow>();
            if(dataset != null && dataset.Tables.Count > 0) {
                foreach(DataRow row in dataset.Tables[0].Rows) {
                    Console.WriteLine("looping ...");

                    dataList.Add(row);
                }
            }
            return dataList;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            patronService.LogoutPatron(loggedInUsername);
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchText.Text.Trim().ToLower();

            foreach(ListItem item in flowLayoutPanel1.Controls)
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    item.Visible = true;
                }
                Console.WriteLine(item.BookOwner);
                if (!string.IsNullOrEmpty(searchText))
                {
                    bool isSatisfied = item.BookName.ToLower().Contains(searchText) ||
                       item.BookOwner.ToLower().Contains(searchText) ||
                       item.Description.ToLower().Contains(searchText) || 
                       item.Branch.ToLower().Contains(searchText) ||
                       item.Subject.ToLower().Contains(searchText);

                    Console.WriteLine("item.BookOwner" + item.BookOwner);
                    string BO = item.BookOwner;
                    if (unameToFullName.ContainsKey(item.BookOwner) == true)
                    {
                        isSatisfied = isSatisfied || unameToFullName[item.BookOwner].Contains(searchText);
                    }
                    item.Visible = isSatisfied;
                }
            }
        }
    }
}


