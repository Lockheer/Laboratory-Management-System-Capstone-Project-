using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class UpdateBorrowReturnTransaction : Form
    {
        //Using the BorrowReturnTransaction table
        public UpdateBorrowReturnTransaction()
        {
            InitializeComponent();
        }


        Int64 rowid;
        int id;

        private void UpdateBorrowReturnTransaction_Load(object sender, EventArgs e)
        {
            // SQL Connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from BorrowReturnTransaction";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvTransaction.DataSource = ds.Tables[0];
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get selected row from DataGridView
            if (dgvTransaction.SelectedRows.Count > 0)
            {
                // Get selected row's transactionID
                int transactionID = Convert.ToInt32(dgvTransaction.SelectedRows[0].Cells["transactionID"].Value);

                // Get updated values from input fields
                string studentName = tbStudentName.Text;
                string idNumber = tbIDNum.Text;
                string emailAddress = tbEmailAdd.Text;
                string contactNumber = tbContact.Text;
                string program = cbProgram.Text;
                string apparatusName = tbAppaName.Text;
                string borrowDate = dtpBorrowedDate.Text;
                string dueDate = dtpDueDate.Text;
                string dateReturned = dtpDateReturned.Text;
                string remarks = tbRemarks.Text;

                int studentID;
                int apparatusID;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    con.Open();

                    // Get StudentID based on Student Name
                    SqlCommand cmdGetStudentID = new SqlCommand("SELECT studID FROM Students WHERE [Student_Name] = @Student_Name", con);
                    cmdGetStudentID.Parameters.AddWithValue("@Student_Name", studentName);
                    object resultStudent = cmdGetStudentID.ExecuteScalar();
                    if (resultStudent != null)
                    {
                        studentID = Convert.ToInt32(resultStudent);
                    }
                    else
                    {
                        MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get ApparatusID based on Apparatus Name
                    SqlCommand cmdGetApparatusID = new SqlCommand("SELECT ApparatusID FROM ApparatusList WHERE [Apparatus Name] = @Apparatus_Name", con);
                    cmdGetApparatusID.Parameters.AddWithValue("@Apparatus_Name", apparatusName);
                    object resultApparatus = cmdGetApparatusID.ExecuteScalar();
                    if (resultApparatus != null)
                    {
                        apparatusID = Convert.ToInt32(resultApparatus);
                    }
                    else
                    {
                        MessageBox.Show("Apparatus not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update BorrowReturnTransaction record
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE BorrowReturnTransaction SET [Student_Name] = @Student_Name, [ID_Number] = @ID_Number, [Email_Address] = @Email_Address, [Contact_Number] = @Contact_Number, [Program] = @Program, [Apparatus_Name] = @Apparatus_Name, [Borrow_Date] = @Borrow_Date, [Due_Date] = @Due_Date, [Date_Returned] = @Date_Returned, [Remarks] = @Remarks, [studID] = @StudentID, [ApparatusID] = @ApparatusID WHERE transactionID = @TransactionID", con);
                    cmdUpdate.Parameters.AddWithValue("@Student_Name", studentName);
                    cmdUpdate.Parameters.AddWithValue("@ID_Number", idNumber);
                    cmdUpdate.Parameters.AddWithValue("@Email_Address", emailAddress);
                    cmdUpdate.Parameters.AddWithValue("@Contact_Number", contactNumber);
                    cmdUpdate.Parameters.AddWithValue("@Program", program);
                    cmdUpdate.Parameters.AddWithValue("@Apparatus_Name", apparatusName);
                    cmdUpdate.Parameters.AddWithValue("@Borrow_Date", borrowDate);
                    cmdUpdate.Parameters.AddWithValue("@Due_Date", dueDate);
                    cmdUpdate.Parameters.AddWithValue("@Date_Returned", dateReturned);
                    cmdUpdate.Parameters.AddWithValue("@Remarks", remarks);
                    cmdUpdate.Parameters.AddWithValue("@StudentID", studentID);
                    cmdUpdate.Parameters.AddWithValue("@ApparatusID", apparatusID);
                    cmdUpdate.Parameters.AddWithValue("@TransactionID", transactionID);

                    cmdUpdate.ExecuteNonQuery();
                }

                MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh DataGridView or reload data
            }
            else
            {
                MessageBox.Show("Please select a record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            UpdateBorrowReturnTransaction_Load(sender, e);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("The Data will be deleted\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // SQL Connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from BorrowReturnTransaction where transactionID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

              
                UpdateBorrowReturnTransaction_Load(this, null);
            }


        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (tbSearch.Text != "")
            {
                cmd.CommandText = "select * from BorrowReturnTransaction where [Student_Name] LIKE @SearchText + '%' OR [ID_Number] LIKE @SearchText + '%' " +
                                  "OR [Email_Address] LIKE @SearchText + '%' OR [Contact_Number] LIKE @SearchText + '%' OR [Program] LIKE @SearchText + '%' " +
                                  "OR [Apparatus_Name] LIKE @SearchText + '%' OR [Borrow_Date] LIKE @SearchText + '%' OR [Due_Date] LIKE @SearchText + '%' " +
                                  "OR [Date_Returned] LIKE @SearchText + '%' OR [Remarks] LIKE @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", tbSearch.Text);
            }
            else
            {
                cmd.CommandText = "select * from BorrowReturnTransaction";
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvTransaction.DataSource = ds.Tables[0];
            }
            else
            {
                dgvTransaction.DataSource = null; // Clear the DataGridView
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
