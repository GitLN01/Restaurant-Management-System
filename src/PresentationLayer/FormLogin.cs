using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer
{
    public partial class FormLogin : Form
    {
        readonly CustomerBusiness customerBusiness = new CustomerBusiness();
        public string ErrorMessage = string.Empty;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            switchToRegister(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            switchToRegister(sender, e);
        }

        private void switchToRegister(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister = new FormRegister();
            formRegister.Closed += (s, args) => this.Close();
            formRegister.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            dontHaveAccountLabel.BackColor = System.Drawing.Color.Transparent;
            createOneLabel.BackColor = System.Drawing.Color.Transparent;

            emailTextBox.GotFocus += OnEmailFocus;
            emailTextBox.LostFocus += OnEmailUnfocus;

            passwordTextBox.GotFocus += OnPasswordFocus;
            passwordTextBox.LostFocus += onPasswordUnfocus;
        }

        public void OnEmailFocus(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "Email address")
            {
                emailTextBox.Text = "";
            }
        }

        public void OnEmailUnfocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
                emailTextBox.Text = "Email address";
        }

        public void OnPasswordFocus(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
                passwordTextBox.PasswordChar = '*';
            }
        }

        public void onPasswordUnfocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.Text = "Password";
                passwordTextBox.PasswordChar = '\0';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = emailTextBox.Text;
            string Password = passwordTextBox.Text;

            if(!IsValidData(Email, Password))
            {
                MessageBox.Show(ErrorMessage);
                return;
            }

            Customers customer = customerBusiness.GetCustomerByEmail(Email);
            UserSession.SetUser(customer.customer_id, customer.name, customer.email);

            OpenMainApplication();
        }

        public bool IsValidData(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || Email == "Email address")
            {
                ErrorMessage = "Email address field must not be empty!";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Password) || passwordTextBox.PasswordChar != '*')
            {
                ErrorMessage = "Password field must not be empty!";
                return false;
            }

            if(!IsCustomerDataValid(Email, Password))
            {
                return false;
            }

            return true;
        }

        public bool IsCustomerDataValid(string Email, string Password)
        {
            if (!customerBusiness.ExistsCustomerWithEmail(Email))
            {
                ErrorMessage = "Your email address or password is incorrect!";
                return false;
            }

            Customers customer = customerBusiness.GetCustomerByEmail(Email);
            if(Password != customer.password)
            {
                ErrorMessage = "Your email address or password is incorrect!";
                return false;
            }

            return true;
        }

        public void OpenMainApplication()
        {
            this.Hide();
            FormMain formMain = new FormMain();
            formMain.Closed += (s, args) => this.Close();
            formMain.Show();
        }
        public void ChangePasswordChar()
        {
            passwordTextBox.PasswordChar = '*';
        }
    }
}
