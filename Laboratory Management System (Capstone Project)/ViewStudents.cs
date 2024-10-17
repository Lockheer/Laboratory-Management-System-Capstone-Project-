using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class ViewStudentInformation : Form, IUnsavedChangesForm
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
            cbProgram.SelectedIndexChanged += new EventHandler(cbProgram_SelectedIndexChanged);
            cbProgramFilter.SelectedIndexChanged += new EventHandler(cbProgramFilter_SelectedIndexChanged);
            tbStudentSearch.TextChanged += new EventHandler(tbStudentSearch_TextChanged);
        }

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
                    return;
                }
            }
        }

        // Call this method when the user makes changes to the form
        private void UpdateUnsavedChanges()
        {
            _hasUnsavedChanges = true;
        }




        private void CbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
            throw new NotImplementedException();
        }



       

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            tbStudentSearch.TextChanged += new EventHandler(tbStudentSearch_TextChanged);
            panel2.Visible = false;
            // Ensure the connection string is correct and accessible
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Define the SQL command
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);

                    // Set up the data adapter and associate it with the command
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);

                    // Create a DataSet to hold the data
                    DataSet DS = new DataSet();

                    // Fill the DataSet with data from the database
                    DA.Fill(DS);

                    // Bind the data to the DataGridView
                    dgvStudentsInformation.DataSource = DS.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Populate the ComboBox with distinct program names
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Program FROM Students", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cbProgramFilter.Items.Add(reader["Program"].ToString());
                    }

                    reader.Close();

                    // Load all student data initially
                    LoadStudentData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void LoadStudentData()
        {
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                try
                {
                    con.Open();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        dgvStudentsInformation.DataSource = DS.Tables[0];
                    }
                    else
                    {
                        dgvStudentsInformation.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        int ID;
        Int64 rowid;
        private void dgvStudentsInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell and row are within the valid range
            if (e.RowIndex >= 0 && dgvStudentsInformation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string cellValue = dgvStudentsInformation.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out ID))
                {
                    panel2.Visible = true;

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
                                rowid = Int64.Parse(DS.Tables[0].Rows[0]["studID"].ToString());
                                tbStudentName.Text = DS.Tables[0].Rows[0]["Student_Name"].ToString();
                                tbIDNum.Text = DS.Tables[0].Rows[0]["ID_Number"].ToString();
                                tbEmail.Text = DS.Tables[0].Rows[0]["Email_Address"].ToString();
                                tbContactNum.Text = DS.Tables[0].Rows[0]["Contact_No"].ToString();
                                cbProgram.Text = DS.Tables[0].Rows[0]["Program"].ToString();
                                cbDept.Text = DS.Tables[0].Rows[0]["Department"].ToString();
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid selection. Please select a valid row.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String studname = tbStudentName.Text;
            String idnum = tbIDNum.Text;
            String email = tbEmail.Text;
            Int64 contactnum;
            String program = cbProgram.Text;
            String department = cbDept.Text;
 

            if (!Int64.TryParse(tbContactNum.Text, out contactnum))
            {
                MessageBox.Show("Invalid contact number.");
                return;
            }
            if (tbContactNum.TextLength < 10 || tbContactNum.TextLength > 11)
            {
                MessageBox.Show("Please enter a valid contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(tbEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbStudentName.Text) || string.IsNullOrEmpty(tbIDNum.Text) || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbContactNum.Text) || string.IsNullOrEmpty(cbProgram.Text) || string.IsNullOrEmpty(cbDept.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (MessageBox.Show("Student's Information will now be updated.\n" +
                "\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                   
                   
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "UPDATE Students SET Student_Name = @StudentName, ID_Number = @IDNumber, Email_Address = @Email, Contact_No = @ContactNumber, Program = @Program, Department = @Department,  WHERE studID = @RowID";

                        cmd.Parameters.AddWithValue("@StudentName", studname);
                        cmd.Parameters.AddWithValue("@IDNumber", idnum);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactnum);
                        cmd.Parameters.AddWithValue("@Program", program);
                        cmd.Parameters.AddWithValue("@Department", department);
                      
                        cmd.Parameters.AddWithValue("@RowID", rowid);

                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student information updated successfully.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No student found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            // Refresh the data grid view with the updated data
                            ViewStudentInformation_Load(this, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

                    cmd.CommandText = "DELETE FROM Students WHERE studID = @RowID";
                    cmd.Parameters.AddWithValue("@RowID", rowid);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student record deleted successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No student found with the specified ID.","No ID Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Refresh the data grid view with the updated data
                        ViewStudentInformation_Load(this, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbStudentSearch.Clear();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tbStudentName.Clear();
            tbIDNum.Clear();
            tbEmail.Clear();
            tbContactNum.Clear();
            cbProgram.SelectedIndex = -1;
            cbDept.SelectedIndex = -1;
           
        }

     
        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure controls are not null
            if (cbProgram == null || cbDept == null) return;

            // Ensure the selected item is not null
            if (cbProgram.SelectedItem == null) return;

            // Automatically select the department based on the selected program
            switch (cbProgram.SelectedItem.ToString())
            {
                case "BSCE":
                case "BSME":
                case "BSIE":
                case "BSEE":
                    cbDept.SelectedItem = "College Of Engineering";
                    break;

                case "SHS":
                    cbDept.SelectedItem = "Senior High School Branch";
                    break;

                default:
                    cbDept.SelectedIndex = -1; // Clear selection if no match is found
                    break;
            }
        }

        private void cbProgramFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProgramFilter.SelectedItem != null)
            {
                string selectedProgram = cbProgramFilter.SelectedItem.ToString();
                FilterStudentsByProgram(selectedProgram);
            }
            else
            {
                // If no program is selected, show all students
                LoadStudentData();
            }
        }

        private void FilterStudentsByProgram(string program)
        {
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE Program = @Program", con);
                cmd.Parameters.AddWithValue("@Program", program);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                try
                {
                    con.Open();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        dgvStudentsInformation.DataSource = DS.Tables[0];
                    }
                    else
                    {
                        dgvStudentsInformation.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        // Set the license context (important to avoid license-related errors)
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        var worksheet = package.Workbook.Worksheets.Add("Students");

                        // Add column headers
                        for (int i = 1; i < dgvStudentsInformation.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i].Value = dgvStudentsInformation.Columns[i - 1].HeaderText;
                        }

                        // Add rows
                        for (int i = 0; i < dgvStudentsInformation.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvStudentsInformation.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dgvStudentsInformation.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Save to file
                        try
                        {
                            package.SaveAs(new System.IO.FileInfo(sfd.FileName));
                            MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void tbStudentName_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbIDNum_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbContactNum_TextChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnsavedChanges();
        }

        private void tbStudentSearch_TextChanged(object sender, EventArgs e)
        {
            // Update the search icon and label visibility based on input
            if (tbStudentSearch.Text != "")
            {
                Image searchImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search1.gif");
                pictureBox1.Image = searchImage;
                label1.Visible = false;
                cbProgramFilter.SelectedIndex = -1;

                // Perform the search
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Students WHERE ID_Number LIKE @SearchText + '%' OR Student_Name LIKE @SearchText + '%' OR Email_Address LIKE @SearchText + '%' " +
                        "OR Contact_No LIKE @SearchText + '%' OR Program LIKE @SearchText + '%' OR Department LIKE @SearchText + '%'";

                    cmd.Parameters.AddWithValue("@SearchText", tbStudentSearch.Text);

                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    try
                    {
                        con.Open();
                        DA.Fill(DS);

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvStudentsInformation.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvStudentsInformation.DataSource = null;
                            MessageBox.Show("No records found matching your search criteria.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred during the search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Image defaultImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search.gif");
                pictureBox1.Image = defaultImage;
                label1.Visible = true;

                // Load all student data when the search box is empty
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Students";

                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    try
                    {
                        con.Open();
                        DA.Fill(DS);

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvStudentsInformation.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvStudentsInformation.DataSource = null;
                            MessageBox.Show("No student records found.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            UpdateUnsavedChanges();
        }

        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

      
    }
}
/*private void tbStudentSearch_TextChanged(object sender, EventArgs e)
      {
          // Update the search icon and label visibility based on input
          if (tbStudentSearch.Text != "")
          {
              Image searchImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search1.gif");
              pictureBox1.Image = searchImage;
              label1.Visible = false;
              cbProgramFilter.SelectedIndex = -1;

              // Perform the search
              using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.Connection = con;
                  cmd.CommandText = "SELECT * FROM Students WHERE ID_Number LIKE @SearchText + '%' OR Student_Name LIKE @SearchText + '%' OR Email_Address LIKE @SearchText + '%' OR Contact_No LIKE @SearchText + '%' OR Program LIKE @SearchText + '%' OR Department LIKE @SearchText + '%'";

                  cmd.Parameters.AddWithValue("@SearchText", tbStudentSearch.Text);

                  SqlDataAdapter DA = new SqlDataAdapter(cmd);
                  DataSet DS = new DataSet();

                  try
                  {
                      con.Open();
                      DA.Fill(DS);

                      // Check if the dataset is empty
                      if (DS.Tables[0].Rows.Count > 0)
                      {
                          dgvStudentsInformation.DataSource = DS.Tables[0];
                      }
                      else
                      {
                          dgvStudentsInformation.DataSource = null;
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
          }
          else
          {
              Image defaultImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search.gif");
              pictureBox1.Image = defaultImage;
              label1.Visible = true;

              // Load all student data when the search box is empty
              using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.Connection = con;
                  cmd.CommandText = "SELECT * FROM Students";

                  SqlDataAdapter DA = new SqlDataAdapter(cmd);
                  DataSet DS = new DataSet();

                  try
                  {
                      con.Open();
                      DA.Fill(DS);

                      // Check if the dataset is empty
                      if (DS.Tables[0].Rows.Count > 0)
                      {
                          dgvStudentsInformation.DataSource = DS.Tables[0];
                      }
                      else
                      {
                          dgvStudentsInformation.DataSource = null;
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
          }
      }*/



/* private void tbStudentSearch_TextChanged(object sender, EventArgs e)
        {
            // Update the search icon and label visibility based on input
            if (tbStudentSearch.Text != "")
            {
                Image searchImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search1.gif");
                pictureBox1.Image = searchImage;
                label1.Visible = false;
                cbProgramFilter.SelectedIndex = -1;

                // Perform the search
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Students WHERE ID_Number LIKE @SearchText + '%' OR Student_Name LIKE @SearchText + '%' OR Email_Address LIKE @SearchText + '%' " +
                        "OR Contact_No LIKE @SearchText + '%' OR Program LIKE @SearchText + '%' OR Department LIKE @SearchText + '%'";

                    cmd.Parameters.AddWithValue("@SearchText", tbStudentSearch.Text);

                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    try
                    {
                        con.Open();
                        DA.Fill(DS);

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvStudentsInformation.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvStudentsInformation.DataSource = null;
                            MessageBox.Show("No records found matching your search criteria.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred during the search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Image defaultImage = Image.FromFile("C:/Users/Kyoto/source/repos/Laboratory Management System (Capstone Project)/Images/img/search.gif");
                pictureBox1.Image = defaultImage;
                label1.Visible = true;

                // Load all student data when the search box is empty
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Students";

                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    try
                    {
                        con.Open();
                        DA.Fill(DS);

                        // Check if the dataset is empty
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            dgvStudentsInformation.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            dgvStudentsInformation.DataSource = null;
                            MessageBox.Show("No student records found.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
*/