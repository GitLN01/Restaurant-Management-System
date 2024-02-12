using BusinessLayer;
using DataAccessLayer;
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

namespace PresentationLayer
{
    public partial class reservationUserControl : UserControl
    {
        readonly ReservationBusiness reservationBusiness = new ReservationBusiness();

        private string ErrorMessage = "";

        public reservationUserControl()
        {
            InitializeComponent();
        }

        private void reservationUserControl_Load(object sender, EventArgs e)
        {
            numOfCustomersTextBox.GotFocus += OnNumberOfCustomersFocus;
            numOfCustomersTextBox.LostFocus += OnNumberOfCustomersUnfocus;

            RefreshList();
        }

        public void OnNumberOfCustomersFocus(object sender, EventArgs e)
        {
            if(numOfCustomersTextBox.Text == "Number of customers")
            {
                numOfCustomersTextBox.Text = "";
            }
        }

        public void OnNumberOfCustomersUnfocus(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(numOfCustomersTextBox.Text))
            {
                numOfCustomersTextBox.Text = "Number of customers";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string TableSection = tableSectionComboBox.Text;
            string NumberOfCustomers = numOfCustomersTextBox.Text;

            DateTime date = datePicker.Value;
            DateTime time = timePicker.Value;

            date = date.Date + time.TimeOfDay;

            if(!IsValidData(TableSection, NumberOfCustomers, date))
            {
                MessageBox.Show(ErrorMessage);
                return;
            }

            Reservations reservation = new Reservations()
            {
                name = TableSection,
                number_of_customers = Convert.ToInt32(NumberOfCustomers),
                date = date,
                customer_id = UserSession.Id
            };

            reservationBusiness.InsertReservations(reservation);

            RefreshList();
        }

        public bool IsValidData(string TableSection, string NumberOfCustomers, DateTime Date)
        {
            if (TableSection == "" || NumberOfCustomers == "")
            {
                ErrorMessage = "All fields must be filled in!";
                return false;
            }

            if(!NumberOfCustomers.All(char.IsDigit))
            {
                ErrorMessage = "Number of customers must be a number!";
                return false;
            }

            if(Date.CompareTo(DateTime.Now) < 0)
            {
                ErrorMessage = "Selected date and time cannot be less than current date and time!";
                return false;
            }
            return true;
        }

        public void RefreshList()
        {
            reservationsListBox.Items.Clear();

            List<Reservations> reservationList = reservationBusiness.GetReservationsByCustomerId(UserSession.Id);

            foreach(Reservations reservation in reservationList)
            {
                reservationsListBox.Items.Add("Reservation ID:\t\t" + reservation.reservation_id);
                reservationsListBox.Items.Add("Table section:\t\t" + reservation.name);
                reservationsListBox.Items.Add("Number of customers:\t" + reservation.number_of_customers);
                reservationsListBox.Items.Add("Date:\t\t\t" + reservation.date.ToShortDateString());

                TimeSpan trimmedTime = new TimeSpan(reservation.date.TimeOfDay.Hours, reservation.date.TimeOfDay.Minutes, reservation.date.TimeOfDay.Seconds);
                reservationsListBox.Items.Add("Time:\t\t\t" + trimmedTime);
                reservationsListBox.Items.Add(Environment.NewLine);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            string input = "";
            DialogResult result = ShowInputDialog(ref input);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if(input.All(char.IsDigit))
            {
                int id;
                bool isConverted = int.TryParse(input, out id);
                if(!isConverted)
                {
                    MessageBox.Show("Reservation ID must be a number!");
                    return;
                }

                if(reservationBusiness.ExistsReservationWithId(id))
                {
                    Reservations reservations = reservationBusiness.GetReservationById(id);
                    if(reservations.customer_id == UserSession.Id)
                    {
                        reservationBusiness.DeleteReservations(reservations);
                        RefreshList();
                        return;
                    }
                }

                MessageBox.Show("No reservation found with the given ID!");
            }
            RefreshList();
        }

        private DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter reservation id:";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            inputBox.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
