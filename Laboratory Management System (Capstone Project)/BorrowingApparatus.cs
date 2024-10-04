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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static Laboratory_Management_System__Capstone_Project_.Form1;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class BorrowingApparatus : Form
    {
        public BorrowingApparatus()
        {
            InitializeComponent();

            UIHelper.SetRoundedCorners(this, 20);

            UIHelper.SetRoundedCorners(btnConfirm, 30);
            UIHelper.SetRoundedCorners(btnSearch, 30);
            UIHelper.SetRoundedCorners(btnExit, 20);
            UIHelper.SetRoundedCorners(panel3, 20);

            UIHelper.SetShadow(btnConfirm);
            UIHelper.SetShadow(btnSearch);
            UIHelper.SetShadow(panel3);

            UIHelper.MakeRoundedTextBox(tbSearch, 25);
            UIHelper.MakeRoundedTextBox(tbStudName, 25);
            UIHelper.MakeRoundedTextBox(tbIDnum, 25);
            UIHelper.MakeRoundedTextBox(tbEmail, 25);
            UIHelper.MakeRoundedTextBox(tbContact, 25);
            UIHelper.MakeRoundedTextBox(tbProgram, 25);
            UIHelper.MakeRoundedTextBox(tbPurpose, 25);

            UIHelper.SetRoundedComboBox(cbApparatusName, 25);
            UIHelper.SetRoundedComboBox(cbApparatusName1, 25);
            UIHelper.SetRoundedComboBox(cbApparatusName2, 25);
            UIHelper.SetRoundedComboBox(cbApparatusName3, 25);
            UIHelper.SetRoundedComboBox(cbApparatusName4, 25);

            UIHelper.SetRoundedNumericUpDown(nudQuantity, 25);
            UIHelper.SetRoundedNumericUpDown(nudQuantity1, 25);
            UIHelper.SetRoundedNumericUpDown(nudQuantity2, 25);
            UIHelper.SetRoundedNumericUpDown(nudQuantity3, 25);
            UIHelper.SetRoundedNumericUpDown(nudQuantity4, 25);
        }

        //Loading of ID numbers
        private void LoadIDNumbers()
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID_Number FROM Students", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    autoCompleteCollection.Add(reader["ID_Number"].ToString());
                }
                reader.Close();
            }

            // Configure AutoComplete properties
            tbSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbSearch.AutoCompleteCustomSource = autoCompleteCollection;
        }


        //EXIT BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the instance?"
                , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                Dashboard.formRestrict = 0;

            }

        }

        private void BorrowingApparatus_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True");
            SqlCommand cmd = new SqlCommand("Select [Apparatus Name] from Inventory", con);
            con.Open();
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                string apparatusName = Sdr.GetString(0);
                cbApparatusName.Items.Add(apparatusName);
                cbApparatusName1.Items.Add(apparatusName);
                cbApparatusName2.Items.Add(apparatusName);
                cbApparatusName3.Items.Add(apparatusName);
                cbApparatusName4.Items.Add(apparatusName);
            }
            Sdr.Close();
            con.Close();

            LoadIDNumbers();


            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 10; // Set the maximum quantity to 100
            nudQuantity.Value = 1; // Set the default value to 1

            nudQuantity1.Minimum = 1;
            nudQuantity1.Maximum = 10;
            nudQuantity1.Value = 1;

            nudQuantity2.Minimum = 1;
            nudQuantity2.Maximum = 10;
            nudQuantity2.Value = 1;

            nudQuantity3.Minimum = 1;
            nudQuantity3.Maximum = 10;
            nudQuantity3.Value = 1;

            nudQuantity4.Minimum = 1;
            nudQuantity4.Maximum = 10;
            nudQuantity4.Value = 1;
        }




        //Counter var
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                String searchID = tbSearch.Text;
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE ID_Number = @ID_Number", con);
                    cmd.Parameters.AddWithValue("@ID_Number", searchID);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count != 0)
                    {
                        DataRow dr = DS.Tables[0].Rows[0];
                        tbStudName.Text = dr["Student_Name"].ToString();
                        tbIDnum.Text = dr["ID_Number"].ToString();
                        tbEmail.Text = dr["Email_Address"].ToString();
                        tbContact.Text = dr["Contact_No"].ToString();
                        tbProgram.Text = dr["Program"].ToString();
                    }
                    else
                    {
                        tbStudName.Clear();
                        tbIDnum.Clear();
                        tbEmail.Clear();
                        tbContact.Clear();
                        tbProgram.Clear();
                        MessageBox.Show("Student ID number does not exist or is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Count how many apparatuses have been borrowed by this student
                    SqlCommand cmdCount = new SqlCommand("SELECT SUM(Quantity) FROM BorrowReturnTransaction WHERE ID_Number = @ID_Number AND Date_Returned IS NULL AND Quantity_Returned is NULL", con);
                    cmdCount.Parameters.AddWithValue("@ID_Number", searchID);
                    con.Open();
                    object resultCount = cmdCount.ExecuteScalar();
                    con.Close();

                    if (resultCount != DBNull.Value)
                    {
                        count = Convert.ToInt32(resultCount);
                    }
                    else
                    {
                        count = 0;
                    }


                    /* Count how many apparatuses have been borrowed by this student
                    SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM BorrowReturnTransaction WHERE ID_Number = @ID_Number AND Date_Returned IS NULL", con);
                    cmdCount.Parameters.AddWithValue("@ID_Number", searchID);
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();*/
                }
            }
        }

        //Resetting the objects once a transaction is done.
        private void ResetForm()
        {
            tbStudName.Clear();
            tbIDnum.Clear();
            tbEmail.Clear();
            tbContact.Clear();
            tbProgram.Clear();
            tbSearch.Clear();

            cbApparatusName.SelectedIndex = -1;
            cbApparatusName1.SelectedIndex = -1;
            cbApparatusName2.SelectedIndex = -1;
            cbApparatusName3.SelectedIndex = -1;
            cbApparatusName4.SelectedIndex = -1;

            nudQuantity.Value = 1;
            nudQuantity1.Value = 1;
            nudQuantity2.Value = 1;
            nudQuantity3.Value = 1;
            nudQuantity4.Value = 1;

            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbStudName.Text != "")
            {
                //up to 10 apparatuses can be borrowed
                //count is 0 to 9
                if (count <= 9)
                {
                    List<string> selectedApparatusNames = new List<string>
            {
                cbApparatusName.Text,
                cbApparatusName1.Text,
                cbApparatusName2.Text,
                cbApparatusName3.Text,
                cbApparatusName4.Text
            };

                    List<int> quantities = new List<int>
            {
                (int)nudQuantity.Value,
                (int)nudQuantity1.Value,
                (int)nudQuantity2.Value,
                (int)nudQuantity3.Value,
                (int)nudQuantity4.Value
            };

                    String Studname = tbStudName.Text;
                    String IDnum = tbIDnum.Text;
                    String Email = tbEmail.Text;
                    Int64 Contact = Int64.Parse(tbContact.Text);
                    String Program = tbProgram.Text;
                    String purpose = tbPurpose.Text;
                    String IssueDate = dtpBorrowDate.Text;
                    String dueDate = dtpDueDate.Text;

                    using (SqlConnection dbConnection = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        try
                        {
                            dbConnection.Open();

                            if (tbPurpose.Text == "None" || tbPurpose.Text == "" || tbPurpose.Text == "Unknown" || tbPurpose.Text == "UNKNOWN" || tbPurpose.Text == "Unknown Purpose" || tbPurpose.Text == "UNKNOWN PURPOSE")
                            {
                                MessageBox.Show("Please enter a valid purpose.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            for (int i = 0; i < selectedApparatusNames.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(selectedApparatusNames[i]))
                                {
                                    string AppaName = selectedApparatusNames[i];
                                    int quantity = quantities[i];

                                    int apparatusID = 0; // Declare apparatusID here

                                    // Get ApparatusID based on the selected apparatus name
                                    using (SqlCommand cmdGetApparatusID = new SqlCommand("SELECT ApparatusID FROM Inventory WHERE [Apparatus Name] = @Apparatus_Name", dbConnection))
                                    {
                                        cmdGetApparatusID.Parameters.AddWithValue("@Apparatus_Name", AppaName);
                                        object resultApparatus = cmdGetApparatusID.ExecuteScalar();
                                        if (resultApparatus != null)
                                        {
                                            apparatusID = Convert.ToInt32(resultApparatus);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Apparatus '{AppaName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }

                                    // Check if the quantity borrowed does not exceed the quantity available
                                    using (SqlCommand cmdGetQuantityAvailable = new SqlCommand("SELECT Quantity FROM Inventory WHERE ApparatusID = @ApparatusID", dbConnection))
                                    {
                                        cmdGetQuantityAvailable.Parameters.AddWithValue("@ApparatusID", apparatusID);
                                        int quantityAvailable = (int)cmdGetQuantityAvailable.ExecuteScalar();
                                        if (quantity > quantityAvailable)
                                        {
                                            MessageBox.Show($"Quantity borrowed exceeds quantity available for apparatus '{AppaName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }

                                    // Insert multiple rows for each apparatus
                                    for (int j = 0; j < quantity; j++)
                                    {
                                        int studentID = 0;
                                        int accountID = Form1.Session.AccountID; // Get the AccountID from the Session class based on the logged user

                                        // Get StudentID based on the student's ID number
                                        using (SqlCommand cmdGetStudentID = new SqlCommand("SELECT studID FROM Students WHERE ID_Number = @ID_Number", dbConnection))
                                        {
                                            cmdGetStudentID.Parameters.AddWithValue("@ID_Number", IDnum);
                                            object resultStudent = cmdGetStudentID.ExecuteScalar();
                                            if (resultStudent != null)
                                            {
                                                studentID = Convert.ToInt32(resultStudent);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Student with ID number '{IDnum}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }

                                        // Insert transaction with IDs and quantities
                                        using (SqlCommand cmdInsertTransaction = new SqlCommand("INSERT INTO BorrowReturnTransaction (Student_Name, ID_Number, Email_Address, Contact_Number, Program, Apparatus_Name, Quantity, Purpose, Borrow_Date, Due_Date, Quantity_Returned, Date_Returned, studID, AccountID, ApparatusID, Remarks) VALUES (@Student_Name, @ID_Number, @Email_Address, @Contact_Number, @Program, @Apparatus_Name, @Quantity, @Purpose, @Borrow_Date, @Due_Date, NULL, NULL, @StudentID, @AccountID, @ApparatusID, NULL)", dbConnection))
                                        {
                                            cmdInsertTransaction.Parameters.AddWithValue("@Student_Name", Studname);
                                            cmdInsertTransaction.Parameters.AddWithValue("@ID_Number", IDnum);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Email_Address", Email);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Contact_Number", Contact);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Program", Program);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Apparatus_Name", AppaName);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Quantity", quantity);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Purpose", purpose);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Borrow_Date", IssueDate);
                                            cmdInsertTransaction.Parameters.AddWithValue("@Due_Date", dueDate);
                                            cmdInsertTransaction.Parameters.AddWithValue("@StudentID", studentID);
                                            cmdInsertTransaction.Parameters.AddWithValue("@AccountID", accountID);
                                            cmdInsertTransaction.Parameters.AddWithValue("@ApparatusID", apparatusID);
                                            cmdInsertTransaction.ExecuteNonQuery();

                                        }

                                    }

                                    // Update apparatus quantity
                                    using (SqlCommand cmdUpdateQty = new SqlCommand("UPDATE Inventory SET Quantity = Quantity - @Quantity WHERE ApparatusID = @ApparatusID", dbConnection))
                                    {
                                        cmdUpdateQty.Parameters.AddWithValue("@Quantity", quantity);
                                        cmdUpdateQty.Parameters.AddWithValue("@ApparatusID", apparatusID);
                                        cmdUpdateQty.ExecuteNonQuery();

                                    }

                                }
                            }

                            MessageBox.Show("Apparatuses have been issued.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Student has reached the maximum number of apparatuses that can be borrowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter a valid student ID number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                ResetForm();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        //Pressing ENTER on the Search box
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
