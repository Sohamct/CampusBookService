using CampusBookClient.CampusBook_PatronService;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CampusBookClient
{
    public partial class Login : Form
    {
        private IPatronService _patronService;
        public Login()
        {
            InitializeComponent();
            _patronService = new PatronServiceClient();
            this.Load += Login_Load;
            ShowPasswordCheckBox.Checked = false;
            Password.UseSystemPasswordChar = true;
        }
        private bool IsValidUsername(string username)
        {
            string pattern = @"^\d{2}[a-zA-Z]{5}\d{3}";

            return Regex.IsMatch(username, pattern);
        }
        private void Login_BtnClicked(object sender, EventArgs e)
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
                MessageBox.Show("Password should be atleast 6 characters long", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Patron patron = _patronService.LoginPatron(username, password);

                Console.WriteLine(patron.uname);
                MessageBox.Show("Logged in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Invoke((MethodInvoker)delegate {
                    Home homepage = new Home(patron.uname);
                    homepage.Show();
                    this.Hide();
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate {
                    MessageBox.Show($"Failed to login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }

        }

        private void Signup_LinkClicked(object sender, EventArgs e)
        {
            Signup signupForm = new Signup();
            signupForm.Show();
            this.Hide();
        }

        private void ToggleShowPassword(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = !Password.UseSystemPasswordChar;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
