using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class TransactionDetails : Form
    {
        private DataGridView currentDataGridView;
        private string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True";

        public TransactionDetails()
        {
            InitializeComponent();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
        }

        private void TransactionDetails_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand { Connection = con };

                    // Load data into respective DataGridViews
                    LoadData(cmd, "select * from BorrowReturnTransaction where Quantity_Returned is NULL AND Date_Returned is NULL AND Remarks is NULL AND Quantity_Returned is NULL", dgvBorrowDetails);
                    LoadData(cmd, "select * from BorrowReturnTransaction where Quantity_Returned is not NULL AND Date_Returned is not NULL AND Remarks is not NULL AND Quantity_Returned is NOT NULL", dgvReturnDetails);
                    LoadData(cmd, "Select * from LaboratoryPenalties", dgvViolationRecords);

                    //Load data into Inventory and Category DataGridViews
                    LoadData(cmd,"SELECT i.[ApparatusID], i.[Apparatus Name], i.[Model Number], i.[Date Purchased], i.[Price], i.[Brand], i.[Status], i.[Quantity], i.[Remarks], c.[CategoryName] " +
                                 "FROM Inventory i " +
                                 "JOIN Category c ON i.CategoryID = c.CategoryID",dgvInventory);

                    LoadData(cmd, "Select * from Students", dgvStudents);

                    // Set up ComboBox options
                    SetupComboBox();

                    // Display the default DataGridView
                    DisplayDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(SqlCommand cmd, string query, DataGridView dataGridView)
        {
            try
            {
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBox()
        {
            cmbViewOptions.Items.AddRange(new string[]
            {
                "Borrowed Items",
                "Returned Items",
                "Violation Records",
                "Inventory List",
                "Student List"
            });
            cmbViewOptions.SelectedIndex = 0; // Default selection
        }

        private void DisplayDataGridView()
        {
            try
            {
                lblBorrow.Visible = dgvBorrowDetails.Visible = cmbViewOptions.SelectedIndex == 0;
                lblReturn.Visible = dgvReturnDetails.Visible = cmbViewOptions.SelectedIndex == 1;
                lblViolation.Visible = dgvViolationRecords.Visible = cmbViewOptions.SelectedIndex == 2;
                lblApparatus.Visible = dgvInventory.Visible = cmbViewOptions.SelectedIndex == 3;
                lblStudents.Visible = dgvStudents.Visible = cmbViewOptions.SelectedIndex == 4;

                switch (cmbViewOptions.SelectedIndex)
                {
                    case 0:
                        currentDataGridView = dgvBorrowDetails;
                        break;
                    case 1:
                        currentDataGridView = dgvReturnDetails;
                        break;
                    case 2:
                        currentDataGridView = dgvViolationRecords;
                        break;
                    case 3:
                        currentDataGridView = dgvInventory;
                        break;
                    case 4:
                        currentDataGridView = dgvStudents;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDataGridView(DataGridView dgv, Graphics g, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                Bitmap bitmap = new Bitmap(dgv.Width, dgv.Height);
                dgv.DrawToBitmap(bitmap, new Rectangle(0, 0, dgv.Width, dgv.Height));
                g.DrawImage(bitmap, leftMargin, yPos);
                yPos += bitmap.Height + 20; // Adjust space between DataGridView and next section
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing the DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintViolationRecords(Graphics g, PrintPageEventArgs e, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT [Student Name], Violation, [Penalty Status] FROM LaboratoryPenalties";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Define column positions
                    float column1Width = 200;
                    float column2Width = 300;
                    float marginLeft = leftMargin;

                    // Define fonts
                    Font contentFont = new Font("Arial", 10);

                    while (reader.Read())
                    {
                        string studentName = reader["Student Name"].ToString();
                        string violation = reader["Violation"].ToString();
                        string penaltyStatus = reader["Penalty Status"].ToString();

                        g.DrawString($"Student:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(studentName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Violation:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(violation, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Penalty Status:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(penaltyStatus, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight * 2; // Add extra space before the next record
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the violation records report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintInventoryList(Graphics g, PrintPageEventArgs e, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Updated query to include CategoryName by joining the Category table
                    string query = "SELECT i.[Apparatus Name], i.[Model Number], i.Brand, i.Status, i.Quantity, c.[CategoryName] " +
                                   "FROM Inventory i " +
                                   "JOIN Category c ON i.CategoryID = c.CategoryID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Define column positions
                    float column1Width = 150;
                    float column2Width = 150;
                    float column3Width = 150;
                    float marginLeft = leftMargin;

                    // Define fonts
                    Font contentFont = new Font("Arial", 10);

                    while (reader.Read())
                    {
                        string apparatusName = reader["Apparatus Name"].ToString();
                        string model = reader["Model Number"].ToString();
                        string brand = reader["Brand"].ToString();
                        string status = reader["Status"].ToString();
                        string quantity = reader["Quantity"].ToString();
                        string categoryName = reader["CategoryName"].ToString(); // Get the Category Name

                        // Print apparatus details
                        g.DrawString($"Apparatus Name:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(apparatusName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);
                        yPos += lineHeight;

                        g.DrawString($"Model:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(model, contentFont, Brushes.Black, marginLeft + column2Width, yPos);
                        yPos += lineHeight;

                        g.DrawString($"Brand:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(brand, contentFont, Brushes.Black, marginLeft + column2Width, yPos);
                        yPos += lineHeight;

                        g.DrawString($"Status:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(status, contentFont, Brushes.Black, marginLeft + column2Width, yPos);
                        yPos += lineHeight;

                        g.DrawString($"Quantity:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(quantity, contentFont, Brushes.Black, marginLeft + column2Width, yPos);
                        yPos += lineHeight;

                        // Print Category Name
                        g.DrawString($"Category:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(categoryName, contentFont, Brushes.Black, marginLeft + column2Width, yPos);
                        yPos += lineHeight * 2; // Add extra space before the next record
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the inventory list report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintStudentsList(Graphics g, PrintPageEventArgs e, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Students";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Define column positions
                    float column1Width = 200;
                    float column2Width = 200;
                    float marginLeft = leftMargin;

                    // Define fonts
                    Font contentFont = new Font("Arial", 10);

                    while (reader.Read())
                    {
                        string name = reader["Student_Name"].ToString();
                        string id = reader["ID_Number"].ToString();
                        string email = reader["Email_Address"].ToString();
                        string contact = reader["Contact_No"].ToString();
                        string program = reader["Program"].ToString();
                        string department = reader["Department"].ToString();
                      

                        g.DrawString($"Name:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(name, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"ID:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(id, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Email:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(email, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Contact:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(contact, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Program:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(program, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Department:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(department, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        yPos += lineHeight * 2; // Add extra space before the next record
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the students list report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintBorrowedItems(Graphics g, PrintPageEventArgs e, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BorrowReturnTransaction WHERE Date_Returned IS NULL AND Remarks IS NULL AND Quantity_Returned is NULL";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Define column positions
                    float column1Width = 200;
                    float column2Width = 200;
                    float marginLeft = leftMargin;

                    // Define fonts
                    Font contentFont = new Font("Arial", 10);

                    while (reader.Read())
                    {
                        string studentName = reader["Student_Name"].ToString();
                        string apparatusName = reader["Apparatus_Name"].ToString();
                        string borrowDate = reader["Borrow_Date"].ToString();
                        string dueDate = reader["Due_Date"].ToString();

                        g.DrawString($"Student:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(studentName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Apparatus:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(apparatusName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Borrow Date:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(borrowDate, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Due Date:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(dueDate, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight * 2; // Add extra space before the next record
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the borrowed items report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReturnedItems(Graphics g, PrintPageEventArgs e, ref float yPos, float leftMargin, float lineHeight)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BorrowReturnTransaction WHERE Date_Returned IS NOT NULL AND Remarks IS NOT NULL AND Quantity_Returned is NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Define column positions
                    float column1Width = 200;
                    float column2Width = 200;
                    float marginLeft = leftMargin;

                    // Define fonts
                    Font contentFont = new Font("Arial", 10);

                    while (reader.Read())
                    {
                        string studentName = reader["Student_Name"].ToString();
                        string apparatusName = reader["Apparatus_Name"].ToString();
                        string borrowDate = reader["Borrow_Date"].ToString();
                        string dueDate = reader["Due_Date"].ToString();
                        string returnDate = reader["Date_Returned"].ToString();

                        g.DrawString($"Student:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(studentName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Apparatus:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(apparatusName, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Borrow Date:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(borrowDate, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Due Date:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(dueDate, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight;

                        g.DrawString($"Return Date:", contentFont, Brushes.Black, marginLeft, yPos);
                        g.DrawString(returnDate, contentFont, Brushes.Black, marginLeft + column1Width, yPos);

                        yPos += lineHeight * 2; // Add extra space before the next record
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the returned items report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float yPos = e.MarginBounds.Top + 40; // Add top margin
                float leftMargin = e.MarginBounds.Left;
                float lineHeight = new Font("Courier New", 10).GetHeight(e.Graphics);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);

                if (currentDataGridView != null)
                {
                    string headerTitle = GetHeaderTitle(currentDataGridView);

                    // Measure the header title to center it
                    SizeF headerSize = e.Graphics.MeasureString(headerTitle, headerFont);
                    float headerXPos = (e.PageBounds.Width - headerSize.Width) / 2;

                    // Draw the header title centered
                    e.Graphics.DrawString(headerTitle, headerFont, Brushes.Black, headerXPos, yPos);

                    yPos += headerSize.Height + 20; // Adjust space between header and content

                    // Add specific report printing methods based on the DataGridView being used
                    if (currentDataGridView == dgvViolationRecords)
                    {
                        PrintViolationRecords(e.Graphics, e, ref yPos, leftMargin, lineHeight);
                    }
                    else if (currentDataGridView == dgvInventory)
                    {
                        PrintInventoryList(e.Graphics, e, ref yPos, leftMargin, lineHeight);
                    }
                    else if (currentDataGridView == dgvStudents)
                    {
                        PrintStudentsList(e.Graphics, e, ref yPos, leftMargin, lineHeight);
                    }
                    else if (currentDataGridView == dgvBorrowDetails)
                    {
                        PrintBorrowedItems(e.Graphics, e, ref yPos, leftMargin, lineHeight);
                    }
                    else if (currentDataGridView == dgvReturnDetails)
                    {
                        PrintReturnedItems(e.Graphics, e, ref yPos, leftMargin, lineHeight);
                    }

                    // Debugging output
                    Debug.WriteLine($"yPos: {yPos}, Margin Bottom: {e.MarginBounds.Bottom}");

                    // Check if more pages are needed
                    if (yPos + lineHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true; // Request additional pages
                    }
                    else
                    {
                        e.HasMorePages = false; // No more pages needed
                    }
                }
                else
                {
                    e.HasMorePages = false; // Ensure no more pages are generated if no DataGridView is set
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
                {
                    Document = printDocument1
                };
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while showing the print preview: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GetHeaderTitle(DataGridView dgv)
        {
            switch (dgv.Name)
            {
                case "dgvBorrowDetails":
                    return "Borrowed Items";
                case "dgvReturnDetails":
                    return "Returned Items";
                case "dgvViolationRecords":
                    return "Violation Records";
                case "dgvInventory":
                    return "Inventory List";
                case "dgvStudents":
                    return "Student List";
                default:
                    return "Report";
            }
        }

        
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (currentDataGridView == null)
            {
                MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportDataToExcel(saveFileDialog.FileName, currentDataGridView);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportDataToExcel(string filePath, DataGridView dgv)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                // Header
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                }

                // Data
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value;
                    }
                }

                package.SaveAs(new FileInfo(filePath));
                MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Open an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImportDataFromExcel(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while importing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }*/

       /* private void ImportDataFromExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(currentDataGridView);

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataGridViewRow.Cells[col - 1].Value = worksheet.Cells[row, col].Value;
                    }

                    currentDataGridView.Rows.Add(dataGridViewRow);
                }
            }

            MessageBox.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/



        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            Dashboard.formRestrict = 0;
            PenaltiesRecords.detailRestrict = 0;
        }
        private void cmbViewOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            // Confirm with the user before printing all reports
            DialogResult result = MessageBox.Show(
                "You are about to print all records from the database tables. Are you sure you want to proceed?",
                "Confirm Print All",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(printAllDocuments_PrintPage);

                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc
                };

                previewDialog.ShowDialog();
            }
        }

        private void printAllDocuments_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float lineHeight = new Font("Arial", 10).GetHeight(e.Graphics);

            // Print each section with headers and detailed descriptions
            PrintSection(e.Graphics, "Borrowed Items", GetBorrowedItems(), ref yPos, leftMargin, e.MarginBounds.Right, lineHeight);
            PrintSection(e.Graphics, "Returned Items", GetReturnedItems(), ref yPos, leftMargin, e.MarginBounds.Right, lineHeight);
            PrintSection(e.Graphics, "Violation Records", GetViolationRecords(), ref yPos, leftMargin, e.MarginBounds.Right, lineHeight);
            PrintSection(e.Graphics, "Inventory List", GetInventoryList(), ref yPos, leftMargin, e.MarginBounds.Right, lineHeight);
            PrintSection(e.Graphics, "Students List", GetStudentsList(), ref yPos, leftMargin, e.MarginBounds.Right, lineHeight);

            e.HasMorePages = false;
        }

        private void PrintSection(Graphics g, string header, DataTable data, ref float yPos, float leftMargin, float rightMargin, float lineHeight)
        {
            try
            {
                // Print header
                g.DrawString(header, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
                yPos += lineHeight * 2;

                // Print data
                foreach (DataRow row in data.Rows)
                {
                    string line = string.Join(", ", row.ItemArray);
                    g.DrawString(line, new Font("Arial", 10), Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing the section: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable GetBorrowedItems()
        {
            return GetData("SELECT * FROM BorrowReturnTransaction WHERE Date_Returned IS NULL AND Remarks is NULL AND Quantity_Returned is NULL");
        }

        private DataTable GetReturnedItems()
        {
            return GetData("SELECT * FROM BorrowReturnTransaction WHERE Date_Returned IS NOT NULL AND Remarks is NOT NULL AND Quantity_Returned is NOT NULL");
        }

        private DataTable GetViolationRecords()
        {
            return GetData("SELECT * FROM LaboratoryPenalties");
        }

        private DataTable GetInventoryList()
        {
            return GetData("SELECT * FROM Inventory");
        }

        private DataTable GetStudentsList()
        {
            return GetData("SELECT * FROM Students");
        }

        private DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }


    }

}   