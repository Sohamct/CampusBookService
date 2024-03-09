using CampusBookClient.CampusBook_PatronService;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using CampusBookService;

namespace CampusBookClient
{
    public partial class Signup : Form
    {
        private CampusBook_PatronService.IPatronService _patronService;
        public Signup()
        {
            InitializeComponent();
           _patronService = new PatronServiceClient();
            this.Load += Signup_Load;
            ShowPasswordCheckBox.Checked = false;
            Password.UseSystemPasswordChar = true;
        }
        private bool IsValidUsername(string username)
        {
            string pattern = @"^\d{2}[a-zA-Z]{5}\d{3}";

            return Regex.IsMatch(username, pattern);
        }
        private void Signup_BtnClicked(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            if (!IsValidUsername(username))
            {
                MessageBox.Show("Username should be in formate '21CEUOS019'.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password.Length <= 5)
            {
                MessageBox.Show("Password should be atleast 6 characters long");
                return;
            }
            string firstname = Firstname.Text;
            string lastname = Lastname.Text;
            string branch = BranchCombobox.Text;

            Patron patron = new Patron();
            patron.fname = firstname; patron.lname = lastname;
            patron.Branch = branch; patron.uname = username;
            patron.password = password;
            try
            {
                Patron newPatron =_patronService.SignupPatron(patron);
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Home homepage = new Home(patron.uname);
                homepage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to signup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            string[] validBranchsArray =_patronService.GetValidBranches();
            List<string> validBranches = validBranchsArray.ToList();
            BranchCombobox.Items.Clear();
            foreach (string branch in validBranches)
            {
                BranchCombobox.Items.Add(branch);
            }

        }
        private void ToggleShowPassword(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = !Password.UseSystemPasswordChar;
        }
    }
}
