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
                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO LaboratoryPenalties ([ID Number],[Student Name],[Contact Number],[Email Address],[Penalty Issued Date],[Violation],[Penalty Condition],[Amount to be Paid],[Amount Received], [Balance], [Penalty Status],transactionID) " +
                                                        "VALUES (@IDNumber, @StudentName, @ContactNumber, @Email, @PenaltyDate, @Violation, @Condition, @ToBePayed, @Payed, @Balance, @Status, @RefNum)", con);

                        // Add parameters with explicit types
                        cmd.Parameters.Add("@IDNumber", SqlDbType.NVarChar).Value = tbIDnum.Text;
                        cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = tbStudentName.Text;
                        cmd.Parameters.Add("@ContactNumber", SqlDbType.BigInt).Value = Int64.Parse(tbContact.Text); // Handle potential parse errors
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = tbEmail.Text;
                        cmd.Parameters.Add("@PenaltyDate", SqlDbType.Date).Value = dtpPenaltyDate.Value; // Use DateTimePicker.Value instead of .Text
                        cmd.Parameters.Add("@Violation", SqlDbType.NVarChar).Value = tbViolation.Text;
                        cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = cbCondition.Text;
                        cmd.Parameters.Add("@ToBePayed", SqlDbType.Decimal).Value = Decimal.Parse(tbAmtToBe.Text);
                        cmd.Parameters.Add("@Payed", SqlDbType.Decimal).Value = Decimal.Parse(tbAmtPayed.Text);
                        cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Decimal.Parse(lblRemainingBalance.Text);
                        cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cbStatus.Text;
                        cmd.Parameters.Add("@RefNum", SqlDbType.BigInt).Value = Int64.Parse(cbTransact.Text); // Handle potential parse errors

                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The Student's information has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh Data
                        LoadPenaltiesData();
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
                    MessageBox.Show("Error saving student's information: " + ex.Message);
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

            if (tbContact.Text.Length < 10 || tbContact.Text.Length > 11 || !Int64.TryParse(tbContact.Text, out _))
            {
                MessageBox.Show("Please enter a valid contact number.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!IsValidEmail(tbEmail.Text))
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

        // Validate email with regex pattern
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (MessageBox.Show("The Penalty and Violation records will now be updated.\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE LaboratoryPenalties SET [ID Number] = @IDNumber, [Student Name] = @StudentName, [Contact Number] = @ContactNumber, [Email Address] = @Email, [Penalty Issued Date] = @PenaltyDate, [Violation] = @Violation, [Penalty Condition] = @Condition, [Amount to be Paid] = @ToBePayed, [Amount Received] = @Payed, [Balance] = @Balance, [Penalty Status] = @Status, transactionID = @RefNum WHERE PenaltyID = @RowID", con);

                            // Add parameters
                            cmd.Parameters.AddWithValue("@IDNumber", tbIDnum.Text);
                            cmd.Parameters.AddWithValue("@StudentName", tbStudentName.Text);
                            cmd.Parameters.AddWithValue("@ContactNumber", Int64.Parse(tbContact.Text));
                            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                            cmd.Parameters.AddWithValue("@PenaltyDate", dtpPenaltyDate.Text);
                            cmd.Parameters.AddWithValue("@Violation", tbViolation.Text);
                            cmd.Parameters.AddWithValue("@Condition", cbCondition.Text);
                            cmd.Parameters.AddWithValue("@ToBePayed", Decimal.Parse(tbAmtToBe.Text));
                            cmd.Parameters.AddWithValue("@Payed", Decimal.Parse(tbAmtPayed.Text));
                            cmd.Parameters.AddWithValue("@Balance", Decimal.Parse(lblRemainingBalance.Text));
                            cmd.Parameters.AddWithValue("@Status", cbStatus.Text);
                            cmd.Parameters.AddWithValue("@RefNum", Int64.Parse(cbTransact.Text));
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating penalty information: " + ex.Message);
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
                }
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
                            dtpPenaltyDate.Text = reader["Penalty Issued Date"].ToString();
                            tbViolation.Text = reader["Violation"].ToString();
                            cbCondition.Text = reader["Penalty Condition"].ToString();
                            tbAmtToBe.Text = reader["Amount to be Paid"].ToString();
                            tbAmtPayed.Text = reader["Amount Received"].ToString();
                            lblRemainingBalance.Text = reader["Balance"].ToString();
                            cbStatus.Text = reader["Penalty Status"].ToString();
                            cbTransact.Text = reader["transactionID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading penalty details: " + ex.Message);
            }
        }

        //RETURN Button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            //Dashboard.formRestrict = 0;
        }

        //Transaction Details button
        private void button1_Click(object sender, EventArgs e)
        {

            if (detailRestrict == 0)
            {
                detailRestrict++;
                TransactionDetails details = new TransactionDetails();
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





/*using System;
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

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class PenaltiesRecords : Form
    {
       
        public PenaltiesRecords()
        {
            InitializeComponent();

            tbAmtToBe.TextChanged += tbAmount_TextChanged;
            tbAmtPayed.TextChanged += tbAmount_TextChanged;

        }
        //prevents the transaction detail form from appearing multiple times to save memory
        public static int detailRestrict = 0;
        public static int emailFormRestrict = 0;


        int ID;
        Int64 rowid;

        private void PenaltiesRecords_Load(object sender, EventArgs e)
        {
            btnUpdate.Hide();
            panelPayment.Visible = false;
            cbCondition.SelectedIndexChanged += new EventHandler(cbCondition_SelectedIndexChanged);


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from LaboratoryPenalties";
            SqlDataAdapter DA = new SqlDataAdapter();
            DataSet DS = new DataSet();
            DA.SelectCommand = cmd; // Set the SelectCommand for the SqlDataAdapter
            DA.Fill(DS);

            dgvPenalties.DataSource = DS.Tables[0];
            // Load the COMBO BOX with the transaction ID data source
            using (SqlConnection combo_con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                using (SqlCommand new_cmd = new SqlCommand("Select transactionID from BorrowReturnTransaction", combo_con))
                {
                    try
                    {
                        combo_con.Open();
                        using (SqlDataReader reader = new_cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Read the integer transaction ID and add it to the ComboBox
                                cbTransact.Items.Add(reader.GetInt32(0));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it or show a message to the user)
                        MessageBox.Show("An error occurred while loading transaction IDs: " + ex.Message);
                    }
                }
            }




        }




        private void cbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCondition.SelectedItem != null && cbCondition.SelectedItem.ToString() == "Payment" || cbCondition.SelectedIndex.ToString() == "PAYMENT")
            {
                panelPayment.Visible = true;
                tbAmtToBe.Visible = true;
                tbAmtPayed.Visible = true;
                lblRemainingBalance.Visible = true;

            }
            else
            {
                panelPayment.Visible = false;
                tbAmtToBe.Visible = false;
                tbAmtPayed.Visible = false;
                lblRemainingBalance.Visible = false;
            }

        }


        //RETURN Button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            //Dashboard.formRestrict = 0;
        }

        //Transaction Details button
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (detailRestrict == 0)
            {
                detailRestrict++;
                TransactionDetails details = new TransactionDetails();
                details.Show();
            }else
            {
                MessageBox.Show("The details form has already been opened.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Opens the SMTP Email sending form
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (emailFormRestrict == 0)
            {
                emailFormRestrict++;
                PenaltyEmail penaltyEmail = new PenaltyEmail();
                penaltyEmail.Show();
            }else
            {
                MessageBox.Show("The instance has already been opened.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Rework and match LabPenalties table
            if (tbIDnum.Text != "" && tbStudentName.Text != "" && tbEmail.Text != ""
              && tbContact.Text != "" && tbViolation.Text != "" && cbCondition.Text != "" && cbTransact.Text != "" && cbStatus.Text != "")
            {

               
                String idnum = tbIDnum.Text;
                String name = tbStudentName.Text;
                String email = tbEmail.Text;
                Int64 contact = Int64.Parse(tbContact.Text);
                String violation = tbViolation.Text;
                String condition = cbCondition.Text;
                Int64 transactRef = Int64.Parse(cbTransact.Text);
                String status = cbStatus.Text;
                String issueDate = dtpPenaltyDate.Text;
                Decimal ToPay = Decimal.Parse(tbAmtToBe.Text);
                Decimal Payed = Decimal.Parse(tbAmtPayed.Text);
                Decimal Balance = Decimal.Parse(lblRemainingBalance.Text);

                SqlConnection connect = new SqlConnection();
                connect.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand command = new SqlCommand();
                command.Connection = connect;

                connect.Open();
                command.CommandText = "Insert into LaboratoryPenalties ([ID Number],[Student Name],[Contact Number],[Email Address],[Penalty Issued Date],[Violation],[Penalty Condition],[Amount to be Paid],[Amount Received], [Balance], [Penalty Status],transactionID) values ('" + idnum + "','" + name + "', " + contact + ",'" + email + "',  '" + issueDate + "', '" + violation + "', '"+condition+"', "+ToPay+", "+Payed+ ", "+Balance+", '" + status+"', "+transactRef+")";
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("The Student's information has been saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {

                MessageBox.Show("Please fill in the following empty fields or textboxes.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            if (tbContact.TextLength < 10 || tbContact.TextLength > 11)
            {
                MessageBox.Show("Please enter a valid contact number.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String idnum = tbIDnum.Text;
            String name = tbStudentName.Text;
            String email = tbEmail.Text;
            Int64 contact;
            if (!Int64.TryParse(tbContact.Text, out contact))
            {
                MessageBox.Show("Invalid contact number.");
                return;
            }
            String violation = tbViolation.Text;
            String condition = cbCondition.Text;
            Int64 transactRef = Int64.Parse(cbTransact.Text);
            String status = cbStatus.Text;
            String issueDate = dtpPenaltyDate.Text;
            Decimal ToPay = Decimal.Parse(tbAmtToBe.Text);
            Decimal Payed = Decimal.Parse(tbAmtPayed.Text);
            Decimal Balance = Decimal.Parse(lblRemainingBalance.Text);

            if (MessageBox.Show("Student's Information will now be updated.\n" +
              "\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "UPDATE LaboratoryPenalties SET [ID Number] = @IDNumber,[Student Name] = @StudentName ,[Contact Number] = @ContactNumber, [Email Address] = @EmailAddress ,[Penalty Issued Date] = @PenaltyDate ,[Violation] = @Violation ,[Penalty Condition] = @Condition ," +
                        "[Amount to be Paid] = @ToBePayed, [Amount Received] = @Payed , [Balance] = @Balance, [Penalty Status] =@Status,transactionID = @RefNum WHERE PenaltyID = @RowID";

                    cmd.Parameters.AddWithValue("@IDNumber", idnum);
                    cmd.Parameters.AddWithValue("@StudentName", name);
                    cmd.Parameters.AddWithValue("@ContactNumber", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PenaltyDate", issueDate);
                    cmd.Parameters.AddWithValue("@Violation", violation);
                    cmd.Parameters.AddWithValue("@Condition", condition);
                    cmd.Parameters.AddWithValue("@ToBePayed", ToPay);
                    cmd.Parameters.AddWithValue("@Payed", Payed);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@RefNum", transactRef);
                    cmd.Parameters.AddWithValue("@RowID", rowid);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The Penalty information has been updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No existing Penalty found with the specified ID.");
                        }

                        // Refresh the data grid view with the updated data
                        PenaltiesRecords_Load(this, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The selected student's information will now be deleted.\n" +
                "\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "DELETE FROM LaboratoryPenalties WHERE PenaltyID = @RowID";
                    cmd.Parameters.AddWithValue("@RowID", rowid);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The Penalty record has now been removed.","Success",MessageBoxButtons.OK,MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("No penalty record found with the specified ID.");
                        }

                        // Refresh the data grid view with the updated data
                        PenaltiesRecords_Load(this, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }


        //dgv Click Event 
        private void dgvPenalties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell and row are within the valid range
            if (e.RowIndex >= 0)
            {
                // Check if the cell value is not null or empty
                if (dgvPenalties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    !string.IsNullOrWhiteSpace(dgvPenalties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // Acquire the data that will match the Primary Key of the table
                    ID = int.Parse(dgvPenalties.Rows[e.RowIndex].Cells[0].Value.ToString());

                    btnUpdate.Visible = true;

                    // Define the connection string
                    string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE studID = @ID", con);
                        cmd.Parameters.AddWithValue("@ID", ID);

                        // Set up the data adapter with the command
                        SqlDataAdapter DA = new SqlDataAdapter(cmd);

                        // To hold the data
                        DataSet DS = new DataSet();

                        try
                        {
                            con.Open();
                            // Fill the DataSet with data from the database
                            DA.Fill(DS);

                            // Check if the query returned any results
                            if (DS.Tables[0].Rows.Count > 0)
                            {
                                // Extract data from the first row
                                rowid = Int64.Parse(DS.Tables[0].Rows[0]["PenaltyID"].ToString());
                                tbIDnum.Text = DS.Tables[0].Rows[0]["[ID Number]"].ToString();
                                tbStudentName.Text = DS.Tables[0].Rows[0]["[Student Name]"].ToString();
                                tbContact.Text = DS.Tables[0].Rows[0]["[Contact Number]"].ToString();
                                tbEmail.Text = DS.Tables[0].Rows[0]["[Email Address]"].ToString();
                                dtpPenaltyDate.Text = DS.Tables[0].Rows[0]["[Penalty Issued Date]"].ToString();
                                tbViolation.Text = DS.Tables[0].Rows[0]["[Violation]"].ToString();
                                cbCondition.Text = DS.Tables[0].Rows[0]["[Penalty Condition]"].ToString();
                                tbAmtToBe.Text = DS.Tables[0].Rows[0]["[Amount to be Paid]"].ToString();
                                tbAmtPayed.Text = DS.Tables[0].Rows[0]["[Amount Received]"].ToString();
                                lblRemainingBalance.Text = DS.Tables[0].Rows[0]["[Balance]"].ToString();
                                cbStatus.Text = DS.Tables[0].Rows[0]["[Penalty Status]"].ToString();
                                cbTransact.Text = DS.Tables[0].Rows[0]["transactionID"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    // Display an error message if the cell is empty or null
                    MessageBox.Show("The selected cell is empty. Please select a valid cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        //Penalty search bar box
        private void tbSearchPenalty_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchPenalty.Text != "")
            {
                // Perform the search
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM LaboratoryPenalties WHERE [ID Number] LIKE @SearchText + '%' OR [Student Name] LIKE @SearchText + '%' OR [Penalty Issued Date] LIKE @SearchText + '%'";

                    cmd.Parameters.AddWithValue("@SearchText", tbSearchPenalty.Text);

                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    try
                    {
                        con.Open();
                        DA.Fill(DS);

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvPenalties.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvPenalties.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                // Load all penalty data when the search box is empty
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
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

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvPenalties.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvPenalties.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            // Calculate the remaining balance whenever the amount to be paid or paid changes
            CalculateRemainingBalance();
        }

        private void CalculateRemainingBalance()
        {
            decimal toPay = 0;
            decimal payed = 0;

            // Try to parse the values from the textboxes; default to 0 if parsing fails
            decimal.TryParse(tbAmtToBe.Text, out toPay);
            decimal.TryParse(tbAmtPayed.Text, out payed);

            // Calculate the remaining balance
            decimal remainingBalance = toPay - payed;

            // Display the remaining balance in the label
            lblRemainingBalance.Text = remainingBalance.ToString("F2");
        }


       

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExitUpper_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPenalties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
*/