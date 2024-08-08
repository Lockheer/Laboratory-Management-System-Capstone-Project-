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

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the instance?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                Dashboard.formRestrict = 0;

            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbStudName.Clear();
            tbIDNum.Clear();
            tbStudEmail.Clear();
            tbStudContact.Clear();
            cbProgram.SelectedIndex = -1;
            cbDepartment.SelectedIndex = -1;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbIDNum.Text != "" && tbStudName.Text != "" && tbStudEmail.Text != ""
                && tbStudContact.Text != "" && cbProgram.Text != "" && cbDepartment.Text != "")
            {
                String name = tbStudName.Text;
                String idnum = tbIDNum.Text;
                String email = tbStudEmail.Text;
                Int64 contact = Int64.Parse(tbStudContact.Text);
                String program = cbProgram.Text;
                String department = cbDepartment.Text;

                // Check for duplicate email or contact number
                using (SqlConnection connect = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    connect.Open();

                    //checks to see if there any possible duplicates
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Students WHERE Email_Address = @Email OR Contact_No = @Contact", connect);
                    checkCommand.Parameters.AddWithValue("@Email", email);
                    checkCommand.Parameters.AddWithValue("@Contact", contact);

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The email address or contact number already exists. Please use a different one.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Proceed with insertion if no duplicate is found
                        SqlCommand command = new SqlCommand("insert into Students (Student_Name, ID_Number, Email_Address, Contact_No, Program, Department) values (@Name, @IDNum, @Email, @Contact, @Program, @Department)", connect);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@IDNum", idnum);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Program", program);
                        command.Parameters.AddWithValue("@Department", department);

                        command.ExecuteNonQuery();
                        MessageBox.Show("The Student's information has been saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(sender, e);
                    }

                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("Please input the following empty fields or textboxes.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (tbStudContact.TextLength < 10 || tbStudContact.TextLength > 11)
            {
                MessageBox.Show("Please enter a valid contact number.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
