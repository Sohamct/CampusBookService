using CampusBookClient.CampusBook_BookRequestService_;
using CampusBookClient.CampusBook_BookStoreService;
using CampusBookService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusBookClient
{
    public partial class BorrowedBooks : Form
    {
        private List<DataRow> borrowedBooks;
        private string loggedInUsername;
        private CampusBook_BookStoreService.IBookStoreService bookStoreService;
        private CampusBook_BookRequestService_.IBookRequestService bookRequestService;
        private bool isBorrowed;

        public BorrowedBooks(string username)
        {
            InitializeComponent();
            bookRequestService = new BookRequestServiceClient();
            bookStoreService = new BookStoreServiceClient();
            this.loggedInUsername = username;
            GetBorrwedBooks();
        }
        private void GetBorrwedBooks()
        {
            try
            {
                Console.WriteLine(loggedInUsername);
                string []isbnList = bookRequestService.GetAllBorrowedIsbn(loggedInUsername, isBorrowed);
                if (isbnList == null || isbnList.Length == 0)
                {
                    MessageBox.Show("No Book is " + ((isBorrowed) ? "Requested" : "Borrowed"));
                    return ;
                }
                Console.WriteLine(isbnList);
                DataSet ds = bookStoreService.GetBooksFromIsbns(isbnList, loggedInUsername);
                this.borrowedBooks = ConvertDataSetToList(ds);
                PopulateBorrowedBooks();
            }
            catch(Exception ex) {
                MessageBox.Show("Error In BorrowedBooks " + ex.Message);
            }
        }
        private List<DataRow> ConvertDataSetToList(DataSet dataset)
        {
            List<DataRow> dataList = new List<DataRow>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    dataList.Add(row);
                }
            }
            return dataList;
        }
        private void PopulateBorrowedBooks()
        {

            foreach (var bookRow in borrowedBooks)
            {
                ListItem listItem = new ListItem(bookRow, loggedInUsername);
                flowLayoutPanel1.Controls.Add(listItem);
            }
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
                       item.Subject.ToLower().Contains(searchText);
                    item.Visible = isSatisfied;
                }
            }
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUsername);
            this.Hide();
            home.Show();
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            flowLayoutPanel1.Controls.Clear();
            if (radioButton != null && radioButton.Checked)
            {
                if (radioButton.Name == "Borrowed")
                {
                    Console.WriteLine("Borrowed...");
                    Console.WriteLine(isBorrowed);

                    isBorrowed = true;
                    GetBorrwedBooks();
                }
                else if (radioButton.Name == "Requested")
                {
                    Console.WriteLine("Requested...");
                    Console.WriteLine(isBorrowed);
                    isBorrowed = false;
                    GetBorrwedBooks();
                }
            }
        }
    }
}
