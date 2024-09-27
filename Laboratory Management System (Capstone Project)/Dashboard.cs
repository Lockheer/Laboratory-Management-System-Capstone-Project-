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

        private Timer collapseExpandTimer;
        private bool isCollapsed = true;
        private const int animationInterval = 1;
        private const int animationStep = 20;
        private const int collapsedWidth = 90;
        private const int expandedWidth = 320;
        private bool isMouseInsideMenuStrip = false;
        private bool isMenuItemClicked = false;


        public Dashboard()
        {
            InitializeComponent();

            menuStrip3.RenderMode = ToolStripRenderMode.Professional;
            menuStrip3.Renderer = new CustomToolStripRenderer();

            collapseExpandTimer = new Timer();
            collapseExpandTimer.Interval = animationInterval;
            collapseExpandTimer.Tick += CollapseExpandTimer_Tick;

            panel1.DoubleBuffered(true);

            panel1.Width = collapsedWidth;
            menuStrip3.Width = collapsedWidth;

            panelContainer.Left = panel1.Right;

            menuStrip3.MouseEnter += MenuStrip3_MouseEnter;
            panelContainer.Click += PanelContainer_Click;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            menuStrip3.Visible = true;

            // Apply rounded corners
            // SetRoundedCorners(30); 

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
        }


        private void MenuStrip3_MouseEnter(object sender, EventArgs e)
        {
            isMouseInsideMenuStrip = true;

            if (isCollapsed)
            {
                isCollapsed = false;
                collapseExpandTimer.Start();
            }
        }



        private void PanelContainer_Click(object sender, EventArgs e)
        {
            if (!isCollapsed)
            {
                isCollapsed = true;
                collapseExpandTimer.Start();
            }
        }

        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Color hoverColor = ColorTranslator.FromHtml("#0E287A");

                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(hoverColor), e.Item.ContentRectangle);
                }
            }
        }


        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (collapseExpandTimer.Enabled)
                return;
            isCollapsed = !isCollapsed;
            collapseExpandTimer.Start();
        }

        private void CollapseExpandTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                if (panel1.Width > collapsedWidth)
                {
                    panel1.Width -= animationStep;
                    menuStrip3.Width = panel1.Width;

                    panelContainer.Left = panel1.Right;
                }
                else
                {
                    collapseExpandTimer.Stop();
                    panel1.Width = collapsedWidth;
                    menuStrip3.Width = collapsedWidth;


                    panelContainer.Left = panel1.Right;
                }
            }
            else
            {
                if (panel1.Width < expandedWidth)
                {
                    panel1.Width += animationStep;
                    menuStrip3.Width = panel1.Width;

                    panelContainer.Left = panel1.Right;
                }
                else
                {
                    collapseExpandTimer.Stop();
                    panel1.Width = expandedWidth;
                    menuStrip3.Width = expandedWidth;

                    panelContainer.Left = panel1.Right;
                }
            }
        }


        private void picBoxBC_Click(object sender, EventArgs e)
        {
            // Create a temporary list of forms to close
            List<Form> formsToClose = openForms.Values.ToList();

            // Close all forms
            foreach (var form in formsToClose)
            {
                if (form != null)
                {
                    form.Close();
                }
            }

            // Clear the openForms dictionary
            openForms.Clear();

            // Clear the panelContainer controls
            panelContainer.Controls.Clear();
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

    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property.SetValue(control, enable, null);
        }
    }

}

