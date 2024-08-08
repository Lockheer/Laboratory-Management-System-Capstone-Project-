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
            SqlConnection combo_con = new SqlConnection();
            combo_con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand new_cmd = new SqlCommand();
            new_cmd.Connection = combo_con;
            combo_con.Open();
            new_cmd.CommandText = "Select transactionID from BorrowReturnTransaction";
            SqlDataReader reader = new_cmd.ExecuteReader();

            while (reader.Read())
            {
                // Read the integer transaction ID and add it to the ComboBox
                cbTransact.Items.Add(reader.GetInt32(0));
            }

            reader.Close();
            combo_con.Close();
            con.Close();


          

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
                command.CommandText = "Insert into LaboratoryPenalties ([ID Number],[Student Name],[Contact Number],[Email Address],[Penalty Issued Date],[Violation],[Penalty Condition],[Amount to be Paid],[Amount Received], [Balance], [Penalty Status],[Transaction Reference Number]) values ('" + idnum + "','" + name + "', " + contact + ",'" + email + "',  '" + issueDate + "', '" + violation + "', '"+condition+"', "+ToPay+", "+Payed+ ", "+Balance+", '" + status+"', "+transactRef+")";
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
                        "[Amount to be Paid] = @ToBePayed, [Amount Received] = @Payed , [Balance] = @Balance, [Penalty Status] =@Status,[Transaction Reference Number] = @RefNum WHERE PenaltyID = @RowID";

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
            if (e.RowIndex >= 0 && dgvPenalties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
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
                            cbTransact.Text = DS.Tables[0].Rows[0]["[Transaction Reference Number]"].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
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
    }
}
