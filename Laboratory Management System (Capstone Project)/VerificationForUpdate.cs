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
    public partial class VerificationForUpdate : Form
    {
        RegistrationAccountDataContext db = new RegistrationAccountDataContext();
        HashHelpers hashHelper = new HashHelpers();
        private Dashboard dashboard;

        private int failedPasswordAttempts = 0;
        private const int maxPasswordAttempts = 3;
        private DateTime cooldownStartTime;
        private TimeSpan cooldownPeriod = TimeSpan.FromMinutes(2);

        public VerificationForUpdate(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (failedPasswordAttempts >= maxPasswordAttempts)
            {
                if (DateTime.Now < cooldownStartTime.Add(cooldownPeriod))
                {
                    TimeSpan remainingCooldown = cooldownStartTime.Add(cooldownPeriod) - DateTime.Now;
                    MessageBox.Show($"Too many failed attempts. Please try again in {remainingCooldown.Minutes} minutes and {remainingCooldown.Seconds} seconds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Reset the failed attempts after cooldown
                    failedPasswordAttempts = 0;
                }
            }

            if (string.IsNullOrEmpty(tbConfirmPass.Text))
            {
                MessageBox.Show("Please enter your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hashedPassword = hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbConfirmPass.Text));

            var admin = db.AdminAccounts
                          .Where(o => o.AccountID == Form1.Session.AccountID && o.Password == hashedPassword)
                          .FirstOrDefault();

            if (admin != null)
            {
                UpdateBorrowReturnTransaction updateTransactForm = new UpdateBorrowReturnTransaction();
                dashboard.ShowFormInPanel(updateTransactForm);
                this.Close();
            }
            else
            {
                failedPasswordAttempts++;
                if (failedPasswordAttempts >= maxPasswordAttempts)
                {
                    cooldownStartTime = DateTime.Now;
                    MessageBox.Show($"Too many failed attempts. Please try again in {cooldownPeriod.Minutes} minutes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerificationForUpdate_Load(object sender, EventArgs e)
        {
            failedPasswordAttempts = 0;
            cooldownStartTime = DateTime.MinValue;
        }
    }
}