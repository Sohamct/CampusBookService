using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CampusBookClient.CampusBook_BookStoreService;
using CampusBookClient.CampusBook_PatronService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CampusBookClient
{
    public partial class AddNewBook : Form
    {
        private readonly DataRow bookRow;

        private IPatronService _patronService;
        private IBookStoreService _bookStoreService;
        private byte[] fileBytes;
        private string username;
        public AddNewBook(DataRow bookRow, string username)
        {
            InitializeComponent();
            this.bookRow = bookRow;
            this.username = username;
            _bookStoreService = new BookStoreServiceClient();
            if(bookRow != null)
            {
                PopulateFormEditing();
            }
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
            isbn.Text = bookRow["isbn"].ToString();
            bookName.Text = bookRow["bookname"].ToString();
            authorName.Text = bookRow["authorname"].ToString();
            pages.Text = bookRow["pages"].ToString();
            subject.Text = bookRow["subject"].ToString();
            description.Text = bookRow["description"].ToString();
            branchComboBox.Text = bookRow["branch"].ToString();
            if (DateTime.TryParse(bookRow["returnDate"].ToString(), out DateTime returnDate))
            {
                dateTimePicker.Value = returnDate;
            }
            else
            {
                dateTimePicker.Value = DateTime.Today;
                // MessageBox.Show("Invalid return date format or null value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            SubmitBtn.Text = "Update Book";
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
            try
            {
                Console.WriteLine(dateTimePicker.Value);
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
                    MessageBox.Show("Book submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }catch(Exception ex){
                MessageBox.Show($"Failed to submit book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
