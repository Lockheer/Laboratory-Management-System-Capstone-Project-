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
using System.Runtime.Remoting.Contexts;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class InventoryList : Form
    {
        private List<string> lifeSpanSuggestions = new List<string> { "Years", "Months", "Days" };
        private ListBox suggestionBox;

        private const string PlaceholderText = "000.00";
        public InventoryList()
        {
            InitializeComponent();
            tbPrice.Enter += tbPrice_Enter;
            tbPrice.Leave += tbPrice_Leave;
            tbLifeSpan.TextChanged += tbLifeSpan_TextChanged;
            suggestionBox.Click += SuggestionBox_Click;
            InitializeSuggestionBox();
            SetPlaceholderText();
        }

        private void ViewApparatus_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgvApparatusList.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSuggestionBox()
        {
            suggestionBox = new ListBox
            {
                Visible = false,
                Width = tbLifeSpan.Width
            };
            this.Controls.Add(suggestionBox);
            suggestionBox.BringToFront();
        }




        // Press/Navigate event
        private void SetPlaceholderText()
        {
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                tbPrice.Text = PlaceholderText;
                tbPrice.ForeColor = Color.Gray;
            }
        }

        private void tbPrice_Enter(object sender, EventArgs e)
        {
            if (tbPrice.Text == PlaceholderText)
            {
                tbPrice.Text = "";
                tbPrice.ForeColor = Color.Black;
            }
        }

        private void tbPrice_Leave(object sender, EventArgs e)
        {
            SetPlaceholderText();
        }

        // Global variable to get the primary key ID from the database towards the form
        int id;
        Int64 rowid;

        private void dgvApparatusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvApparatusList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(dgvApparatusList.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE ApparatusID = @ApparatusID", con))
                    {
                        cmd.Parameters.AddWithValue("@ApparatusID", id);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                        tbAppName.Text = ds.Tables[0].Rows[0][1].ToString();
                        tbModelNum.Text = ds.Tables[0].Rows[0][2].ToString();
                        tbPurchaseDate.Text = ds.Tables[0].Rows[0][3].ToString();
                        tbPrice.Text = ds.Tables[0].Rows[0][4].ToString();
                        tbBrand.Text = ds.Tables[0].Rows[0][5].ToString();
                        cbEditStatus.Text = ds.Tables[0].Rows[0][6].ToString();
                        tbQuantity.Text = ds.Tables[0].Rows[0][7].ToString();
                        tbLifeSpan.Text = ds.Tables[0].Rows[0][8].ToString();
                        tbRemarks.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            // Sets back to 0 to prevent restriction from occurring
            // Dashboard.formRestrict = 0;
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbAppaSearch.Clear();
            panel2.Visible = false;
            cbStatusFilter.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("The Data will be updated\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string appa_name = tbAppName.Text;
                    string model_num = string.IsNullOrEmpty(tbModelNum.Text) ? "N/A" : tbModelNum.Text;
                    string date_purch = tbPurchaseDate.Text;
                    decimal price = Decimal.Parse(tbPrice.Text);
                    string brand = tbBrand.Text;
                    string status = cbEditStatus.Text;
                    long quantity = Int64.Parse(tbQuantity.Text);
                    string life_span = tbLifeSpan.Text;
                    string remarks = (quantity == 0) ? "Out of Stock" : tbRemarks.Text;

                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Inventory SET [Apparatus Name] = @ApparatusName, [Model Number] = @ModelNum, [Date Purchased] = @DatePurchased, [Price] = @Price, [Brand] = @Brand, [Status] = @Status, [Quantity] = @Quantity, [Life Span] = @LifeSpan, [Remarks] = @Remarks WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusName", appa_name);
                            cmd.Parameters.AddWithValue("@ModelNum", model_num);
                            cmd.Parameters.AddWithValue("@DatePurchased", date_purch);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Brand", brand);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@LifeSpan", life_span);
                            cmd.Parameters.AddWithValue("@Remarks", remarks);
                            cmd.Parameters.AddWithValue("@ApparatusID", rowid);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    ViewApparatus_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusID", rowid);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    ViewApparatus_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tbLifeSpan_TextChanged(object sender, EventArgs e)
        {
            string query = tbLifeSpan.Text.ToLower();
            var filteredSuggestions = lifeSpanSuggestions.Where(x => x.ToLower().Contains(query)).ToList();

            if (filteredSuggestions.Count > 0)
            {
                suggestionBox.Items.Clear();
                suggestionBox.Items.AddRange(filteredSuggestions.ToArray());
                suggestionBox.Location = new Point(tbLifeSpan.Location.X, tbLifeSpan.Location.Y + tbLifeSpan.Height);
                suggestionBox.Visible = true;
            }
            else
            {
                suggestionBox.Visible = false;
            }

        }
        private void SuggestionBox_Click(object sender, EventArgs e)
        {
            if (suggestionBox.SelectedItem != null)
            {
                tbLifeSpan.Text = suggestionBox.SelectedItem.ToString();
                suggestionBox.Visible = false;
            }
        }

        //filter by status
        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FilterApparatusList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering by status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //search textbox
        private void tbAppaSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FilterApparatusList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Method for combine or individual searching
        private void FilterApparatusList()
        {
            string searchQuery = tbAppaSearch.Text.Trim();
            string statusFilter = cbStatusFilter.SelectedItem?.ToString();

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Inventory WHERE 1=1");

            if (!string.IsNullOrEmpty(statusFilter))
            {
                queryBuilder.Append(" AND [Status] = @Status");
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                queryBuilder.Append(" AND ([Apparatus Name] LIKE @SearchText + '%' OR [Model Number] LIKE @SearchText + '%' " +
                                    "OR [Date Purchased] LIKE @SearchText + '%' OR [Price] LIKE @SearchText + '%' OR [Brand] LIKE @SearchText + '%' " +
                                    "OR [Quantity] LIKE @SearchText + '%' OR [Life Span] LIKE @SearchText + '%' OR [Remarks] LIKE @SearchText + '%')");
            }

            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con))
                {
                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        cmd.Parameters.AddWithValue("@Status", statusFilter);
                    }

                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", searchQuery);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dgvApparatusList.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvApparatusList.Rows.Count > 0)
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "InventoryList.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                // Set the license context for EPPlus
                                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                                // Create a worksheet
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Inventory List");

                                // Load DataGridView data into DataTable
                                DataTable dt = new DataTable();

                                // Add columns
                                foreach (DataGridViewColumn column in dgvApparatusList.Columns)
                                {
                                    dt.Columns.Add(column.HeaderText, typeof(string));
                                }

                                // Add rows
                                foreach (DataGridViewRow row in dgvApparatusList.Rows)
                                {
                                    dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString() ?? "").ToArray());
                                }

                                // Load data into worksheet
                                worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                                // Format the header
                                using (ExcelRange headerRange = worksheet.Cells[1, 1, 1, dt.Columns.Count])
                                {
                                    headerRange.Style.Font.Bold = true;
                                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                    headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    headerRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    headerRange.AutoFitColumns();
                                }

                                // Auto-fit all columns
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                                // Save the Excel file
                                FileInfo fi = new FileInfo(sfd.FileName);
                                excelPackage.SaveAs(fi);

                                MessageBox.Show("Data Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }



}