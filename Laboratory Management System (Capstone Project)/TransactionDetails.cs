using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class TransactionDetails : Form
    {
        private DataGridView currentDataGridView;

        public TransactionDetails()
        {
            InitializeComponent();
        }

        private void TransactionDetails_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Load Borrowed Items
                cmd.CommandText = "select * from BorrowReturnTransaction where Date_Returned is NULL AND Remarks is NULL";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBorrowDetails.DataSource = ds.Tables[0];

                // Load Returned Items
                cmd.CommandText = "select * from BorrowReturnTransaction where Date_Returned is not NULL AND Remarks is not NULL";
                SqlDataAdapter da01 = new SqlDataAdapter(cmd);
                DataSet ds01 = new DataSet();
                da01.Fill(ds01);
                dgvReturnDetails.DataSource = ds01.Tables[0];

                // Load Violation Records
                cmd.CommandText = "Select * from LaboratoryPenalties";
                SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                DataSet violds = new DataSet();
                dataAdapt.Fill(violds);
                dgvViolationRecords.DataSource = violds.Tables[0];

                // Load Apparatus List
                cmd.CommandText = "Select * from Inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                adapter.Fill(set);
                dgvInventory.DataSource = set.Tables[0];

                // Load Students
                cmd.CommandText = "Select * from Students";
                SqlDataAdapter adapterStud = new SqlDataAdapter(cmd);
                DataSet setStud = new DataSet();
                adapterStud.Fill(setStud);
                dgvStudents.DataSource = setStud.Tables[0];

                // Set up ComboBox
                cmbViewOptions.Items.Add("Borrowed Items");
                cmbViewOptions.Items.Add("Returned Items");
                cmbViewOptions.Items.Add("Violation Records");
                cmbViewOptions.Items.Add("Apparatus List");
                cmbViewOptions.Items.Add("Student List");
                cmbViewOptions.SelectedIndex = 0; // Default selection

                // Display the default DataGridView
                DisplayDataGridView();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DisplayDataGridView()
        {
            try
            {
                switch (cmbViewOptions.SelectedIndex)
                {
                    case 0: // Borrowed Items
                        lblBorrow.Visible = true;
                        dgvBorrowDetails.Visible = true;
                        lblReturn.Visible = false;
                        dgvReturnDetails.Visible = false;
                        lblViolation.Visible = false;
                        dgvViolationRecords.Visible = false;
                        lblApparatus.Visible = false;
                        dgvInventory.Visible = false;
                        lblStudents.Visible = false;
                        dgvStudents.Visible = false;
                        currentDataGridView = dgvBorrowDetails;
                        break;
                    case 1: // Returned Items
                        lblBorrow.Visible = false;
                        dgvBorrowDetails.Visible = false;
                        lblReturn.Visible = true;
                        dgvReturnDetails.Visible = true;
                        lblViolation.Visible = false;
                        dgvViolationRecords.Visible = false;
                        lblApparatus.Visible = false;
                        dgvInventory.Visible = false;
                        lblStudents.Visible = false;
                        dgvStudents.Visible = false;
                        currentDataGridView = dgvReturnDetails;
                        break;
                    case 2: // Violation Records
                        lblBorrow.Visible = false;
                        dgvBorrowDetails.Visible = false;
                        lblReturn.Visible = false;
                        dgvReturnDetails.Visible = false;
                        lblViolation.Visible = true;
                        dgvViolationRecords.Visible = true;
                        lblApparatus.Visible = false;
                        dgvInventory.Visible = false;
                        lblStudents.Visible = false;
                        dgvStudents.Visible = false;
                        currentDataGridView = dgvViolationRecords;
                        break;
                    case 3: // Apparatus List
                        lblBorrow.Visible = false;
                        dgvBorrowDetails.Visible = false;
                        lblReturn.Visible = false;
                        dgvReturnDetails.Visible = false;
                        lblViolation.Visible = false;
                        dgvViolationRecords.Visible = false;
                        lblApparatus.Visible = true;
                        dgvInventory.Visible = true;
                        lblStudents.Visible = false;
                        dgvStudents.Visible = false;
                        currentDataGridView = dgvInventory;
                        break;
                    case 4: // Student List
                        lblBorrow.Visible = false;
                        dgvBorrowDetails.Visible = false;
                        lblReturn.Visible = false;
                        dgvReturnDetails.Visible = false;
                        lblViolation.Visible = false;
                        dgvViolationRecords.Visible = false;
                        lblApparatus.Visible = false;
                        dgvInventory.Visible = false;
                        lblStudents.Visible = true;
                        dgvStudents.Visible = true;
                        currentDataGridView = dgvStudents;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while displaying the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (currentDataGridView != null)
                {
                    Bitmap bitmap = new Bitmap(currentDataGridView.Width, currentDataGridView.Height);
                    currentDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, currentDataGridView.Width, currentDataGridView.Height));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                }
                else
                {
                    e.Graphics.DrawString("No data available to print.", new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the print document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard.formRestrict = 0;
            PenaltiesRecords.detailRestrict = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbViewOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show(
                "You are about to print all records from the database tables. Are you sure you want to proceed?",
                "Confirm Print All",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += new PrintPageEventHandler(PrintAllDocument_PrintPage);

                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = printDocument;

                    printPreviewDialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void PrintAllDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float yPos = 0;
                int pageNumber = 0;

                //manually printing the gridviews
                foreach (DataGridView dgv in new[] { dgvBorrowDetails, dgvReturnDetails, dgvViolationRecords, dgvInventory, dgvStudents })
                {
                    if (dgv.Visible) // Check if dataGridview is visible
                    {
                        // Create a Bitmap and draw it to the page
                        Bitmap bitmap = new Bitmap(dgv.Width, dgv.Height);
                        dgv.DrawToBitmap(bitmap, new Rectangle(0, 0, dgv.Width, dgv.Height));

                        e.Graphics.DrawImage(bitmap, 0, yPos);

                        yPos += bitmap.Height;

                        // Add page number if needed
                        pageNumber++;
                    }
                }

                // Indicate that more pages are available
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the print document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //exporting existing data from the gridviews using "Export to Excel" strategy
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
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 

                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                            //creates the sheet headers
                            for (int i = 0; i < currentDataGridView.Columns.Count; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = currentDataGridView.Columns[i].HeaderText;
                            }

                            //adding of data using count methodology
                            for (int i = 0; i < currentDataGridView.Rows.Count; i++)
                            {
                                for (int j = 0; j < currentDataGridView.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1].Value = currentDataGridView.Rows[i].Cells[j].Value;
                                }
                            }

                            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fileInfo);

                            MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                            DataTable dataTable = new DataTable();

                            // Add columns
                            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                            {
                                dataTable.Columns.Add(firstRowCell.Text);
                            }

                            // Add rows
                            for (int rowNum = 2; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                            {
                                var wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                                DataRow row = dataTable.NewRow();

                                foreach (var cell in wsRow)
                                {
                                    row[cell.Start.Column - 1] = cell.Text;
                                }

                                dataTable.Rows.Add(row);
                            }

                            // Assuming the data is being imported to the currently visible DataGridView
                            currentDataGridView.DataSource = dataTable;
                        }

                        MessageBox.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while importing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}