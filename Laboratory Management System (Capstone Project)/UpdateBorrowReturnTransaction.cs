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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;


namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class UpdateBorrowReturnTransaction : Form, IUnsavedChangesForm
    {

        public UpdateBorrowReturnTransaction()
        {
            InitializeComponent();
        }

        private bool _hasUnsavedChanges = false;
        public bool HasUnsavedChanges
        {
            get { return _hasUnsavedChanges; }
        }

    
        // Call this method when the user makes changes to the form
        private void UpdateUnsavedChanges()
        {
            _hasUnsavedChanges = true;
        }


        private void tbStudentName_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbEmailAdd_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }
        private void tbPurpose_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void cbAppaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void dtpBorrowedDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void nudQuantityReturned_ValueChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void dtpDateReturned_ValueChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbRemarks_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }




        Int64 rowid;
        int id;

        private void UpdateBorrowReturnTransaction_Load(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Student_Name, ID_Number, Email_Address, Contact_Number, Program, Apparatus_Name, Quantity, Purpose, Borrow_Date, Due_Date, Quantity_Returned, Date_Returned, Remarks FROM BorrowReturnTransaction", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgvTransaction.DataSource = ds.Tables[0];
                }
                pnelUPDATE.Visible = false;

                // Populate the Apparatus Name ComboBox
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [Apparatus Name] FROM Inventory", con);
                    SqlDataReader sdataread = cmd.ExecuteReader();

                    while (sdataread.Read())
                    {
                        cbAppaName.Items.Add(sdataread.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                if (dgvTransaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(dgvTransaction.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                pnelUPDATE.Visible = true;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM BorrowReturnTransaction WHERE transactionID= {id}", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];

                        rowid = Convert.ToInt64(row[0]);
                        tbStudentName.Text = row[1].ToString();
                        tbIDNum.Text = row[2].ToString();
                        tbEmailAdd.Text = row[3].ToString();
                        tbContact.Text = row[4].ToString();
                        cbProgram.Text = row[5].ToString();
                        cbAppaName.Text = row[6].ToString();
                        nudQuantity.Value = Convert.ToInt32(row[7]);
                        tbRemarks.Text = row[8].ToString();
                        dtpBorrowedDate.Text = row[9].ToString();
                        dtpDueDate.Text = row[10].ToString();
                        nudQuantityReturned.Value = Convert.ToInt32(row[11]);
                        dtpDateReturned.Text = row[12].ToString();
                        tbRemarks.Text = row[13].ToString();
                       
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbStudentName.Text))
                {
                    MessageBox.Show("Please enter the student's name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbStudentName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbIDNum.Text))
                {
                    MessageBox.Show("Please enter the student's ID number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbIDNum.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbEmailAdd.Text))
                {
                    MessageBox.Show("Please enter the student's email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbEmailAdd.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbContact.Text))
                {
                    MessageBox.Show("Please enter the student's contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbContact.Focus();
                    return;
                }

                if (cbProgram.SelectedItem == null)
                {
                    MessageBox.Show("Please select the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbProgram.Focus();
                    return;
                }

                if (cbAppaName.SelectedItem == null)
                {
                    MessageBox.Show("Please select the apparatus name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAppaName.Focus();
                    return;
                }

                //Checks if the quantity matches with the inventory quantity
                if (nudQuantity.Value == 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nudQuantity.Focus();
                    return;
                }

                // Check if the entered quantity is not more than the available quantity in the Inventory
                int availableQuantity = GetAvailableQuantity(cbAppaName.SelectedItem.ToString());
                if (nudQuantity.Value > availableQuantity)
                {
                    MessageBox.Show($"You cannot borrow more than {availableQuantity} {cbAppaName.SelectedItem} from the Inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nudQuantity.Focus();
                    return;
                }


                if (nudQuantityReturned.Value == 0)
                {
                    MessageBox.Show("Please enter a valid quantity returned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nudQuantityReturned.Focus();
                    return;
                }

                if (cbAppaName.SelectedItem == null)
                {
                    MessageBox.Show("Please select the apparatus name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbAppaName.Focus();
                    return;
                }


                if (tbPurpose.Text == "None" || tbPurpose.Text == "" || tbPurpose.Text == "Unknown" || tbPurpose.Text == "UNKNOWN" || tbPurpose.Text == "Unknown Purpose" || tbPurpose.Text == "UNKNOWN PURPOSE")
                {
                    MessageBox.Show("Please enter a valid purpose.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                // Get the ApparatusID based on the selected Apparatus Name
                int apparatusID = GetApparatusID(cbAppaName.SelectedItem.ToString());
                //Getting the studID during updating
                int studentID = GetStudentID(tbStudentName.Text, tbIDNum.Text);

                // Update the database with the new values
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE BorrowReturnTransaction SET Student_Name = @Student_Name, ID_Number = @ID_Number, Email_Address = @Email_Address, Contact_Number = @Contact_Number, Program = @Program, Apparatus_Name = @Apparatus_Name, ApparatusID = @ApparatusID, Quantity = @Quantity, Purpose = @Purpose, Borrow_Date = @Borrow_Date, Due_Date = @Due_Date, Quantity_Returned = @Quantity_Returned, Date_Returned = @Date_Returned, Remarks = @Remarks, studID = @StudentID WHERE transactionID = @transactionID", con);

                    cmd.Parameters.AddWithValue("@Student_Name", tbStudentName.Text);
                    cmd.Parameters.AddWithValue("@ID_Number", tbIDNum.Text);
                    cmd.Parameters.AddWithValue("@Email_Address", tbEmailAdd.Text);
                    cmd.Parameters.AddWithValue("@Contact_Number", tbContact.Text);
                    cmd.Parameters.AddWithValue("@Program", cbProgram.SelectedItem);
                    cmd.Parameters.AddWithValue("@Apparatus_Name", cbAppaName.SelectedItem);
                    cmd.Parameters.AddWithValue("@ApparatusID", apparatusID);
                    cmd.Parameters.AddWithValue("@Quantity", nudQuantity.Value);
                    cmd.Parameters.AddWithValue("@Purpose", tbPurpose.Text);
                    cmd.Parameters.AddWithValue("@Borrow_Date", dtpBorrowedDate.Value);
                    cmd.Parameters.AddWithValue("@Due_Date", dtpDueDate.Value);
                    cmd.Parameters.AddWithValue("@Quantity_Returned", nudQuantityReturned.Value);
                    cmd.Parameters.AddWithValue("@Date_Returned", dtpDateReturned.Value);
                    cmd.Parameters.AddWithValue("@Remarks", tbRemarks.Text);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@transactionID", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("The Data will be deleted\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                    {
                        SqlCommand cmd = new SqlCommand($"DELETE FROM BorrowReturnTransaction WHERE transactionID = {rowid}", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateBorrowReturnTransaction_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pnelUPDATE.Visible = false;
            tbSearch.Clear();
        }


        // Helper method to get the available quantity from the Inventory
        private int GetAvailableQuantity(string apparatusName)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Quantity FROM Inventory WHERE [Apparatus Name] = @Apparatus_Name", con);
                cmd.Parameters.AddWithValue("@Apparatus_Name", apparatusName);

                int availableQuantity = (int)cmd.ExecuteScalar();

                return availableQuantity;
            }
        }


        // Helper method to get the ApparatusID based on the Apparatus Name
        private int GetApparatusID(string apparatusName)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ApparatusID FROM Inventory WHERE [Apparatus Name] = @Apparatus_Name", con);
                cmd.Parameters.AddWithValue("@Apparatus_Name", apparatusName);

                int apparatusID = (int)cmd.ExecuteScalar();

                return apparatusID;
            }
        }



        // Helper method to get the StudentID based on the student's information
        private int GetStudentID(string studentName, string idNumber)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT studID FROM Students WHERE Student_Name = @Student_Name AND ID_Number = @ID_Number", con);
                cmd.Parameters.AddWithValue("@Student_Name", studentName);
                cmd.Parameters.AddWithValue("@ID_Number", idNumber);

                int studentID = (int)cmd.ExecuteScalar();

                return studentID;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Set the license context for EPPlus
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BorrowReturnTransaction", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        using (ExcelPackage pck = new ExcelPackage())
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("BorrowReturnTransaction");

                            // Load the DataTable into the sheet, starting from cell A1
                            ws.Cells["A1"].LoadFromDataTable(dt, true);

                            // Format the header for columns
                            using (ExcelRange rng = ws.Cells["A1:XFD1"])
                            {
                                rng.Style.Font.Bold = true;
                                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                                rng.Style.Font.Color.SetColor(Color.White);
                            }

                            // Auto-fit columns
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            // Create a SaveFileDialog to choose the location and file name
                            using (SaveFileDialog sfd = new SaveFileDialog())
                            {
                                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                                sfd.Title = "Save an Excel File";

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    // Save the file to the selected location
                                    File.WriteAllBytes(sfd.FileName, pck.GetAsByteArray());

                                    MessageBox.Show($"Data has been successfully exported to {sfd.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbIDNum_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
            // Get the list of existing ID Numbers from the Students table
            List<string> idNumbers = GetExistingIDNumbers();

            // Create an AutoCompleteStringCollection from the list
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (string idNumber in idNumbers)
            {
                autoCompleteCollection.Add(idNumber);
            }

            // Set up the AutoComplete feature
            tbIDNum.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbIDNum.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbIDNum.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private List<string> GetExistingIDNumbers()
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID_Number FROM Students", con);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> idNumbers = new List<string>();

                while (reader.Read())
                {
                    idNumbers.Add(reader["ID_Number"].ToString());
                }

                return idNumbers;
            }
        }

        private void tbIDNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected ID Number
            string selectedIDNumber = tbIDNum.Text;

            // Get the corresponding student information
            Student student = GetStudentInfo(selectedIDNumber);

            // Update the textboxes and combobox
            tbStudentName.Text = student.StudentName;
            tbEmailAdd.Text = student.EmailAddress;
            tbContact.Text = student.ContactNumber;
            cbProgram.SelectedItem = student.Program;
        }

        private Student GetStudentInfo(string idNumber)
        {
            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Student_Name, Email_Address, Contact_No, Program FROM Student WHERE ID_Number = @ID_Number", con);
                cmd.Parameters.AddWithValue("@ID_Number", idNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                Student student = new Student();

                while (reader.Read())
                {
                    student.StudentName = reader["Student_Name"].ToString();
                    student.EmailAddress = reader["Email_Address"].ToString();
                    student.ContactNumber = reader["Contact_No"].ToString();
                    student.Program = reader["Program"].ToString();
                }

                return student;
            }
        }

        public class Student
        {
            public string StudentName { get; set; }
            public string EmailAddress { get; set; }
            public string ContactNumber { get; set; }
            public string Program { get; set; }
        }

        private void lnklblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbStudentName.Text = "";
            tbIDNum.Text = "";
            tbEmailAdd.Text = "";
            tbContact.Text = "";
            cbProgram.Text = "";
            cbAppaName.Text = string.Empty;
            nudQuantity.Value = 0;
            dtpBorrowedDate.Text = string.Empty;
            dtpDueDate.Text = string.Empty;
            nudQuantityReturned.Value = 0;
            dtpDateReturned.Text = string.Empty;
            tbRemarks.Text = string.Empty;

        }

        /*private void btnExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Unsaved changes will be lost\nDo you want to go back to the Dashboard?"
               , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                Dashboard.formRestrict = 0;

            }   
        }*/

      

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
                    
                    return;
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    if (!string.IsNullOrEmpty(tbSearch.Text))
                    {
                        cmd.CommandText = "SELECT * FROM BorrowReturnTransaction WHERE Student_Name LIKE @SearchText + '%' OR ID_Number LIKE @SearchText + '%' " +
                                          "OR Email_Address LIKE @SearchText + '%' OR Contact_Number LIKE @SearchText + '%' OR Program LIKE @SearchText + '%' " +
                                          "OR Apparatus_Name LIKE @SearchText + '%' OR Borrow_Date LIKE @SearchText + '%' OR Due_Date LIKE @SearchText + '%' " +
                                          "OR Date_Returned LIKE @SearchText + '%' OR Remarks LIKE @SearchText + '%' OR Purpose LIKE @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", tbSearch.Text.Trim());
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM BorrowReturnTransaction";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // Check if the dataset is empty
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgvTransaction.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        dgvTransaction.DataSource = null;
                        MessageBox.Show("No records found matching your search criteria.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }


  
}