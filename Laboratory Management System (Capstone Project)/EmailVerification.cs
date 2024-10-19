using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class EmailVerification : Form
    {
        private int timer = 60 * 5;
        private string email = "";
        private string PIN = "";
        private bool isResend = false;
        public bool isVerified = false;

        public EmailVerification(string email)
        {
            InitializeComponent();
            this.email = email;
            send(email);
            
            UIHelper.SetRoundedCorners(this, 50);
            UIHelper.SetRoundedCorners(btnVerify, 20);
            UIHelper.SetShadow(panel1);
        }

        private void send(string email)
        {
            GetPin Getpin = new GetPin();
            smtp_Framework mail = new smtp_Framework();
            PIN = Getpin.Pin();
            mail.SmtpCredentials("revenger45626@gmail.com", "fwquvhusxramyfis");
            mail.Send(email, "Email Verification", "This is your verification PIN \n\n" + PIN);
      

            timer = 60 * 5;
            timer1.Enabled = true;

        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            isResend = true;
            btnResend.Enabled = false;
            send(email);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;

            
            //if (timer > 0)
            //    Text = "Email Verification " + "(" + timer.ToString() + "s" + ")";
            //else
            //    Text = "Email Verification" + "(Please Resend PIN)";

            if (isResend)
            {
                btnResend.Text = timer.ToString() + "s";
            }
            else
            {
                btnResend.Text = "Re-send";
            }

            if (timer == 0)
            {
                PIN = "";
                btnResend.Text = "Re-send";
                btnResend.Enabled = true;
                timer1.Enabled = false;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (tbPIN.Text == PIN)
            {
                isVerified = true;
                MessageBox.Show("Email verified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid PIN. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm register = new RegistrationForm();
            register.ShowDialog();
        }
    }
}
