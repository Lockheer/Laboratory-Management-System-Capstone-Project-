using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class ChangePassVerification : Form
    {
        int timer = 60 * 5;
        string pin = "";


        RegistrationAccountDataContext db = new RegistrationAccountDataContext();

        public string message(string Pin)
        {
            return "Your verification code is: " + Pin;
        }
        public ChangePassVerification()
        {
            InitializeComponent();

            UIHelper.SetRoundedCorners(pictureBox3, 170);

            UIHelper.SetRoundedCorners(btnSendPIN, 40);
            UIHelper.SetRoundedCorners(btnConfirm, 40);
        }

        private void btnSendPIN_Click(object sender, EventArgs e)
        {
            var user = db.UserRegistrations
                  .Where(o => o.Email == tbEmail.Text)
                  .FirstOrDefault();

            if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (tbEmail.Text == "")
            {
                MessageBox.Show("Please enter your email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user == null || string.IsNullOrEmpty(user.Email))
            {
                MessageBox.Show("Email address not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                timer1.Enabled = true;
                btnSendPIN.Enabled = false;
                send();
            }
        }

        private void send()
        {
            GetPin Getpin = new GetPin();
            smtp_Framework mail = new smtp_Framework();
            pin = Getpin.Pin();
            mail.SmtpCredentials("revenger45626@gmail.com", "Revengerkyoto45626");
            mail.Send(tbEmail.Text, "Password Reset Verification", message(pin));
            timer = 60 * 10;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;
        
            btnSendPIN.Text = timer.ToString() + "s";
            if (timer == 0)
            {
                pin = "";
                btnSendPIN.Text = "Re-send";
                btnSendPIN.Enabled = true;
                timer1.Enabled = false;
            }

        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbPin.Text == pin)
            {
                ChangePasswordForm changePasswordForm = new ChangePasswordForm(tbEmail.Text);
                changePasswordForm.Show();
                this.Hide();
             
            }
            else
            {
                MessageBox.Show("Invalid Pin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnklblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
