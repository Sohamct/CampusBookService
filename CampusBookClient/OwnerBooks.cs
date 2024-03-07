using CampusBookClient.CampusBook_PatronService;
using CampusBookService;
using System;
using System.Collections.Generic;
using System.Data;

using System.Windows.Forms;

namespace CampusBookClient
{
    public partial class OwnerBooks : Form
    {
        private CampusBook_PatronService.IPatronService patronService;
        private List<DataRow> ownerBooks;
        private string loggedInUsername;

        private string FullName;
        public OwnerBooks(List<DataRow> ownerBooks, string username)
        {
            patronService = new PatronServiceClient();
            InitializeComponent();
            this.loggedInUsername = username;
            this.ownerBooks = ownerBooks;
            PopulateOwnerBooks();
            Patron pt = patronService.GetPatronByUsername(username);
            FullName = pt.fname + " " + pt.lname + " "+ loggedInUsername;
        }

        private void OwnerBooks_Load(object sender, EventArgs e)
        {

        }
        private void PopulateOwnerBooks()
        {
            foreach(var bookRow in ownerBooks)
            {
                ListItem listItem = new ListItem(bookRow, loggedInUsername);
                flowLayoutPanel1.Controls.Add(listItem);
            }
        }

        private void HomeBtn_Clicked(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUsername);
            this.ParentForm.Hide();
            home.Show();
        }


        private void AddNewBook_Clicked(object sender, EventArgs e)
        {
            AddNewBook addNewBookPage = new AddNewBook(null, this.loggedInUsername);
            addNewBookPage.Show();
            this.Hide();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchText.Text.Trim().ToLower();

            foreach (ListItem item in flowLayoutPanel1.Controls)
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
                       item.Subject.ToLower().Contains(searchText) ||
                       FullName.Contains(searchText);

                    item.Visible = isSatisfied;
                }
            }
        }
    }
}
