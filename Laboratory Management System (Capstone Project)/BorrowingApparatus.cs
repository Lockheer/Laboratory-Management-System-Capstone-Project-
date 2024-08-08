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
            if (MessageBox.Show("Do you want to go back to the Dashboard?"
                , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                Dashboard.formRestrict = 0;

            }

        }

        private void BorrowingApparatus_Load(object sender, EventArgs e)
        {
            //Load the COMBO BOX with the apparatus name data source
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("Select [Apparatus Name] from ApparatusList",con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read()) 
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    cbApparatusName.Items.Add(Sdr.GetString(i));
                }

            }
            Sdr.Close();
            con.Close();

            LoadIDNumbers();
        }




        //Counter var
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                String searchID = tbSearch.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select count(ID_Number) from BorrowReturnTransaction where ID_Number = '" + searchID+ "' and Student_Name = '" + searchID+ "' and Date_Returned is NULL";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                //---------------------------------------------------------------------------------------
                //Code to count how many Apparatus has been borrowed by the following matching ID Number
                cmd.CommandText = "Select * from Students where ID_Number = '" + searchID + "'";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());

                //---------------------------------------------------------------------------------------


                if (DS.Tables[0].Rows.Count != 0)
                {
                    tbStudName.Text = DS.Tables[0].Rows[0][1].ToString();
                    tbIDnum.Text = DS.Tables[0].Rows[0][2].ToString();
                    tbEmail.Text = DS.Tables[0].Rows[0][3].ToString();
                    tbContact.Text = DS.Tables[0].Rows[0][4].ToString();
                    tbProgram.Text = DS.Tables[0].Rows[0][5].ToString();

                }else
                {
                    tbStudName.Clear();
                    tbIDnum.Clear(); 
                    tbEmail.Clear(); 
                    tbContact.Clear();
                    tbProgram.Clear();
                    MessageBox.Show("Student ID number does not exist or is invalid.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            // Resets the combobox to default
            cbApparatusName.SelectedIndex = -1;
            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbStudName.Text != "")
            {
                // Maximum of 5 apparatuses can only be borrowed.
                if (cbApparatusName.SelectedIndex != -1 && count <= 4)
                {
                    String Studname = tbStudName.Text;
                    String IDnum = tbIDnum.Text;
                    String Email = tbEmail.Text;
                    Int64 Contact = Int64.Parse(tbContact.Text);
                    String Program = tbProgram.Text;
                    String AppaName = cbApparatusName.Text;
                    String IssueDate = dtpBorrowDate.Text;
                    String dueDate = dtpDueDate.Text;

                    int apparatusID = 0;
                    int studentID = 0;
                    int accountID = Session.AccountID; // Retrieve AccountID from the static Session class
                   

                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        con.Open();

                        // Get ApparatusID based on the selected apparatus name
                        SqlCommand cmdGetApparatusID = new SqlCommand("SELECT ApparatusID FROM ApparatusList WHERE [Apparatus Name] = @Apparatus_Name", con);
                        cmdGetApparatusID.Parameters.AddWithValue("@Apparatus_Name", AppaName);
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

                        // Get StudentID based on ID number
                        SqlCommand cmdGetStudentID = new SqlCommand("SELECT studID FROM Students WHERE ID_Number = @ID_Number", con);
                        cmdGetStudentID.Parameters.AddWithValue("@ID_Number", IDnum);
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

                        // Insert transaction with IDs
                        SqlCommand cmdInsertTransaction = new SqlCommand("INSERT INTO BorrowReturnTransaction (Student_Name, ID_Number, Email_Address, Contact_Number, Program, Apparatus_Name, Borrow_Date, Due_Date, Date_Returned, studID, AccountID, ApparatusID, Remarks) VALUES (@Student_Name, @ID_Number, @Email_Address, @Contact_Number, @Program, @Apparatus_Name, @Borrow_Date, @Due_Date, NULL, @StudentID, @AccountID, @ApparatusID, NULL)", con);
                        cmdInsertTransaction.Parameters.AddWithValue("@Student_Name", Studname);
                        cmdInsertTransaction.Parameters.AddWithValue("@ID_Number", IDnum);
                        cmdInsertTransaction.Parameters.AddWithValue("@Email_Address", Email);
                        cmdInsertTransaction.Parameters.AddWithValue("@Contact_Number", Contact);
                        cmdInsertTransaction.Parameters.AddWithValue("@Program", Program);
                        cmdInsertTransaction.Parameters.AddWithValue("@Apparatus_Name", AppaName);
                        cmdInsertTransaction.Parameters.AddWithValue("@Borrow_Date", IssueDate);
                        cmdInsertTransaction.Parameters.AddWithValue("@Due_Date", dueDate);
                        cmdInsertTransaction.Parameters.AddWithValue("@StudentID", studentID);
                        cmdInsertTransaction.Parameters.AddWithValue("@AccountID", accountID);
                        cmdInsertTransaction.Parameters.AddWithValue("@ApparatusID", apparatusID);
                        cmdInsertTransaction.ExecuteNonQuery();

                        // Update apparatus quantity
                        SqlCommand cmdUpdateQty = new SqlCommand("UPDATE ApparatusList SET Quantity = Quantity - 1 WHERE ApparatusID = @ApparatusID", con);
                        cmdUpdateQty.Parameters.AddWithValue("@ApparatusID", apparatusID);
                        cmdUpdateQty.ExecuteNonQuery();

                        MessageBox.Show("Apparatus has been issued.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an Apparatus OR the student has reached their maximum borrow attempts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Student ID Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
