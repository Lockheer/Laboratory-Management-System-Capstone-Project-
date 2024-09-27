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
        private bool emailVerified = false;

        public RegistrationForm()
        {
            InitializeComponent();
            // Key press event handler for the Contact Number input
            tbContactNumber.KeyPress += new KeyPressEventHandler(tbContactNumber_KeyPress);
        }

        // Connecting to DataContext class from SQL
        RegistrationAccountDataContext db = new RegistrationAccountDataContext();

        // Hashing 
        HashHelpers hashHelper = new HashHelpers();

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

            dtpBirthdate.Format = DateTimePickerFormat.Custom;
            dtpBirthdate.CustomFormat = " ";
            lblGender.Visible = false;
            LoadRoles();


        }

        private void LoadRoles()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM Roles", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items
                    cbRole.Items.Clear();

                    while (reader.Read())
                    {
                        var roleName = reader.GetString(1);
                        var roleID = reader.GetInt32(0);

                        // Create a new ComboBoxItem with RoleName as the text and RoleID in the Tag property
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Text = roleName,
                            Tag = roleID
                        };

                        cbRole.Items.Add(item);
                    }

                    // Close reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
        }

        // Restriction for the ContactNumber input
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
            lblGender.Visible = true;
            lblGender.Text = gender;
        }

        private void radiobtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            lblGender.Visible = true;
            lblGender.Text = gender;
        }


        // Registration Method and Event
        private void btnRegister_Click(object sender, EventArgs e)
        {
            db = new RegistrationAccountDataContext();

            if (cbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            // Retrieve the selected role
            ComboBoxItem selectedItem = (ComboBoxItem)cbRole.SelectedItem;
            int roleID = (int)selectedItem.Tag;

            // Check if Admin role limit is reached
            if (selectedItem.Text == "Admin")
            {
                using (SqlConnection conn = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE RoleID = @RoleID", conn);
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    int count = (int)cmd.ExecuteScalar();
                    if (count >= 10)
                    {
                        MessageBox.Show("The Admin role can only have up to 10 registered users.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Restrictions for valid email
            if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if Email already exists
            var emailExists = db.UserRegistrations.Any(a => a.Email == tbEmail.Text);
            if (emailExists)
            {
                MessageBox.Show("This email address is already in use. Please use a different email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if ID number already exists
            var idExists = db.UserRegistrations.Any(a => a.ID_number == tbID.Text);
            if (idExists)
            {
                MessageBox.Show("This ID number is already in use. Please use a different ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usernameExists = db.Accounts.Any(a => a.Username == tbID.Text);
            if (usernameExists)
            {
                MessageBox.Show("This username (ID Number) is already in use. Please choose a different ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password length check
            if (tbPass.TextLength < 8 || tbPass.TextLength > 16 || !tbPass.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Password must be between 8 and 16 characters.", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password confirmation
            if (tbPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role.", "Error: No Role registered.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (lblGender.Text == "Gender:" || lblGender.Text == "Gender")
            {
                MessageBox.Show("Please choose your gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate ID number format
            if (tbID.TextLength != 8 || !tbID.Text.Contains("-"))
            {
                MessageBox.Show("ID number format is incorrect or not valid.", "Invalid ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check for empty fields
            if (string.IsNullOrEmpty(tbFirstName.Text) ||
                string.IsNullOrEmpty(tbLastName.Text) ||
                string.IsNullOrEmpty(tbEmail.Text) ||
                string.IsNullOrEmpty(lblGender.Text) ||
                string.IsNullOrEmpty(tbID.Text) ||
                string.IsNullOrEmpty(tbContactNumber.Text) ||
                string.IsNullOrEmpty(tbPass.Text) ||
                string.IsNullOrEmpty(tbConfirmPass.Text))
            {
                MessageBox.Show("Please fill in all the necessary fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the DateTimePicker is empty (custom format means no date selected)
            if (dtpBirthdate.Format == DateTimePickerFormat.Custom)
            {
                MessageBox.Show("Please select a valid birthdate.", "Missing Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the user is at least 18 years old
            if (!IsUserEighteenYearsOld())
            {
                MessageBox.Show("You must be at least 18 years old to register.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if the email was verified
            if (!emailVerified)
            {
                MessageBox.Show("Please verify your email before proceeding.", "Email Not Verified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Role requires admin approval (Admin or Personnel roles)
            if (selectedItem.Text == "Admin" || selectedItem.Text == "Personnel")
            {
                // Open the AdminApproval form for admin credentials
                AdminApproval adminApprovalForm = new AdminApproval();

                // Show the form and get the result when it's closed
                DialogResult result = adminApprovalForm.ShowDialog();

                // IF-ELSE based on the result of the form dialog
                if (result == DialogResult.OK)
                {
                    // Admin confirmed the approval
                    MessageBox.Show("Registration approved by Admin.", "Approval Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Proceed with registration process
                }
                else if (result == DialogResult.Cancel)
                {
                    // Admin denied or canceled the approval
                    MessageBox.Show("Registration not approved by Admin.", "Approval Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the registration process if not approved
                }
            }

            // Save the new registration
            db.SP_REGISTER(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbEmail.Text, lblGender.Text,
         tbID.Text, tbContactNumber.Text, dtpBirthdate.Text, tbID.Text,
         hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbPass.Text)), roleID);


            // If all checks pass, proceed with the registration
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
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
                lblShowPass.Text = "Hide Password";
            }
            else
            {
                // Hide password
                tbPass.UseSystemPasswordChar = true;
                lblShowPass.Text = "Show Password";
            }
        }

        // Define a class to hold role data
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Tag { get; set; }

            public override string ToString()
            {
                return Text; // This will be displayed in the ComboBox
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbMiddleName.Clear();
            tbEmail.Clear();
            tbID.Clear();
            tbContactNumber.Clear();
            tbPass.Clear();
            tbConfirmPass.Clear();
            dtpBirthdate.ResetText();

        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            dtpBirthdate.Format = DateTimePickerFormat.Short;
        }

        //Validates user age
        private bool IsUserEighteenYearsOld()
        {
            DateTime today = DateTime.Today;

            // Ensure the DateTimePicker has a valid date selected
            if (dtpBirthdate.Format == DateTimePickerFormat.Custom)
            {
                MessageBox.Show("Please select a valid birthdate.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime birthDate = dtpBirthdate.Value;
            int age = today.Year - birthDate.Year;

            // Adjust if the birthdate hasn't occurred yet this year
            if (birthDate > today.AddYears(-age))
                age--;

            // Check if the user is 18 years or older
            if (age < 18)
            {
                MessageBox.Show("You must be at least 18 years old or above to register.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Please enter your email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                EmailVerification emailVerification = new EmailVerification(tbEmail.Text);
                emailVerification.ShowDialog();

                if (emailVerification.isVerified)
                {
                    emailVerified = true; // Set the flag to true if verified
                    btnVerify.Enabled = false; // Disable the button after verification
                    btnVerify.Text = "Verified"; // Change the button text to "Verified
                    MessageBox.Show("Email verification successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    emailVerified = false; // Reset if verification failed
                    MessageBox.Show("Email verification failed. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}