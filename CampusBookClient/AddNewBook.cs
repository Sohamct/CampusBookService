using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using System.Xml.Linq;
using CampusBookClient.CampusBook_BookStoreService;
using CampusBookClient.CampusBook_PatronService;
using CampusBookService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CampusBookClient
{
    public partial class AddNewBook : Form
    {
        private readonly DataRow bookRow;

        private CampusBook_PatronService.IPatronService _patronService;
        private CampusBook_BookStoreService.IBookStoreService _bookStoreService;
        private byte[] fileBytes = null;
        private string username;
        private string loggedInUsername;
        private BookStore bookStore;
        
        private string Isbn, OwnerUsername, BookName, Subject, Branch, ReturnDate, IsAvailable, Description, Authorname, _Pages, BookImagePath;
        public AddNewBook(DataRow bookRow, BookStore bs, string username)
        {
            InitializeComponent();
            this.loggedInUsername = username;
            this.bookRow = bookRow;
            this.username = username;
            this.bookStore = bs;
            _bookStoreService = new BookStoreServiceClient();
            if (bookStore != null)
            {
                PopulateBookDetailsFromBookStore();
                PopulateFormEditing();

            }
            else if(bookRow != null)
            {
                PopulateBookDetailsFromBookRow();
                PopulateFormEditing();

            }
        }
        private void PopulateBookDetailsFromBookStore()
        {
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
            this.IsAvailable = (Convert.ToBoolean(bookRow["isAvailable"])) ? "Available" : "Not Available";
            this.Description = bookRow["description"].ToString();
            this.Branch = bookRow["branch"].ToString();
        }

        private void AddNewBook_Load(object sender, EventArgs e)
        {
            _patronService = new PatronServiceClient();

            string[] validBranchsArray = _patronService.GetValidBranches();
            List<string> validBranches = validBranchsArray.ToList();

            foreach (string branch in validBranches)
            {
                branchComboBox.Items.Add(branch);
            }
        }
        private void PopulateFormEditing()
        {
            isbn.Text = this.Isbn;
            bookName.Text = this.BookName;
            authorName.Text = this.Authorname;
            pages.Text = this._Pages;
            subject.Text = this.Subject;
            description.Text = this.Description;
            branchComboBox.Text = this.Branch;
            if (DateTime.TryParse(this.ReturnDate, out DateTime returnDate))
            {
                dateTimePicker.Value = returnDate;
            }
            else
            {
                dateTimePicker.Value = DateTime.Today;
            }
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
            SubmitBtn.Text = "Update Book";
            pageTitle.Text = "Add New Book";
        }

        private void BrowseImage_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select a image";
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                this.fileBytes = File.ReadAllBytes(selectedFilePath);
                AcknoLabel.Text = $"Selected File: {Path.GetFileName(selectedFilePath)}";
            }
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            if(bookRow == null)
            {
                try
                {
                    BookStore book = new BookStore
                    {
                        isbn = isbn.Text,
                        branch = branchComboBox.Text,
                        bookname = bookName.Text,
                        authorname = authorName.Text,
                        ownerUsername = username,
                        subject = subject.Text,
                        pages = Convert.ToInt32(pages.Text),
                        description = description.Text,
                        bookimage = Convert.ToBase64String(fileBytes),
                        returnDate = dateTimePicker.Value
                    };
                    _bookStoreService.InsertBook(book, username);
                    Home home = new Home(loggedInUsername);
                    home.Show();
                    this.Hide();
                    MessageBox.Show("Book Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (CommunicationException ex)
                {

                    MessageBox.Show("Failed to Add book. Communication error: Please select the file size less then 7kb." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to submit book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    BookStore book = new BookStore
                    {
                        isbn = isbn.Text,
                        branch = branchComboBox.Text,
                        bookname = bookName.Text,
                        authorname = authorName.Text,
                        ownerUsername = username,
                        subject = subject.Text,
                        pages = Convert.ToInt32(pages.Text),
                        description = description.Text,
                        bookimage = (fileBytes != null) ? Convert.ToBase64String(fileBytes) : "",
                        returnDate = dateTimePicker.Value
                    };
                    Console.WriteLine(fileBytes);
                    Console.WriteLine(username);
                    Console.WriteLine(Isbn);
                    BookStore bs = _bookStoreService.UpdateBookByIsbn(book,fileBytes, username, Isbn);

                    BookDetails bd = new BookDetails(bookRow, bs, loggedInUsername);
                    bd.Show();
                    this.Hide();
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                catch (CommunicationException ex)
                {

                    MessageBox.Show("Failed to Edit book. Communication error: Please select the file size less then 7kb." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Home homePage = new Home(username);
            homePage.Show();
        }
    }
}
