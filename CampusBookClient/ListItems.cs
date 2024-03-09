using CampusBookClient.CampusBook_BookStoreService;
using CampusBookClient.CampusBook_PatronService;
using CampusBookService;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CampusBookClient
{
    public partial class ListItem : UserControl
    {
        private DataRow _bookRow;
        private BookStore _bookStore;
        private string loggedInUsername;
        private CampusBook_PatronService.IPatronService _patronService;
        private CampusBook_BookStoreService.IBookStoreService _bookStoreService;
        public ListItem(DataRow bookRow, string loggedInUsername)
        {
            _patronService = new PatronServiceClient();
            _bookStoreService = new BookStoreServiceClient();
            this.loggedInUsername = loggedInUsername;
            InitializeComponent();
            _bookRow = bookRow;
            InitializeBookDetail();
        }
        public void InitializeBookDetail()
        {
            Patron pt = _patronService.GetPatronByUsername(_bookRow["ownerUsername"].ToString());
            BookName = _bookRow["bookName"].ToString();
            BookOwner = pt.fname + " " + pt.lname + " (" + _bookRow["ownerUsername"].ToString() + ")";
            ReturnDate = DateTime.Parse(_bookRow["returnDate"].ToString());
            BookAvailable = Convert.ToBoolean(_bookRow["isAvailable"]);
            Description = _bookRow["description"].ToString();
            Branch = _bookRow["branch"].ToString();
            Subject = _bookRow["subject"].ToString();

            string imagePath = _bookRow["bookImagePath"].ToString();
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    BookImage = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading book image: " + ex.Message);
                }
            }
        }

        #region Properties
        private string _bookName;
        private string _bookOwner;
        private bool _isAvailable;
        private Image _bookImage;
        private DateTime _returnDate;
        private string description;
        private string branch;
        private string subject;

        [Category("Custom Props")]
        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; book_name.Text = value; }
        }

        [Category("Custom Props")]
        public string BookOwner
        {
            get { return _bookOwner; }
            set { _bookOwner = value; book_owner.Text = value; }
        }

        [Category("Custom Props")]
        public Image BookImage
        {
            get { return _bookImage; }
            set { _bookImage = value; book_image.Image = value; }
        }

        [Category("Custom Props")]
        public bool BookAvailable
        {
            get { return _isAvailable; }
            set { 
                _isAvailable = value;
                isAvailable.Text = (value) ? "Available" : "Not Available";
                isAvailable.ForeColor = (value) ? Color.Green : Color.Red;
            }
        }

        [Category("Custom Props")]
        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; return_date.Text = value.ToShortDateString(); }
        }
        [Category("Custom Props")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [Category("Custom Props")]
        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        [Category("Custom Props")]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        #endregion

        private void ListItemMouseHover(object sender, EventArgs e)
        {
            if (BackColor != Color.LemonChiffon)
                BackColor = Color.LemonChiffon;

        } 

        private void ListItemMouseLeave(object sender, EventArgs e)
        {
            if (BackColor != SystemColors.ButtonHighlight)
                BackColor = SystemColors.ButtonHighlight;
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            BookDetails bookDetails = new BookDetails(_bookRow, null, loggedInUsername);
            bookDetails.Show();
        }
    }
}
