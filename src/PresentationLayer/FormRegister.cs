using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer
{
    public partial class FormRegister : Form
    {
        readonly CustomerBusiness customerBusiness = new CustomerBusiness();
        public string ErrorMessage;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void alreadyHaveAccountLabel_Click(object sender, EventArgs e)
        {
            switchToLogin(sender, e);
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            switchToLogin(sender, e);
        }

        private void switchToLogin(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Closed += (s, args) => this.Close();
            formLogin.Show();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            nameTextBox.GotFocus += (s, ev) => OnTextBoxFocus(s, ev, "Enter your name");
            emailTextBox.GotFocus += (s, ev) => OnTextBoxFocus(s, ev, "Email address");
            phoneTextBox.GotFocus += (s, ev) => OnTextBoxFocus(s, ev, "Phone number");
            passwordTextBox.GotFocus += OnPasswordFocus;

            nameTextBox.LostFocus += (s, ev) => OnTextBoxUnfocus(s, ev, "Enter your name");
            emailTextBox.LostFocus += (s, ev) => OnTextBoxUnfocus(s, ev, "Email address");
            phoneTextBox.LostFocus += (s, ev) => OnTextBoxUnfocus(s, ev, "Phone number");
            passwordTextBox.LostFocus += OnPasswordUnfocus;
        }

        public void OnTextBoxFocus(object sender, EventArgs e, string placeholderText)
        {
            TextBox textBox = (TextBox)sender;

            if(textBox.Text == placeholderText)
            {
                textBox.Text = "";
            }
        }

        public void OnTextBoxUnfocus(object sender, EventArgs e, string placeholderText)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = placeholderText;
        }

        public void OnPasswordFocus(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
                passwordTextBox.PasswordChar = '*';
            }
        }

        public void OnPasswordUnfocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.Text = "Password";
                passwordTextBox.PasswordChar = '\0';
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string Name = nameTextBox.Text,
                   Email = emailTextBox.Text,
                   Phone = phoneTextBox.Text,
                   Password = passwordTextBox.Text;

            if(!IsValidData(Name, Email, Phone, Password))
            {
                MessageBox.Show(ErrorMessage);
                return;
            }

            if(customerBusiness.ExistsCustomerWithEmail(Email))
            {
                MessageBox.Show("Email already exists!");
                return;
            }

            Phone = "+(381)" + Phone;
            RegisterUser(Name, Email, Phone, Password);
            OpenMainApplication();
        }

        public void RegisterUser(string Name, string Email, string Phone, string Password)
        {
            Customers customer = new Customers()
            {
                name = Name,
                email = Email,
                contact = Phone,
                password = Password
            };

            customerBusiness.InsertCustomers(customer);
            customer = customerBusiness.GetCustomerByEmail(Email);
            UserSession.SetUser(customer.customer_id, customer.name, customer.email);
        }

        public bool IsValidData(string Name, string Email, string Phone, string Password)
        {

            if(!IsNameValid(Name))
            {
                return false;
            }
            if(!IsEmailValid(Email))
            {
                ErrorMessage = "Email address is not valid!";
                return false;
            }
            if(!IsPhoneValid(Phone))
            {
                ErrorMessage = "Phone number is not valid!";
                return false;
            }
            if (!IsPasswordValid(Password))
            {
                return false;
            }

            return true;
        }

        public bool IsNameValid(string Name)
        {
            if(string.IsNullOrWhiteSpace(Name) || Name == "Enter your name")
            {
                ErrorMessage = "Name field must be filled in!";
                return false;
            }
            else if(Name.Length >= 16)
            {
                ErrorMessage = "Name field must have 15 characters or less!";
                return false;
            }
            else if(!Name.All(char.IsLetter))
            {
                ErrorMessage = "Name must contain only characters!";
                return false;
            }

            return true;
        }

        public bool IsEmailValid(string Email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            return Regex.IsMatch(Email, pattern);
        }

        public bool IsPhoneValid(string phone)
        {
            if (!phone.All(char.IsDigit) || phone.Length < 9 || phone.Length > 10)
            {
                return false;
            }
            return true;
        }

        public bool IsPasswordValid(string Password)
        {
            if(Password.Length < 6)
            {
                ErrorMessage = "Password must have 6 or more characters!";
                return false;
            }
            else if(Password.Length > 20)
            {
                ErrorMessage = "Password must have less than 20 characters!";
                return false;
            }
            else if(passwordTextBox.PasswordChar != '*')
            {
                ErrorMessage = "Password must not be empty!";
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
