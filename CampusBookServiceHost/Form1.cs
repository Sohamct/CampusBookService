using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusBookServiceHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceHost patronServiceHost = new ServiceHost(typeof(CampusBookService.PatronService));

            patronServiceHost.Open();
            label1.Text = "PatronService is running...";

            ServiceHost bookStoreService = new ServiceHost(typeof(CampusBookService.BookStoreService));
            bookStoreService.Open();
            label2.Text = "BookStoreService is running...";

            ServiceHost bookRequestService = new ServiceHost(typeof(CampusBookService.BookRequestService));
            bookRequestService.Open();
            label3.Text = "BookRequestService is running...";
        }
    }
}
