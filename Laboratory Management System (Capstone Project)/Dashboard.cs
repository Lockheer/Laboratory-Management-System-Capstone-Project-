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
            // Set up the panel to display forms
            panelContainer.Dock = DockStyle.Fill;
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to log out?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
               
                Form1 login = new Form1();
                login.Show();
                this.Hide();
                }
        }

        // Method to display forms in the panel container
        private void ShowFormInPanel(Form form)
        {
            // Clears the existing controls
            panelContainer.Controls.Clear();

            // form properties
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Adding the form to the panel
            panelContainer.Controls.Add(form);
            form.Show();
        }

        //method to handle the Form closed event
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = sender as Form;
            if (form != null)
            {
                openForms.Remove(form.GetType());
                form.FormClosed -= Form_FormClosed; // Unsubscribe from the event
            }
        }

        // Method to restrict multiple instances of a form in order to prevent duplications
        private void ShowRestrictedForm(Form form)
        {
            // Check if the form type is already open
            if (openForms.ContainsKey(form.GetType()))
            {
                MessageBox.Show($"{form.Text} is already opened.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Event handler to remove form from the dictionary when closed
            form.FormClosed += Form_FormClosed;

            // Show the form and add it to the dictionary
            form.Show();
            openForms[form.GetType()] = form;
        }

        // Buttons from panel with the applied form restriction
        private void addANewApparatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddApparatus addApparatus = new AddApparatus();
            ShowRestrictedForm(addApparatus);
        }

        private void viewApparatusListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewApparatus viewApp = new ViewApparatus();
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
            UpdateBorrowReturnTransaction updateTransact = new UpdateBorrowReturnTransaction();
            ShowFormInPanel(updateTransact);
        }

       
    }
}