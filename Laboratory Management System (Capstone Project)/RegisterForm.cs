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
            // Key press event handler for the Contact Number input
            tbContactNumber.KeyPress += new KeyPressEventHandler(tbContactNumber_KeyPress);
        }

        // Connecting to DataContext class from SQL
        RegistrationAccountDataContext db = new RegistrationAccountDataContext();

        // Hashing 
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
            btnPrevious.Hide();
            lblCredentials.Hide();
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
                        MessageBox.Show("The Admin role can only have up to 10 registered users.");
                        return;
                    }
                }
            }

            // Restrictions for valid email
            if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Check if Email already exists
            var emailExists = db.UserRegistrations.Any(a => a.Email == tbEmail.Text);
            if (emailExists)
            {
                MessageBox.Show("This email address is already in use. Please use a different email.");
                return;
            }

            // Check if ID number already exists
            var idExists = db.UserRegistrations.Any(a => a.ID_number == tbID.Text);
            if (idExists)
            {
                MessageBox.Show("This ID number is already in use. Please use a different ID number.");
                return;
            }

            // Check if Username already exists
            var usernameExists = db.Accounts.Any(a => a.Username == tbUsername.Text);
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


            if (cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role.","Error: No Role registered.", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }else if (lblGender.Text == "Gender")
            {
                MessageBox.Show("Please choose your gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
         hashHelper.CreateMD5Hash(hashHelper.CreateMD5Hash(tbPass.Text)), roleID);

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
            btnNext.Visible = false;
            lblRole.Visible = false;
            cbRole.Visible = false;
            lblInfo.Visible = false;

            lblUsername.Visible = true;
            tbUsername.Visible = true;
            lblPassword.Visible = true;
            tbPass.Visible = true;
            lblConfirm.Visible = true;
            tbConfirmPass.Visible = true;
            lblReminder.Visible = true;
            chkShowPass.Visible = true;
            lblShowPass.Visible = true;
            btnRegister.Visible = true;
            btnPrevious.Visible = true;
            lblCredentials.Visible = true;
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
            btnNext.Visible = true;
            lblRole.Visible = true;
            cbRole.Visible = true;
            lblInfo.Visible = true;

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
            btnPrevious.Visible = false;
            lblCredentials.Visible = false;
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
    }
}