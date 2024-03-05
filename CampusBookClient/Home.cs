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
        public Home(string username)
        {
            bookStoreService = new BookStoreServiceClient();
            this.loggedInUsername = username;
            InitializeComponent();
            Task.Run(() => GetBooksAsync(username));
        }
        private async Task GetBooksAsync(string username)
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
        private void SearchBtn_Clicked(object sender, EventArgs e)
        {

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
                Console.WriteLine("GetOwnerBooks called");
                if (result != null && result.Tables.Count > 0)
                {
                    List<DataRow> ownerBooks = ConvertDataSetToList(result);
                    Console.WriteLine("ConvertDataSetToList called");
                    OwnerBooks ownerBookForm = new OwnerBooks(ownerBooks, loggedInUsername);
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
    }
}


