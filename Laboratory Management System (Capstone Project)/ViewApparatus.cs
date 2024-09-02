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

        private void InventoryList_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            LoadInventoryData();
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

        private int id;
        private long rowid;

        private void dgvApparatusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvApparatusList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Retrieves the PK
                    id = int.Parse(dgvApparatusList.Rows[e.RowIndex].Cells[0].Value.ToString());
                    panel2.Visible = true;
                    LoadApparatusDetails();
                }
            }
        }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Inventory", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgvApparatusList.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApparatusDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE ApparatusID = @ApparatusID", con))
                    {
                        cmd.Parameters.AddWithValue("@ApparatusID", id);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            rowid = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
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
                        else
                        {
                            MessageBox.Show("No details found for the selected apparatus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading apparatus details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tbAppaSearch.Clear();
                panel2.Visible = false;
                cbStatusFilter.SelectedIndex = -1;
                LoadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The Data will be updated\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    string appa_name = tbAppName.Text;
                    string model_num = string.IsNullOrWhiteSpace(tbModelNum.Text) ? "N/A" : tbModelNum.Text;
                    string date_purch = tbPurchaseDate.Text;
                    decimal price = Convert.ToDecimal(tbPrice.Text);
                    string brand = tbBrand.Text;
                    string status = cbEditStatus.Text;
                    long quantity = Convert.ToInt64(tbQuantity.Text);
                    string life_span = tbLifeSpan.Text;
                    string remarks = quantity == 0 ? "Out of Stock" : tbRemarks.Text;

                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Inventory SET [Apparatus Name] = @ApparatusName, [Model Number] = @ModelNumber, [Date Purchased] = @DatePurchased, [Price] = @Price, [Brand] = @Brand, [Status] = @Status, [Quantity] = @Quantity, [Life Span] = @LifeSpan, [Remarks] = @Remarks WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusName", appa_name);
                            cmd.Parameters.AddWithValue("@ModelNumber", model_num);
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
                            con.Close();
                        }
                    }
                    LoadInventoryData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The Data will be deleted\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys; integrated security=True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE ApparatusID = @ApparatusID", con))
                        {
                            cmd.Parameters.AddWithValue("@ApparatusID", rowid);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    LoadInventoryData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tbLifeSpan_TextChanged(object sender, EventArgs e)
        {
            string query = tbLifeSpan.Text.ToLower();
            var filteredSuggestions = lifeSpanSuggestions.Where(s => s.ToLower().Contains(query)).ToList();
            suggestionBox.DataSource = filteredSuggestions;
            suggestionBox.Visible = filteredSuggestions.Any();
        }

        private void SuggestionBox_Click(object sender, EventArgs e)
        {
            if (suggestionBox.SelectedItem != null)
            {
                tbLifeSpan.Text = suggestionBox.SelectedItem.ToString();
                suggestionBox.Visible = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "InventoryList.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        ExcelWorksheet ws = excel.Workbook.Worksheets.Add("InventoryList");

                        for (int i = 1; i < dgvApparatusList.Columns.Count + 1; i++)
                        {
                            ws.Cells[1, i].Value = dgvApparatusList.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dgvApparatusList.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvApparatusList.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value = dgvApparatusList.Rows[i].Cells[j].Value;
                            }
                        }

                        ws.Cells[ws.Dimension.Address].AutoFitColumns();
                        FileInfo fi = new FileInfo(sfd.FileName);
                        excel.SaveAs(fi);
                    }
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