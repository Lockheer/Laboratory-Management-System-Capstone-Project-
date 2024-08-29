using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Windows.Forms.VisualStyles;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class Dashboard : Form
    {
        public static int formRestrict;
        private Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panelContainer.Dock = DockStyle.Fill;

            int currentAccountId = GetCurrentAccountId();
            if (currentAccountId == -1)
            {
                MessageBox.Show("Invalid session. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1 login = new Form1();
                login.Show();
                this.Hide();
                return;
            }

            string userRole = GetUserRole(currentAccountId);

            lblIDNumber.Text = $"{Form1.Session.IDNumber} - " + $"{Form1.Session.Role}";
            lblFirstName.Text = $"{Form1.Session.FirstName}";
            

            // Restrict access based on user role
            if (userRole == "Personnel")
            {
                penaltyRecordsToolStripMenuItem.Visible = false; // Hide access to PenaltiesRecords for Personnel
            }


        }





        private int GetCurrentAccountId()
        {
            return Form1.Session.AccountID; // Retrieve the stored user ID from the session
        }

        private string GetUserRole(int accountId)
        {
            string role = string.Empty;

            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";
            string query = @"
            SELECT r.RoleName
            FROM Accounts a
            INNER JOIN Roles r ON a.RoleID = r.RoleID
            WHERE a.AccountID = @AccountID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountID", accountId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return role;
        }

        // Method to display forms in the panel container
        public void ShowFormInPanel(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }

        // Method to handle the Form closed event
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = sender as Form;
            if (form != null)
            {
                openForms.Remove(form.GetType());
                form.FormClosed -= Form_FormClosed; // Unsubscribe from the event
                form.Dispose(); // Release resources
            }
        }

        // Method to restrict multiple instances of a form
        private void ShowRestrictedForm(Form form)
        {
            if (openForms.ContainsKey(form.GetType()))
            {
                MessageBox.Show($"{form.Text} is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            form.FormClosed += Form_FormClosed;
            form.Show();
            openForms[form.GetType()] = form;
        }

        private void addANewApparatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddApparatus addApparatus = new AddApparatus();
            ShowRestrictedForm(addApparatus);
        }

        private void viewApparatusListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryList viewApp = new InventoryList();
            ShowFormInPanel(viewApp);
        }

        private void addAStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            ShowRestrictedForm(addStudent);
        }

        private void viewStudentsInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInformation viewStudents = new ViewStudentInformation();
            ShowFormInPanel(viewStudents);
        }

        private void borrowTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowingApparatus borrowApparatus = new BorrowingApparatus();
            ShowRestrictedForm(borrowApparatus);
        }

        private void returnRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnApparatus returnApparatus = new ReturnApparatus();
            ShowFormInPanel(returnApparatus);
        }

        private void comToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionDetails details = new TransactionDetails();
            ShowFormInPanel(details);
        }

        private void penaltyRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenaltiesRecords penalty = new PenaltiesRecords();
            ShowFormInPanel(penalty);
        }

        private void updateTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerificationForUpdate verification = new VerificationForUpdate(this);
            ShowRestrictedForm(verification);
        }

    

        private void lnklblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }
    }
}