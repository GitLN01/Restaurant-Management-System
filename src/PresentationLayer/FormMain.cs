using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string Name = UserSession.Name;
            homeUserControl.MakeAnOrderButton.Click += button1_Click;
            homeUserControl.MakeAReservationButton.Click += button2_Click;

            homeUserControl.WelcomeLabel = string.Format("WELCOME, {0}", Name.ToUpper());
            orderUserControl1.Hide();
            menuUserControl1.Hide();
            reservationUserControl1.Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            UserSession.ClearUser();
            SwitchToLoginScreen();
        }

        public void SwitchToLoginScreen()
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Closed += (s, args) => this.Close();
            formLogin.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homeUserControl.Show();
            orderUserControl1.Hide();
            menuUserControl1.Hide();
            reservationUserControl1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderUserControl1.Show();
            homeUserControl.Hide();
            menuUserControl1.Hide();
            reservationUserControl1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservationUserControl1.Show();
            homeUserControl.Hide();
            orderUserControl1.Hide();
            menuUserControl1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuUserControl1.Show();
            homeUserControl.Hide();
            orderUserControl1.Hide();
            reservationUserControl1.Hide();
        }
    }
}
