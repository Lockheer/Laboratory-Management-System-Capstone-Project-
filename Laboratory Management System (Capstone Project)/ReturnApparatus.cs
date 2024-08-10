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
    public partial class ReturnApparatus : Form
    {
        public ReturnApparatus()
        {
            InitializeComponent();
            dtpReturnDate.MinDate = DateTime.Today;
        }

        private string appa_name;
        private string date_borrowed;
        private string due_date;
        private long rowid;

        private void ReturnApparatus_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            tbSearchID.Clear();

            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT transactionID, Student_Name, ID_Number, Email_Address, Contact_Number, Program, Apparatus_Name, Borrow_Date, Due_Date, Date_Returned, Remarks FROM BorrowReturnTransaction", con))
                {
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dgvReturnInformation.DataSource = DS.Tables[0];
                }
            }
        }

        private void dgvReturnInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var selectedCell = dgvReturnInformation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (selectedCell != null && !string.IsNullOrWhiteSpace(selectedCell.ToString()))
                {
                    panel2.Visible = true;
                    rowid = Convert.ToInt64(dgvReturnInformation.Rows[e.RowIndex].Cells[0].Value);
                    appa_name = dgvReturnInformation.Rows[e.RowIndex].Cells[6].Value.ToString();
                    date_borrowed = dgvReturnInformation.Rows[e.RowIndex].Cells[7].Value.ToString();
                    due_date = dgvReturnInformation.Rows[e.RowIndex].Cells[8].Value.ToString();

                    tbApparatusName.Text = appa_name;
                    tbBorrowedDate.Text = date_borrowed;
                    tbDue.Text = due_date;
                }
                else
                {
                    panel2.Visible = false;
                    MessageBox.Show("The selected cell is empty or invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BorrowReturnTransaction WHERE ID_Number = @IDNumber AND Date_Returned IS NULL", con))
                {
                    cmd.Parameters.AddWithValue("@IDNumber", tbSearchID.Text);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count != 0)
                    {
                        dgvReturnInformation.DataSource = DS.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("ID Number is invalid OR there are no apparatus that has been issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            if (dtpReturnDate.Value < DateTime.Today)
            {
                MessageBox.Show("The return date cannot be earlier than today.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string returnDateStr = dtpReturnDate.Value.ToString("yyyy-MM-dd"); // Format as string for comparison

            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();

                // Retrieve the apparatus name and other date values
                string apparatusName;
                string borrowedDateStr;
                string dueDateStr;
                string dateReturnedStr = returnDateStr; // Initialize with return date

                using (SqlCommand cmd = new SqlCommand("SELECT Apparatus_Name, Borrow_Date, Due_Date FROM BorrowReturnTransaction WHERE transactionID = @TransactionID", con))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", rowid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            apparatusName = reader["Apparatus_Name"].ToString();
                            borrowedDateStr = reader["Borrow_Date"].ToString();
                            dueDateStr = reader["Due_Date"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving apparatus information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Check if the return date is later than the due date
                DateTime dueDate;
                if (DateTime.TryParse(dueDateStr, out dueDate))
                {
                    DateTime returnDate;
                    if (DateTime.TryParse(returnDateStr, out returnDate) && returnDate > dueDate)
                    {
                        tbRemarks.Text = "This is a late return and is subjected as a violation. \nContext: Late Item Return\nPenalty: Student cannot borrow any apparatuses for 3 days or" +
                            "\nSubject for payment penalty ranging from 150 - 500 pesos.";
                    }
                }
                else
                {
                    tbRemarks.Text = "Due date format is invalid.";
                }

                // Update the BorrowReturnTransaction with return date and remarks
                using (SqlCommand cmd = new SqlCommand("UPDATE BorrowReturnTransaction SET Date_Returned = @ReturnDate, Remarks = @Remarks WHERE ID_Number = @IDNumber AND transactionID = @TransactionID", con))
                {
                    cmd.Parameters.AddWithValue("@ReturnDate", returnDateStr);
                    cmd.Parameters.AddWithValue("@Remarks", tbRemarks.Text);
                    cmd.Parameters.AddWithValue("@IDNumber", tbSearchID.Text);
                    cmd.Parameters.AddWithValue("@TransactionID", rowid);
                    cmd.ExecuteNonQuery();
                }

                // Update the quantity stock in the ApparatusList table
                using (SqlCommand cmd = new SqlCommand("UPDATE ApparatusList SET Quantity = Quantity + 1 WHERE [Apparatus Name] = @ApparatusName", con))
                {
                    cmd.Parameters.AddWithValue("@ApparatusName", apparatusName);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("The transaction has been completed.\nThank you for returning the Apparatus!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnApparatus_Load(this, null);
        }


        private void tbSearchID_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchID.Text != "")
            {
                panel2.Visible = false;
                dgvReturnInformation.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbSearchID.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void tbSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnExitUpper_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go back to the Dashboard?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                // Sets back to 0 to prevent restriction from occurring
                Dashboard.formRestrict = 0;
            }
        }

    }
}
