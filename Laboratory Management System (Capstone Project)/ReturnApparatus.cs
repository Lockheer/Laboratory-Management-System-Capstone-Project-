﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class ReturnApparatus : Form
    {
        public ReturnApparatus()
        {
            InitializeComponent();
            dtpReturnDate.MinDate = DateTime.Today;
            tbSearchID.KeyPress += new KeyPressEventHandler(tbSearchID_KeyPress);

        }


        //Loading of ID numbers
        private void LoadIDNumbers()
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();
                // Modified SQL query to get ID numbers of students who have conducted borrow transactions
                SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT ID_Number " +
                    "FROM BorrowReturnTransaction " +
                    "WHERE ID_Number IS NOT NULL", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    autoCompleteCollection.Add(reader["ID_Number"].ToString());
                }
                reader.Close();
            }

            // Configure AutoComplete properties
            tbSearchID.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbSearchID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbSearchID.AutoCompleteCustomSource = autoCompleteCollection;
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
                using (SqlCommand cmd = new SqlCommand("SELECT transactionID, Student_Name, ID_Number, Email_Address, Contact_Number,   Apparatus_Name,Quantity, Borrow_Date, Due_Date, Date_Returned, Remarks FROM BorrowReturnTransaction WHERE Date_Returned IS NULL AND Quantity_Returned IS NULL AND Remarks IS NULL ", con))
                {
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    dgvReturnInformation.DataSource = DS.Tables[0];
                }
            }

            LoadIDNumbers();
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
                    appa_name = dgvReturnInformation.Rows[e.RowIndex].Cells[5].Value.ToString();
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

        //Issue Return Button
        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the return date is valid
                DateTime returnDate = dtpReturnDate.Value;
                DateTime borrowDate = DateTime.Parse(date_borrowed);
                DateTime dueDate = DateTime.Parse(due_date);

                if (returnDate < borrowDate)
                {
                    MessageBox.Show("The return date cannot be earlier than the borrow date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (returnDate > dueDate)
                {
                    tbRemarks.Text = "This is a late return and is subjected as a violation. \nContext: Late Item Return\nPenalty: Student cannot borrow any apparatuses for 1 week.";
                }



                // Check if the return date is valid
                if (dtpReturnDate.Value < DateTime.Today)
                {
                    MessageBox.Show("The return date cannot be earlier than today.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the quantity returned is valid
                int returnedQuantity = (int)numQuantityReturned.Value;
                int borrowedQuantity = 0; // Initialize quantity borrowed

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT Quantity FROM BorrowReturnTransaction WHERE transactionID = @TransactionID", con))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", rowid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                borrowedQuantity = Convert.ToInt32(reader["Quantity"]);
                            }
                            else
                            {
                                MessageBox.Show("Error retrieving apparatus information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (returnedQuantity < 1 || returnedQuantity > borrowedQuantity)
                    {
                        MessageBox.Show("Invalid quantity returned. Please enter a value between 1 and " + borrowedQuantity.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Check if the remarks field is empty
                if (string.IsNullOrWhiteSpace(tbRemarks.Text))
                {
                    if (MessageBox.Show("Are you sure you don't need to place the Transaction remarks?\n" + "The system will automate a generic report comment instead.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Proceed with the insertion without remarks
                        tbRemarks.Text = "No remarks provided";
                        tbRemarks.Text += "\nReturned Quantity: " + returnedQuantity.ToString();
                    }
                    else
                    {
                        // Cancel the insertion and focus on the tbRemarks field
                        tbRemarks.Focus();
                        return;
                    }
                }

                string returnDateStr = dtpReturnDate.Text;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    con.Open();

                    // Retrieve the apparatus name and other date values
                    string apparatusName;
                    string borrowedDateStr;
                    string dueDateStr;
                    string dateReturnedStr = returnDateStr; // Initialize with return date
                    int quantityBorrowed = 0; // Initialize quantity borrowed


                    using (SqlCommand cmd = new SqlCommand("SELECT Apparatus_Name, Borrow_Date, Due_Date, Quantity FROM BorrowReturnTransaction WHERE transactionID = @TransactionID", con))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", rowid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                apparatusName = reader["Apparatus_Name"].ToString();
                                borrowedDateStr = reader["Borrow_Date"].ToString();
                                dueDateStr = reader["Due_Date"].ToString();
                                quantityBorrowed = Convert.ToInt32(reader["Quantity"]);
                            }
                            else
                            {
                                MessageBox.Show("Error retrieving apparatus information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                 

                    // Get the quantity returned from the NumericUpDown control
                    int quantityReturned = (int)numQuantityReturned.Value;

                    // Validate quantity returned
                    if (quantityReturned < 1 || quantityReturned > quantityBorrowed)
                    {
                        MessageBox.Show("Invalid quantity returned. Please enter a value between 1 and " + quantityBorrowed.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(tbRemarks.Text) || tbRemarks.Text == "")
                    {
                        if (MessageBox.Show("Are you sure you don't need to place the Transaction remarks?\n" + "The system will automate a generic report comment instead.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // Proceed with the insertion without remarks
                            tbRemarks.Text = "No remarks provided";
                            tbRemarks.Text += "\nReturned Quantity: " + quantityReturned.ToString();
                        }
                        else
                        {
                            // Cancel the insertion and focus on the tbRemarks field
                            tbRemarks.Focus();
                            return;
                        }
                    }



                    // Check if the student has already returned the apparatus
                    using (SqlCommand cmdCheckReturn = new SqlCommand("SELECT * FROM BorrowReturnTransaction WHERE transactionID = @TransactionID AND Date_Returned IS NOT NULL", con))
                    {
                        cmdCheckReturn.Parameters.AddWithValue("@TransactionID", rowid);
                        using (SqlDataReader reader = cmdCheckReturn.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("The apparatus has already been returned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Update BorrowReturnTransaction with return date, remarks, and quantity returned
                    using (SqlCommand cmd = new SqlCommand("UPDATE BorrowReturnTransaction SET Date_Returned = @ReturnDate, Remarks = @Remarks, Quantity_Returned = @QuantityReturned, AccountID = @AccountID WHERE transactionID = @TransactionID", con))
                    {
                        // Pass the correct parameters to the command
                        cmd.Parameters.AddWithValue("@ReturnDate", dtpReturnDate.Value);
                        cmd.Parameters.AddWithValue("@Remarks", tbRemarks.Text);
                        cmd.Parameters.AddWithValue("@TransactionID", rowid);
                        cmd.Parameters.AddWithValue("@QuantityReturned", numQuantityReturned.Value);
                        cmd.Parameters.AddWithValue("@AccountID", Form1.Session.AccountID);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    // Update the quantity stock in the ApparatusList table
                    using (SqlCommand cmd = new SqlCommand("UPDATE Inventory SET Quantity = Quantity + @QuantityReturned WHERE [Apparatus Name] = @ApparatusName", con))
                    {
                        cmd.Parameters.AddWithValue("@ApparatusName", apparatusName);
                        cmd.Parameters.AddWithValue("@QuantityReturned", quantityReturned);
                        cmd.ExecuteNonQuery();
                    }

                    // Update remarks to include information about the returned quantity
                    //tbRemarks.Text += "\nReturned Quantity: " + quantityReturned.ToString();

                    MessageBox.Show("The transaction has been completed.\nThank you for returning the Apparatus!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnApparatus_Load(this, null);
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the return transaction.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool showErrorMessage = false;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            showErrorMessage = true; // Set flag to show error message
            SearchAndDisplayResults(tbSearchID.Text);
        }

        private void tbSearchID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchID.Text))
            {
                panel2.Visible = false;
                dgvReturnInformation.DataSource = null; // Clear the DataGridView if the text is empty
                showErrorMessage = false; // Reset flag when clearing search
            }
            else
            {
                showErrorMessage = false; // Reset flag when typing
                SearchAndDisplayResults(tbSearchID.Text);
            }
        }

        private void SearchAndDisplayResults(string idNumber)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM BorrowReturnTransaction WHERE ID_Number = @IDNumber AND Date_Returned IS NULL AND Remarks IS NULL AND Quantity_Returned IS NULL AND AccountID = @AccountID", con))
                {
                    cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                    cmd.Parameters.AddWithValue("@AccountID", Form1.Session.AccountID);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count != 0)
                    {
                        dgvReturnInformation.DataSource = DS.Tables[0];
                        panel2.Visible = true; // Show panel2 if results are found
                    }
                    else
                    {
                        dgvReturnInformation.DataSource = null; // Clear DataGridView if no results
                        panel2.Visible = false; // Hide panel2 if no results

                        if (showErrorMessage)
                        {
                            MessageBox.Show("ID Number is invalid OR there are no apparatus that has been issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbSearchID.Clear();
            panel2.Visible = false;
            ReturnApparatus_Load(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }



        private void btnExitUpper_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go back to the Dashboard?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Dashboard db = new Dashboard();
                db.Show();
            }
        }

        private void tbSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e); // Trigger the search button click event
                e.Handled = true; // Prevents the beep sound on Enter key press
            }

        }


        private void ResetFields()
        {
            tbSearchID.Clear();
            tbApparatusName.Clear();
            tbBorrowedDate.Clear();
            tbDue.Clear();
            dtpReturnDate.Value = DateTime.Today;
            numQuantityReturned.Value = 1;
            tbRemarks.Clear();
        }

    
    }
}
