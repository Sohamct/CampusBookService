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
    public partial class OwnerBooks : Form
    {
        private List<DataRow> ownerBooks;
        private string loggedInUsername;
        public OwnerBooks(List<DataRow> ownerBooks, string username)
        {
            InitializeComponent();
            this.loggedInUsername = username;
            this.ownerBooks = ownerBooks;
            PopulateOwnerBooks();
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

        }

        private void Back_Clicked(object sender, EventArgs e)
        {

        }

        private void AddNewBook_Clicked(object sender, EventArgs e)
        {

        }
    }
}
