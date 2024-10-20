﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using System.Text.RegularExpressions;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
           
            cbProgram.SelectedIndexChanged += new EventHandler(cbProgram_SelectedIndexChanged);

            UIHelper.SetRoundedCorners(btnExit, 30);
            UIHelper.SetRoundedCorners(btnSave, 20);
            UIHelper.SetRoundedCorners(btnRefresh, 40);
            UIHelper.SetRoundedCorners(panel2, 50);
            UIHelper.SetRoundedCorners(top, 10);

            UIHelper.SetRoundedComboBox(cbProgram, 20);
            UIHelper.SetRoundedComboBox(cbDepartment, 20);

            UIHelper.MakeRoundedTextBox(tbStudName, 10);
            UIHelper.MakeRoundedTextBox(tbIDNum, 10);
            UIHelper.MakeRoundedTextBox(tbStudContact, 10);
            UIHelper.MakeRoundedTextBox(tbStudEmail, 10);

            UIHelper.SetFormStartLocation(this, 330, 127);

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

        //SAVE INFO BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbIDNum.Text != "" && tbStudName.Text != "" && tbStudEmail.Text != ""
                && tbStudContact.Text != "" && cbProgram.Text != "" && cbDepartment.Text != "" && cbProgram.SelectedIndex != -1 &&
                cbDepartment.SelectedIndex != -1 )
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


                    } //Contact number validation
                    else if (tbStudContact.TextLength < 10 || tbStudContact.TextLength > 11)
                    {

                        MessageBox.Show("Please enter a valid contact number.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }//email address validation using Regular expression classes 
                    else if(!Regex.IsMatch(tbStudEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    {
                        MessageBox.Show("Please enter a valid email address.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Proceed with insertion
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

          
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure controls are not null
            if (cbProgram == null || cbDepartment == null) return;

            // Ensure the selected item is not null
            if (cbProgram.SelectedItem == null) return;

            // Automatically select the department based on the selected program
            switch (cbProgram.SelectedItem.ToString())
            {
                case "BSCE":
                case "BSME":
                case "BSIE":
                case "BSEE":
                    cbDepartment.SelectedItem = "College Of Engineering";
                    break;

                case "SHS":
                    cbDepartment.SelectedItem = "Senior High School Branch";
                    break;

                default:
                    cbDepartment.SelectedIndex = -1; // Clear selection if no match is found
                    break;
            }
        }
    }
}
