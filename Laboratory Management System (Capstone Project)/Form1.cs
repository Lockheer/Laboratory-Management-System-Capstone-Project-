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
using Laboratory_Management_System__Capstone_Project_.Helpers;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RegistrationAccountDataContext db = new RegistrationAccountDataContext();
        HashHelpers hashHelper = new HashHelpers();

        public static class Session
        {
            public static int AccountID { get; set; }
        }


        // 5-minute cooldown for the failed login attempts
        private int failedLoginAttempts = 0;
        private const int maxLoginAttempts = 3;
        private DateTime cooldownStartTime;
        private TimeSpan cooldownPeriod = TimeSpan.FromMinutes(5); 

        // CLOSE BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // REGISTER BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        // LOGIN BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || tbUsername.Text == "Username")
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (string.IsNullOrEmpty(tbPassword.Text) || tbPassword.Text == "Password")
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            // Check if the user enters the failed attempts cooldown 
            if (failedLoginAttempts >= maxLoginAttempts)
            {
                if (DateTime.Now < cooldownStartTime.Add(cooldownPeriod))
                {
                    TimeSpan remainingCooldown = cooldownStartTime.Add(cooldownPeriod) - DateTime.Now;
                    MessageBox.Show($"Too many failed login attempts. Please try again in {remainingCooldown.Minutes} minutes and {remainingCooldown.Seconds} seconds.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Resets the failed attempts
                    failedLoginAttempts = 0;
                }
            }

            // Appliance of Double hashing to ensure security
            var hashedPassword = hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbPassword.Text));
            var admin = db.Accounts.Where(o => o.Username == tbUsername.Text && o.Password == hashedPassword).FirstOrDefault();

            if (admin == null)
            {
                failedLoginAttempts++;
                if (failedLoginAttempts >= maxLoginAttempts)
                {
                    cooldownStartTime = DateTime.Now;
                    MessageBox.Show($"Too many failed login attempts. Please try again in {cooldownPeriod.Minutes} minutes.");
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
                return;
            }

           
            failedLoginAttempts = 0;

            // Stores the AccountID in the static Session class
            Form1.Session.AccountID = admin.AccountID;


            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide(); 
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Username")
            {
                tbUsername.Text = "";
                tbUsername.Focus();
                tbUsername.ForeColor = Color.Black;
                lblHint.Show();
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Silver;
                lblHint.Hide();
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.Silver;
                tbPassword.UseSystemPasswordChar = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (tbPassword.Text != "Password")
            {
                if (CbShowPass.Checked)
                {
                    tbPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    tbPassword.UseSystemPasswordChar = true;
                }
            }
        }

        // Minimize button
        private void button3_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            failedLoginAttempts = 0;
            cooldownStartTime = DateTime.MinValue;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if(CbShowPass.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void lnklblChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassVerification changePass = new ChangePassVerification();
            changePass.ShowDialog();
        }
    }
}