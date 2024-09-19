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
            tbPassword.KeyPress += new KeyPressEventHandler(tbPassword_KeyPress);
        }

        RegistrationAccountDataContext db = new RegistrationAccountDataContext();
        HashHelpers hashHelper = new HashHelpers();

        public static class Session
        {
            public static int AccountID { get; set; }
            public static string IDNumber { get; set; }  
            public static string FirstName { get; set; }  
            public static string Role { get; set; }  
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


        // LOGIN BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            //Username Error Handler
            if (string.IsNullOrEmpty(tbUsername.Text) || tbUsername.Text == "Username")
            {
               lblUsernameHandler.Visible = true;
                lblHint.Visible = true;
                return;
            }else
            {
                lblUsernameHandler.Visible = false;
                lblHint.Visible = false;
            }

            //Password Error Handler
            if (string.IsNullOrEmpty(tbPassword.Text) || tbPassword.Text == "Password")
            {
               lblPasswordHandler.Visible = true;
                return;
            }else
            {
                lblPasswordHandler.Visible = false;
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

            //Double hashing
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
                    lblErrorHandler.Visible = true;
                }
                return;
            }

           
            failedLoginAttempts = 0;

           

            // Retrieve the additional information
            var userInfo = db.UserRegistrations.FirstOrDefault(u => u.UserID == admin.UserID);
            var role = db.Roles.FirstOrDefault(r => r.RoleID == admin.RoleID);

            Form1.Session.AccountID = admin.AccountID;
            Form1.Session.IDNumber = userInfo?.ID_number;
            Form1.Session.FirstName = userInfo?.First_Name;
            Form1.Session.Role = role?.RoleName;





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
                
            }else if (tbUsername.Text != "Username")
            {
                lblUsernameHandler.Visible = false;
                lblHint.Visible = false;
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
            }else if (tbPassword.Text != "Password")
            {
               lblPasswordHandler.Visible = false;
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

     

        // Minimize button
        private void button3_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            failedLoginAttempts = 0;
            cooldownStartTime = DateTime.MinValue;
            lblErrorHandler.Visible = false;
            lblHint.Visible = false;
            lblUsernameHandler.Visible = false;
            lblPasswordHandler.Visible = false;
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
            this.Hide();
            ChangePassVerification changePass = new ChangePassVerification();
            changePass.ShowDialog();
          
        }

        private void lnkLblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Prevents windows beep sound or error sound
                e.Handled = true;

                btnLogin.PerformClick();
            }



        }
    }
}