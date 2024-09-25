﻿using System;
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
using Laboratory_Management_System__Capstone_Project_;
using System.Drawing.Drawing2D;

namespace Laboratory_Management_System__Capstone_Project_
{


    public partial class InventoryList : Form
    {

        private List<string> categoryList = new List<string>();
        private const string PlaceholderText = "000.00";
        // Global variable to get the primary key ID from the database towards the form
        int id;
        Int64 rowid;

        public InventoryList()
        {
            InitializeComponent();
            LoadCategories();
            tbPrice.Enter += tbPrice_Enter;
            tbPrice.Leave += tbPrice_Leave;
            SetPlaceholderText();

            // UI styling
            UIHelper.SetRoundedCorners(panel2, 20);
            UIHelper.SetRoundedCorners(dgvApparatusList, 20);
            UIHelper.SetRoundedCorners(btnUpdate, 40);
            UIHelper.SetRoundedCorners(btnDelete, 40);
            UIHelper.SetGradientBackground(panel2, Color.FromArgb(11, 44, 149), Color.FromArgb(44, 84, 215), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
        }

        private void ViewApparatus_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT i.[ApparatusID], i.[Apparatus Name], i.[Model Number], i.[Date Purchased], i.[Price], i.[Brand], i.[Status], i.[Quantity], i.[Remarks], c.[CategoryName] " +
                        "FROM Inventory i " +
                        "JOIN Category c ON i.CategoryID = c.CategoryID", con))
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


            //Filter method initializing to search the Inventory by Category filtering
            try
            {
                using (SqlConnection conn = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Category", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<int, string> categories = new Dictionary<int, string>();
                    categories.Add(0, "All"); // To add an option for showing all categories

                    while (reader.Read())
                    {
                        categories.Add((int)reader["CategoryID"], reader["CategoryName"].ToString());
                    }

                    cbCategoryFilter.DataSource = new BindingSource(categories, null);
                    cbCategoryFilter.DisplayMember = "Value";
                    cbCategoryFilter.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        //Load the Categories
        private void LoadCategories()
        {
            SqlConnection connect = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True");
            SqlCommand command = new SqlCommand("SELECT CategoryName FROM Category", connect);

            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categoryList.Add(reader["CategoryName"].ToString());
            }
            connect.Close();

            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(categoryList.ToArray());
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



        private void dgvApparatusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvApparatusList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(dgvApparatusList.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;

                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT i.[ApparatusID], i.[Apparatus Name], i.[Model Number], i.[Date Purchased], i.[Price], i.[Brand], i.[Status], i.[Quantity], i.[Remarks], c.[CategoryName] " +
                        "FROM Inventory i " +
                        "JOIN Category c ON i.CategoryID = c.CategoryID " +
                        "WHERE i.[ApparatusID] = @ApparatusID", con))
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
                        tbRemarks.Text = ds.Tables[0].Rows[0][8].ToString();
                        cbCategory.Text = ds.Tables[0].Rows[0][9].ToString(); // CategoryName
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
                    string remarks = (quantity == 0) ? "Out of Stock" : tbRemarks.Text;
                    string categoryName = cbCategory.Text;

                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Inventory SET [Apparatus Name] = @ApparatusName, [Model Number] = @ModelNum, [Date Purchased] = @DatePurchased, [Price] = @Price, [Brand] = @Brand, [Status] = @Status, [Quantity] = @Quantity, [Remarks] = @Remarks, [CategoryID] = (SELECT CategoryID FROM Category WHERE CategoryName = @CategoryName) " +
                            "WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusName", appa_name);
                            cmd.Parameters.AddWithValue("@ModelNum", model_num);
                            cmd.Parameters.AddWithValue("@DatePurchased", date_purch);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Brand", brand);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Remarks", remarks);
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
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


        // Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this apparatus?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusID", rowid);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Apparatus deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewApparatus_Load(this, null); // Reload apparatus list after deletion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the apparatus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // Filter method combining search and status filter
        private void FilterApparatusList()
        {
            string searchQuery = tbAppaSearch.Text.Trim();
            string statusFilter = cbStatusFilter.SelectedItem?.ToString();

            StringBuilder queryBuilder = new StringBuilder("SELECT i.[ApparatusID], i.[Apparatus Name], i.[Model Number], i.[Date Purchased], i.[Price], i.[Brand], i.[Status], i.[Quantity], i.[Remarks], c.[CategoryName] " +
                                                           "FROM Inventory i " +
                                                           "JOIN Category c ON i.CategoryID = c.CategoryID " +
                                                           "WHERE 1=1");

            if (!string.IsNullOrEmpty(statusFilter))
            {
                queryBuilder.Append(" AND [Status] = @Status");
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                queryBuilder.Append(" AND ([Apparatus Name] LIKE @SearchText + '%' OR [Model Number] LIKE @SearchText + '%' " +
                                    "OR [Date Purchased] LIKE @SearchText + '%' OR [Price] LIKE @SearchText + '%' OR [Brand] LIKE @SearchText + '%' " +
                                    "OR [Quantity] LIKE @SearchText + '%' OR [Remarks] LIKE @SearchText + '%')");
            }

            using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
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
                if (dgvApparatusList.Rows.Count > 0) // Check if there are records to export
                {
                    using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "InventoryList.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                // Set the license context for EPPlus
                                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                                // Create a worksheet for the export
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Inventory List");

                                // Load DataGridView data into a DataTable
                                DataTable dt = new DataTable();

                                // Add columns to DataTable
                                foreach (DataGridViewColumn column in dgvApparatusList.Columns)
                                {
                                    dt.Columns.Add(column.HeaderText, typeof(string)); // Assuming all columns as string type
                                }

                                // Add rows to DataTable
                                foreach (DataGridViewRow row in dgvApparatusList.Rows)
                                {
                                    dt.Rows.Add(row.Cells.Cast<DataGridViewCell>()
                                        .Select(cell => cell.Value?.ToString() ?? string.Empty).ToArray());
                                }

                                // Load the data into the Excel worksheet starting from cell A1
                                worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                                // Format the header row
                                using (ExcelRange headerRange = worksheet.Cells[1, 1, 1, dt.Columns.Count])
                                {
                                    headerRange.Style.Font.Bold = true;
                                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                    headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    headerRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                }

                                // Auto-fit all columns
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                                // Save the file
                                FileInfo fileInfo = new FileInfo(sfd.FileName);
                                excelPackage.SaveAs(fileInfo);

                                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records available for export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryID = (int)((KeyValuePair<int, string>)cbCategoryFilter.SelectedItem).Key;
            FilterInventoryByCategory(selectedCategoryID);
        }

        private void FilterInventoryByCategory(int categoryID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    conn.Open();
                    SqlCommand cmd;
                    if (categoryID == 0) // 0 for 'All' categories
                    {
                        cmd = new SqlCommand("SELECT * FROM Inventory", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM Inventory WHERE CategoryID = @CategoryID", conn);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvApparatusList.DataSource = dt; // Assuming you're using a DataGridView to show results
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering items: " + ex.Message);
            }
        }

    }
}



/*
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
*/