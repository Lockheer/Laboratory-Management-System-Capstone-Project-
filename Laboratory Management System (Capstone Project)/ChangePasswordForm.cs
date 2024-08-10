using Laboratory_Management_System__Capstone_Project_.Helpers;
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
    public partial class ChangePasswordForm : Form
    {
        RegistrationAccountDataContext db = new RegistrationAccountDataContext();
        HashHelpers hashHelper = new HashHelpers();

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbCurrentPassword.Text))
                {
                    MessageBox.Show("Please enter your current password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(tbNewPassword.Text) || string.IsNullOrEmpty(tbConfirmPassword.Text))
                {
                    MessageBox.Show("Please enter your new password and confirm it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbNewPassword.Text != tbConfirmPassword.Text)
                {
                    MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure password complexity (e.g., minimum length, special characters)
                if (tbNewPassword.Text.Length < 8 || !tbNewPassword.Text.Any(char.IsDigit) || !tbNewPassword.Text.Any(char.IsUpper))
                {
                    MessageBox.Show("New password must be at least 8 characters long, include a number, and an uppercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hash the current password for validation
                var hashedCurrentPassword = hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbCurrentPassword.Text));

                // Fetch the current user's record from the database
                var admin = db.AdminAccounts
                               .Where(o => o.AccountID == Form1.Session.AccountID && o.Password == hashedCurrentPassword)
                               .FirstOrDefault();

                if (admin == null)
                {
                    MessageBox.Show("Incorrect current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hash the new password
                var hashedNewPassword = hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbNewPassword.Text));

                // Update the password in the database
                admin.Password = hashedNewPassword;
                db.SubmitChanges();

                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Log out the user and redirect to the login screen
                MessageBox.Show("You will now be logged out. Please log in again with your new password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                // Invalidate session
                Form1.Session.AccountID = 0;

               
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Assuming this is called from the dashboard, close the dashboard
                Application.OpenForms["Dashboard"]?.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred while changing the password. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

      
    }
}