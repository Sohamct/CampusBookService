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
    
    public partial class BookDetails : Form
    {
        private readonly string loggedInUsername;
        private DataRow bookRow;
        public BookDetails(DataRow bookRow, string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            this.bookRow = bookRow;
            populateBookDetais(bookRow);
        }

        private void populateBookDetais(DataRow bookRow)
        {
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

        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
