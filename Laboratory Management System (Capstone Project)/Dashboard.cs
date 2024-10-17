using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Laboratory_Management_System__Capstone_Project_
{


    public partial class Dashboard : Form
    {
        public static int formRestrict;
        private Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();

        public Dashboard()
        {
            InitializeComponent();

            menuStrip3.RenderMode = ToolStripRenderMode.Professional;
            menuStrip3.Renderer = new CustomToolStripRenderer();

            UIHelper.ApplyHoverEffectToMenuStrip(menuStrip3);

            UIHelper.SetShadow(panel1);
            UIHelper.SetRoundedCorners(panel1, 30);
            UIHelper.SetRoundedCorners(panelDashboard, 80);
            UIHelper.SetRoundedCorners(panelRules, 30);
            UIHelper.SetRoundedCorners(pictureBox1, 40);
            UIHelper.SetRoundedCorners(btnInventoryShortcut, 30);
            UIHelper.SetRoundedCorners(btnStudentListShortcut, 30);

            UIHelper.SetRoundedCorners(ShowCountPanel, 20);

            UIHelper.SetGradientBackground(panel1, Color.FromArgb(5, 21, 101), Color.FromArgb(20, 57, 175), LinearGradientMode.Horizontal);
            UIHelper.SetGradientBackground(panelDashboard, Color.FromArgb(5, 21, 101), Color.FromArgb(20, 57, 175), LinearGradientMode.Horizontal);
        }


        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                // Correct usage of Color.FromArgb with integer parameters
                Color hoverColor = Color.FromArgb(250, 109, 21); // Orange color

                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(hoverColor), e.Item.ContentRectangle);
                }
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
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
                updateTransactionsToolStripMenuItem.Visible = false; // Hide access to UpdateTransactions for Personnel
            }

            ShowShortcutButtons();
            ShowApparatusCount();
        }

        private void picBoxBC_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation
            if (MessageBox.Show("Are you sure you want to close all forms?", "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Remove any forms that are currently being shown in the panelContainer
                foreach (Control control in panelContainer.Controls)
                {
                    if (control is Form)
                    {
                        control.Dispose();
                    }
                }

                // Show the Dashboard controls
                ShowShortcutButtons();
                ShowApparatusCount();

                // Refresh the UI to ensure everything is updated
                this.Refresh();
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
            // Remove any forms that are currently being shown in the panelContainer
            foreach (Control control in panelContainer.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                }
            }

            // Hide the shortcut buttons
            btnInventoryShortcut.Visible = false;
            btnStudentListShortcut.Visible = false;
            lblShortcut.Visible = false;
            lblFirstName.Visible = false;
            lblIDNumber.Visible = false;

            // Hide the labels
            apparatusCountLabel.Visible = false;
            studentCountLabel.Visible = false;
            borrowedApparatusCountLabel.Visible = false;
            returnedApparatusCountLabel.Visible = false;
            lblOverview.Visible = false;
            ShowCountPanel.Visible = false;
            lblTitle.Visible = false;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }

        /*public void ShowFormInPanel(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }*/

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

        private void dashboardDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowShortcutButtons();
            ShowApparatusCount();
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

     
        private void btnInventoryShortcut_Click(object sender, EventArgs e)
        {
            InventoryList viewApp = new InventoryList();
            ShowFormInPanel(viewApp);
        }

        private void btnStudentListShortcut_Click(object sender, EventArgs e)
        {
            ViewStudentInformation viewStudents = new ViewStudentInformation();
            ShowFormInPanel(viewStudents);
        }

        private void ShowShortcutButtons()
        {
            btnInventoryShortcut.Visible = true;
            btnStudentListShortcut.Visible = true;
            lblShortcut.Visible = true;

            apparatusCountLabel.Visible = true;
            studentCountLabel.Visible = true;
            borrowedApparatusCountLabel.Visible = true;
            returnedApparatusCountLabel.Visible = true;
            lblOverview.Visible = true;
            ShowCountPanel.Visible = true;
            lblTitle.Visible = true;
            panelRules.Visible = true;
            lblIDNumber.Visible = true;
            lblFirstName.Visible = true;
            panelDashboard.Visible = true;
        }


        private void ShowApparatusCount()
        {
            // Update the apparatus count label
            UpdateApparatusCountLabel(apparatusCountLabel);

            // Update the student count label
            UpdateStudentCountLabel(studentCountLabel);

            // Update the borrowed apparatus count label
            UpdateBorrowedApparatusCountLabel(borrowedApparatusCountLabel);

            // Update the returned apparatus count label
            UpdateReturnedApparatusCountLabel(returnedApparatusCountLabel);

            ShowCountPanel.Visible = true;
        }

         
        private void UpdateApparatusCountLabel(Label apparatusCountLabel)
        {
            // Connect to the database and retrieve the apparatus count
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";
            string query = "SELECT COUNT(*) FROM Inventory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int apparatusCount = (int)command.ExecuteScalar();

                // Update the apparatus count label
                apparatusCountLabel.Text = $"{apparatusCount}";
            }
        }

        private void UpdateStudentCountLabel(Label studentCountLabel)
        {
            // Connect to the database and retrieve the student count
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";
            string query = "SELECT COUNT(*) FROM Students";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int studentCount = (int)command.ExecuteScalar();

                // Update the student count label
                studentCountLabel.Text = $"{studentCount}";
            }
        }

        private void UpdateBorrowedApparatusCountLabel(Label borrowedApparatusCountLabel)
        {
            // Connect to the database and retrieve the borrowed apparatus count
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";
            string query = "SELECT COUNT(*) FROM BorrowReturnTransaction WHERE Date_Returned IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int borrowedApparatusCount = (int)command.ExecuteScalar();

                // Update the borrowed apparatus count label
                borrowedApparatusCountLabel.Text = $"{borrowedApparatusCount}";
            }
        }

        private void UpdateReturnedApparatusCountLabel(Label returnedApparatusCountLabel)
        {
            // Connect to the database and retrieve the returned apparatus count
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";
            string query = "SELECT COUNT(*) FROM BorrowReturnTransaction WHERE Date_Returned IS NOT NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int returnedApparatusCount = (int)command.ExecuteScalar();

                // Update the returned apparatus count label
                returnedApparatusCountLabel.Text = $"{returnedApparatusCount}";
            }
        }

       
        public void NavigateBackToDashboard()
        {
            // Remove the current form from the panelContainer
            panelContainer.Controls.Clear();

            // Show the shortcut buttons
            btnInventoryShortcut.Visible = true;
            btnStudentListShortcut.Visible = true;
            lblShortcut.Visible = true;

            // Show the labels
            apparatusCountLabel.Visible = true;
            studentCountLabel.Visible = true;
            borrowedApparatusCountLabel.Visible = true;
            returnedApparatusCountLabel.Visible = true;
            lblOverview.Visible = true;
            ShowCountPanel.Visible = true;
            lblTitle.Visible = true;
        }


        private void dashboardtoolStripMenu_Click(object sender, EventArgs e)
        { // Remove any forms that are currently being shown in the panelContainer
            foreach (Control control in panelContainer.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                }
            }

            // Show the Dashboard controls
            ShowShortcutButtons();
            ShowApparatusCount();

            // Refresh the UI to ensure everything is updated
            this.Refresh();

        }
    }
}

