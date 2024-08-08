using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using Laboratory_Management_System__Capstone_Project_.Helpers;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class RegistrationForm : Form
    {
        string gender;
      

        public RegistrationForm()
        {
            InitializeComponent();
            //Key press event handler for the Contact Number input
            tbContactNumber.KeyPress += new KeyPressEventHandler(tbContactNumber_KeyPress);
        }
        //Connecting to DataContext class from SQL
        RegistrationAccountDataContext db = new RegistrationAccountDataContext();

        //Hashing 
        HashHelpers hashHelper = new HashHelpers();



        private void RegistrationForm_Load(object sender, EventArgs e)
        {
          
            lblUsername.Hide();
            tbUsername.Hide();
            lblPassword.Hide();
            tbPass.Hide();
            lblConfirm.Hide();
            tbConfirmPass.Hide();
            lblReminder.Hide();
            chkShowPass.Hide();
            lblShowPass.Hide();
            btnRegister.Hide();


        }


        //Restriction for the ContactNumber input
        private void tbContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void radiobtnMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
            lblGender.Text = gender;
        }

        private void radiobtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            lblGender.Text = gender;    
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            
                lblReminder.Show();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            lblReminder.Hide();
        }

        //Registration Method and Event
        private void btnRegister_Click(object sender, EventArgs e)
        {
            db = new RegistrationAccountDataContext();

            // Restrictions for valid email
            if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Check if Email already exists
            var emailExists = db.AdminRegisters.Any(a => a.Email == tbEmail.Text);
            if (emailExists)
            {
                MessageBox.Show("This email address is already in use. Please use a different email.");
                return;
            }

            // Check if ID number already exists
            var idExists = db.AdminRegisters.Any(a => a.ID_number == tbID.Text);
            if (idExists)
            {
                MessageBox.Show("This ID number is already in use. Please use a different ID number.");
                return;
            }

            // Check if Username already exists
            var usernameExists = db.AdminAccounts.Any(a => a.Username == tbUsername.Text);
            if (usernameExists)
            {
                MessageBox.Show("This username is already in use. Please choose a different username.");
                return;
            }

            // Password length check
            if (tbPass.TextLength < 8 || tbPass.TextLength > 16)
            {
                MessageBox.Show("Password must be between 8 and 16 characters.");
                return;
            }

            // Password confirmation
            if (tbPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Check if ID number matches the username
            if (tbID.Text != tbUsername.Text)
            {
                MessageBox.Show("Your username must be your ID Number.");
                return;
            }

            // Validate ID number format
            if (tbID.TextLength != 10 || !tbID.Text.Contains("-"))
            {
                MessageBox.Show("ID number format is incorrect or not valid.");
                return;
            }

            // Check for empty fields
            if (string.IsNullOrEmpty(tbFirstName.Text) ||
                string.IsNullOrEmpty(tbLastName.Text) ||
                string.IsNullOrEmpty(tbEmail.Text) ||
                string.IsNullOrEmpty(tbUsername.Text) ||
                string.IsNullOrEmpty(lblGender.Text) ||
                string.IsNullOrEmpty(tbID.Text) ||
                string.IsNullOrEmpty(tbContactNumber.Text) ||
                string.IsNullOrEmpty(tbPass.Text) ||
                string.IsNullOrEmpty(tbConfirmPass.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Save the new registration
            db.SP_REGISTER(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbEmail.Text, lblGender.Text,
                tbID.Text, tbContactNumber.Text, dtpBirthdate.Text, tbUsername.Text,
                hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbPass.Text)));

            MessageBox.Show("Successfully Registered");
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }


      

        private void btnNext_Click(object sender, EventArgs e)
        {
            lbFN.Visible = false;
            tbFirstName.Visible = false;
            lbLN.Visible = false;
            tbLastName.Visible = false;
            lbMN.Visible = false;
            tbMiddleName.Visible = false;
            lblEmail.Visible = false;
            tbEmail.Visible = false;
            lbIDnum.Visible = false;
            tbID.Visible = false;
            lbContact.Visible = false;
            dtpBirthdate.Visible = false;
            groupGender.Visible = false;
            tbContactNumber.Visible = false;
            lblBirth.Visible = false;


            lblUsername.Visible = true;
            tbUsername.Visible = true;
            lblPassword.Visible =  true;
            tbPass.Visible = true;
            lblConfirm.Visible = true;
            tbConfirmPass.Visible = true;
            lblReminder.Visible = true;
            chkShowPass.Visible = true;
            lblShowPass.Visible = true;
           btnRegister.Visible = true;

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            lbFN.Visible = true;
            tbFirstName.Visible = true;
            lbLN.Visible = true;
            tbLastName.Visible = true;
            lbMN.Visible = true;
            tbMiddleName.Visible = true;
            lblEmail.Visible = true;
            tbEmail.Visible = true;
            lbIDnum.Visible = true;
            tbID.Visible = true;
            lbContact.Visible = true;
            tbContactNumber.Visible = true;
            dtpBirthdate.Visible = true;
            groupGender.Visible = true;
        


            lblUsername.Visible = false;
            tbUsername.Visible = false;
            lblPassword.Visible = false;
            tbPass.Visible = false;
            lblConfirm.Visible = false;
            tbConfirmPass.Visible = false;
            lblReminder.Visible = false;
            chkShowPass.Visible = false;
            lblShowPass.Visible = false;
            btnRegister.Visible = false;


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                // Show password
                tbPass.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                tbPass.UseSystemPasswordChar = true;
            }
        }
    }
}
