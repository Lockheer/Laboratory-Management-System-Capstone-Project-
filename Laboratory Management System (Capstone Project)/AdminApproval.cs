using Laboratory_Management_System__Capstone_Project_.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class AdminApproval : Form
    {
        public AdminApproval()
        {
            InitializeComponent();

            UIHelper.SetRoundedCorners(this, 40);

            UIHelper.SetRoundedCorners(btnConfirm, 20);
            UIHelper.SetRoundedCorners(tbReject, 20);

            tbAdminPass.PasswordChar = '*';
        }

        HashHelpers hashHelpers = new HashHelpers();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate that the admin ID-Number and password are entered
            if (string.IsNullOrEmpty(tbAdminUsername.Text) || string.IsNullOrEmpty(tbAdminPass.Text))
            {
                MessageBox.Show("Please enter both Admin ID-Number and Password.", "Missing Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Set up the SQL connection
                using (SqlConnection conn = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    conn.Open();

                    // SQL query to verify admin credentials by matching ID-Number and Password with RoleName as "Admin"
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Accounts a " +
                        "INNER JOIN Roles r ON a.RoleID = r.RoleID " +
                        "WHERE a.Username = @Username AND a.Password = @Password AND r.RoleName = @RoleName", conn);

                    // Add the parameters for ID-Number, Password, and RoleName ("Admin")
                    cmd.Parameters.AddWithValue("@Username", tbAdminUsername.Text); // Admin ID textbox
                    cmd.Parameters.AddWithValue("@Password", hashHelpers.CreateMD5Hash(hashHelpers.CreateMD5Hash(tbAdminPass.Text))); // Admin Password textbox (hashed)
                    cmd.Parameters.AddWithValue("@RoleName", "Admin"); // Static value "Admin" for role

                    // Execute the query and get the count (1 if credentials match, 0 if they don't)
                    int count = (int)cmd.ExecuteScalar();

                    // If count is 1, credentials match and the user has the Admin role
                    if (count == 1)
                    {
                        MessageBox.Show("Approval successful!", "Admin Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Set DialogResult to OK to indicate approval
                        this.DialogResult = DialogResult.OK;

                        // Close the AdminApproval form
                        this.Close();
                    }
                    else
                    {
                        // Display error if credentials are invalid or user is not an Admin
                        MessageBox.Show("Invalid Admin credentials or not an Admin role.", "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during the approval process: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void tbReject_Click(object sender, EventArgs e)
        {
            // Set DialogResult to Cancel to indicate the operation was canceled
            this.DialogResult = DialogResult.Cancel;

            // Close the AdminApproval form
            this.Close();
        }
    }
}
