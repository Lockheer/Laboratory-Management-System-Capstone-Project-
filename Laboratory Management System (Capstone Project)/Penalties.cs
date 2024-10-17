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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class PenaltiesRecords : Form, IUnsavedChangesForm
    {
        private bool _hasUnsavedChanges = false;

        public bool HasUnsavedChanges
        {
            get { return _hasUnsavedChanges; }
        }

        public void ConfirmUnsavedChanges()
        {
            if (_hasUnsavedChanges)
            {
                if (MessageBox.Show("You have unsaved changes. Do you want to save them before proceeding?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Save changes
                    btnUpdate_Click(null, null);
                }
                else if (MessageBox.Show("You have unsaved changes. Are you sure you want to discard them?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Discard changes
                    _hasUnsavedChanges = false;
                }
                else
                {
                    // Cancel navigation
                    return;
                }
            }
        }

        // Call this method when the user makes changes to the form
        private void UpdateUnsavedChanges()
        {
            _hasUnsavedChanges = true;
        }

        // Prevents multiple instances of TransactionDetails and PenaltyEmail forms
        public static int detailRestrict = 0;
        public static int emailFormRestrict = 0;

        private int ID;
        private Int64 rowid;

        public PenaltiesRecords()
        {
            InitializeComponent();

            // Attach event handlers
            tbAmtToBe.TextChanged += tbAmount_TextChanged;
            tbAmtPayed.TextChanged += tbAmount_TextChanged;
            cbTransact.SelectedIndexChanged += cbTransact_SelectedIndexChanged;
        }

        private void PenaltiesRecords_Load(object sender, EventArgs e)
        {
            // Initial setup
            btnUpdate.Hide();
            btnDelete.Hide();
            panelPayment.Visible = false;
            cbCondition.SelectedIndexChanged += cbCondition_SelectedIndexChanged;

            // Load Penalties data and Transaction IDs into ComboBox
            LoadPenaltiesData();
            LoadTransactionIDs();
        }

        private void LoadPenaltiesData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand("select * from LaboratoryPenalties", con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    dgvPenalties.DataSource = DS.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading penalties data: " + ex.Message);
            }
        }

        private void LoadTransactionIDs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand("Select transactionID from BorrowReturnTransaction", con);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbTransact.Items.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transaction IDs: " + ex.Message);
            }
        }

        private void cbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPaymentCondition = cbCondition.SelectedItem != null && (cbCondition.SelectedItem.ToString().Equals("Payment", StringComparison.OrdinalIgnoreCase));

            panelPayment.Visible = isPaymentCondition;
            tbAmtToBe.Visible = isPaymentCondition;
            tbAmtPayed.Visible = isPaymentCondition;
            lblRemainingBalance.Visible = isPaymentCondition;
            UpdateUnsavedChanges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    String idNumber = tbIDnum.Text;
                    String studentName = tbStudentName.Text;
                    if (!Int64.TryParse(tbContact.Text, out Int64 contactNumber))
                    {
                        MessageBox.Show("Error: Invalid contact number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    String emailAddress = tbEmail.Text;

                    // Convert DateTimePicker value to string format "dddd, dd MMMM yyyy" for display
                    String penaltyDate = dtpPenaltyDate.Value.ToString("dddd, dd MMMM yyyy");

                    String violation = tbViolation.Text;
                    String condition = cbCondition.Text;
                    Decimal? toPay = null;
                    Decimal? amtPayed = null;
                    Decimal? balance = null;

                    if (!string.IsNullOrEmpty(tbAmtToBe.Text))
                    {
                        if (Decimal.TryParse(tbAmtToBe.Text, out Decimal parsedToPay))
                        {
                            toPay = parsedToPay;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid amount to be paid format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(tbAmtPayed.Text))
                    {
                        if (Decimal.TryParse(tbAmtPayed.Text, out Decimal parsedAmtPayed))
                        {
                            amtPayed = parsedAmtPayed;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid amount payed format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(lblRemainingBalance.Text))
                    {
                        // Remove any commas or unwanted characters
                        string sanitizedBalanceText = lblRemainingBalance.Text.Replace("...", "");

                        if (Decimal.TryParse(sanitizedBalanceText, out Decimal parsedBalance))
                        {
                            balance = parsedBalance;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid balance format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    String status = cbStatus.Text;
                    if (!int.TryParse(cbTransact.Text, out int transactionID))
                    {
                        MessageBox.Show("Error: Invalid transaction ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Add debugging log to show the values of the inputs
                    MessageBox.Show($"IDNumber: {idNumber}, StudentName: {studentName}, ContactNumber: {contactNumber}, " +
                                    $"EmailAddress: {emailAddress}, PenaltyDate: {penaltyDate}, Violation: {violation}, Condition: {condition}, " +
                                    $"ToPay: {toPay}, AmtPayed: {amtPayed}, Balance: {balance}, Status: {status}, TransactionID: {transactionID}",
                                    "Debugging Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO LaboratoryPenalties ([ID Number],[Student Name],[Contact Number],[Email Address],[Penalty Issued Date],[Violation],[Penalty Condition],[Amount to be Paid],[Amount Received], Balance, [Penalty Status],transactionID) " +
                                                        "VALUES (@IDNumber, @StudentName, @ContactNumber, @EmailAddress, @PenaltyDate, @Violation, @Condition, @ToPay, @AmtPayed, @Balance, @Status, @TransactionID)", con);

                        // Add parameters with AddWithValue
                        cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                        cmd.Parameters.AddWithValue("@StudentName", studentName);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
                        cmd.Parameters.AddWithValue("@PenaltyDate", penaltyDate); // Use the formatted date string
                        cmd.Parameters.AddWithValue("@Violation", violation);
                        cmd.Parameters.AddWithValue("@Condition", condition);

                        // Check if toPay has a value; if not, use DBNull
                        cmd.Parameters.AddWithValue("@ToPay", toPay.HasValue ? (object)toPay.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@AmtPayed", amtPayed.HasValue ? (object)amtPayed.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Balance", balance.HasValue ? (object)balance.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The Student's information has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh Data
                        LoadPenaltiesData();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving student's information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Payment method algorithm
        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbAmtToBe.Text, out decimal toBePayed) && Decimal.TryParse(tbAmtPayed.Text, out decimal payed))
            {
                lblRemainingBalance.Text = (toBePayed - payed).ToString("F2");
            }
            else
            {
                lblRemainingBalance.Text = "0.00";
            }
        }

        // Validate Inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(tbIDnum.Text) || string.IsNullOrEmpty(tbStudentName.Text) || string.IsNullOrEmpty(tbContact.Text) ||
                string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbViolation.Text) || string.IsNullOrEmpty(cbCondition.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbContact.Text.Length < 10 || tbContact.Text.Length > 11)
            {
                MessageBox.Show("Please enter a valid contact number.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!tbEmail.Text.Contains("@") && tbEmail.Text.Contains(".") )
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbCondition.SelectedItem != null && cbCondition.SelectedItem.ToString().Equals("Payment", StringComparison.OrdinalIgnoreCase))
            {
                if (!Decimal.TryParse(tbAmtToBe.Text, out decimal toBePayed) || !Decimal.TryParse(tbAmtPayed.Text, out decimal payed))
                {
                    MessageBox.Show("Please enter valid payment amounts.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (MessageBox.Show("The Penalty and Violation records will now be updated.\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Decimal? toPay = null;
                        Decimal? amtPayed = null;
                        Decimal? balance = null;

                        // Validate and parse amounts
                        if (!string.IsNullOrEmpty(tbAmtToBe.Text) && Decimal.TryParse(tbAmtToBe.Text, out Decimal parsedToPay))
                        {
                            toPay = parsedToPay;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid amount to be paid format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!string.IsNullOrEmpty(tbAmtPayed.Text) && Decimal.TryParse(tbAmtPayed.Text, out Decimal parsedAmtPayed))
                        {
                            amtPayed = parsedAmtPayed;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid amount paid format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validate and parse balance
                        if (!string.IsNullOrEmpty(lblRemainingBalance.Text) && Decimal.TryParse(lblRemainingBalance.Text.Replace("...", ""), out Decimal parsedBalance))
                        {
                            balance = parsedBalance;
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid balance format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE LaboratoryPenalties SET [ID Number] = @IDNumber, [Student Name] = @StudentName, [Contact Number] = @ContactNumber, [Email Address] = @Email, [Penalty Issued Date] = @PenaltyDate, [Violation] = @Violation, [Penalty Condition] = @Condition, [Amount to be Paid] = @ToPay, [Amount Received] = @AmtPayed, Balance = @Balance, [Penalty Status] = @Status, transactionID = @TransactionID WHERE PenaltyID = @RowID", con);

                            // Add parameters with appropriate checks for null values
                            cmd.Parameters.AddWithValue("@IDNumber", tbIDnum.Text);
                            cmd.Parameters.AddWithValue("@StudentName", tbStudentName.Text);
                            cmd.Parameters.AddWithValue("@ContactNumber", Int64.Parse(tbContact.Text)); // Ensure this is validated
                            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                            cmd.Parameters.AddWithValue("@PenaltyDate", dtpPenaltyDate.Value.ToString("dddd, dd MMMM yyyy")); // Consistent date format
                            cmd.Parameters.AddWithValue("@Violation", tbViolation.Text);
                            cmd.Parameters.AddWithValue("@Condition", cbCondition.Text);

                            // Check if toPay has a value; if not, use DBNull
                            cmd.Parameters.AddWithValue("@ToPay", toPay.HasValue ? (object)toPay.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@AmtPayed", amtPayed.HasValue ? (object)amtPayed.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Balance", balance.HasValue ? (object)balance.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Status", cbStatus.Text);
                            cmd.Parameters.AddWithValue("@TransactionID", int.Parse(cbTransact.Text)); // Ensure this is validated
                            cmd.Parameters.AddWithValue("@RowID", rowid);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("The Penalty information has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Refresh Data
                                LoadPenaltiesData();
                            }
                            else
                            {
                                MessageBox.Show("No existing Penalty found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: Invalid number format in contact number or transaction ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating penalty information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The selected information will now be deleted.\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM LaboratoryPenalties WHERE PenaltyID = @RowID", con);
                        cmd.Parameters.AddWithValue("@RowID", rowid);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The Penalty record has been removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh Data
                            LoadPenaltiesData();
                        }
                        else
                        {
                            MessageBox.Show("No penalty record found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting penalty record: " + ex.Message);
                }
            }
        }



        private void dgvPenalties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvPenalties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ID = Convert.ToInt32(dgvPenalties.Rows[e.RowIndex].Cells[0].Value);
                    LoadPenaltyDetails(ID);
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // General exception handler for any other exceptions
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPenaltyDetails(int penaltyID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM LaboratoryPenalties WHERE PenaltyID = @PenaltyID", con);
                    cmd.Parameters.AddWithValue("@PenaltyID", penaltyID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rowid = penaltyID;

                            tbIDnum.Text = reader["ID Number"].ToString();
                            tbStudentName.Text = reader["Student Name"].ToString();
                            tbContact.Text = reader["Contact Number"].ToString();
                            tbEmail.Text = reader["Email Address"].ToString();
                            string penaltyDateStr = reader["Penalty Issued Date"].ToString();
                            dtpPenaltyDate.Value = DateTime.Parse(penaltyDateStr);
                            tbViolation.Text = reader["Violation"].ToString();
                            cbCondition.Text = reader["Penalty Condition"].ToString();

                            // Handle Amount to be Paid
                            if (reader["Amount to be Paid"] != DBNull.Value)
                            {
                                tbAmtToBe.Text = reader["Amount to be Paid"].ToString();
                            }
                            else
                            {
                                tbAmtToBe.Text = "0.00";
                            }

                            // Handle Amount Received
                            if (reader["Amount Received"] != DBNull.Value)
                            {
                                tbAmtPayed.Text = reader["Amount Received"].ToString();
                            }
                            else
                            {
                                tbAmtPayed.Text = "0.00";
                            }

                            // Handle Balance
                            if (reader["Balance"] != DBNull.Value)
                            {
                                lblRemainingBalance.Text = reader["Balance"].ToString();
                            }
                            else
                            {
                                lblRemainingBalance.Text = "0.00";
                            }

                            cbStatus.Text = reader["Penalty Status"].ToString();
                            cbTransact.Text = reader["transactionID"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No penalty found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Transaction Details button
        private void button1_Click(object sender, EventArgs e)
        {
            if (detailRestrict == 0)
            {
                detailRestrict++;
                TransactionDetails details = new TransactionDetails();
                details.HideControls(); // Call the HideControls method from the TransactionDetails form
                details.FormClosed += (s, args) => { detailRestrict = 0; }; // Reset the restriction when the form is closed
                details.Show();
            }
            else
            {
                MessageBox.Show("The summary form has already been opened.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Opens the SMTP Email sending form
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (emailFormRestrict == 0)
            {
                emailFormRestrict++;
                PenaltyEmail penaltyEmail = new PenaltyEmail();
                penaltyEmail.FormClosed += (s, args) => { emailFormRestrict = 0; };
                penaltyEmail.Show();
            }
            else
            {
                MessageBox.Show("The instance has already been opened.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

  

        //Automation of the following textboxes (Student name, contact number, email address and ID number)
        private void cbTransact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTransact.SelectedItem != null)
                {
                   
                    if (int.TryParse(cbTransact.SelectedItem.ToString(), out int selectedTransactionID))
                    {
                        LoadTransactionDetails(selectedTransactionID);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Transaction ID selected. Please choose a valid transaction.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting the transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateUnsavedChanges();
        }

        //Automation method
        private void LoadTransactionDetails(int transactionID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID_Number, Student_Name, Email_Address, Contact_Number FROM BorrowReturnTransaction WHERE transactionID = @TransactionID", con);
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tbIDnum.Text = reader["ID_Number"].ToString();
                            tbStudentName.Text = reader["Student_Name"].ToString();
                            tbEmail.Text = reader["Email_Address"].ToString();
                            tbContact.Text = reader["Contact_Number"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No matching record found for the selected Transaction ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transaction details: " + ex.Message);
            }
        }

        private const string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

        // Search bar for penalties
        private void tbSearchPenalty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearchPenalty.Text))
            {
                SearchPenalties(tbSearchPenalty.Text);
            }
            else
            {
                LoadAllPenalties();
            }

        }



        private void SearchPenalties(string searchText)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM LaboratoryPenalties WHERE [ID Number] LIKE @SearchText + '%' OR [Student Name] LIKE @SearchText + '%' OR [Penalty Issued Date] LIKE @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", searchText);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                try
                {
                    con.Open();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        dgvPenalties.DataSource = DS.Tables[0];
                    }
                    else
                    {
                        dgvPenalties.DataSource = null;
                        MessageBox.Show("No records found matching your search criteria.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAllPenalties()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM LaboratoryPenalties";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                try
                {
                    con.Open();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        dgvPenalties.DataSource = DS.Tables[0];
                    }
                    else
                    {
                        dgvPenalties.DataSource = null;
                        MessageBox.Show("No penalty records found.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbIDnum_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbStudentName_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbViolation_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

     
        private void tbAmtToBe_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbAmtPayed_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

     
    }
}




