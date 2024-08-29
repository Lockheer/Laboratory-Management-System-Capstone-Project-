using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class AddApparatus : Form
    {
        private string PlaceHolderText = "000.00";
        public AddApparatus()
        {
            InitializeComponent();
            tbPrice.Enter += tbPrice_Enter;
            tbPrice.Leave += tbPrice_Leave;
            // Set the initial placeholder text
            SetPlaceholderText();
        }

        //Press/Navigate event
        private void SetPlaceholderText()
        {
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                tbPrice.Text = PlaceHolderText;
                tbPrice.ForeColor = Color.Gray;
            }
            else
            {
                tbPrice.ForeColor = Color.Black;
            }
        }

        private void tbPrice_Enter(object sender, EventArgs e)
        {
            if (tbPrice.Text == PlaceHolderText)
            {
                tbPrice.Text = "";
                tbPrice.ForeColor = Color.Black;
            }

        }

        private void tbPrice_Leave(object sender, EventArgs e)
        {
            SetPlaceholderText();

            string value = tbPrice.Text;
            bool thereIsDecimal = false;

            foreach (char c in value)
            {
                if (c == '.')
                {
                    thereIsDecimal = true;
                }
            }
            if (thereIsDecimal == false && tbPrice.Text != "")
            {
                tbPrice.Text = value + ".00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbAppaName.Text != "" && tbModelNum.Text != "" && cbStatus.Text != "" && tbQuantity.Text != "")
            {
                String appa_name = tbAppaName.Text;
                String model_num = tbModelNum.Text;
                String date_purch = dtpDatePurchased.Text;
                Decimal price = Decimal.Parse(tbPrice.Text);
                String brand = tbBrand.Text;
                String status = cbStatus.Text;
                Int64 quantity = Int64.Parse(tbQuantity.Text);
                String life_span = tbLifeSpan.Text;
                String remarks = tbRemarks.Text;

                SqlConnection connect = new SqlConnection();
                connect.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand command = new SqlCommand();
                command.Connection = connect;

                connect.Open();
                command.CommandText = "INSERT INTO Inventory ([Apparatus Name], [Model Number], [Date Purchased], [Price], [Brand], [Status], [Quantity], [Life Span], [Remarks]) " +
                                      "VALUES (@AppaName, @ModelNum, @DatePurch, @Price, @Brand, @Status, @Quantity, @LifeSpan, @Remarks)";
                command.Parameters.AddWithValue("@AppaName", appa_name);
                command.Parameters.AddWithValue("@ModelNum", model_num);
                command.Parameters.AddWithValue("@DatePurch", date_purch);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@LifeSpan", life_span);
                command.Parameters.AddWithValue("@Remarks", remarks);

                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Apparatus data has been saved and added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbAppaName.Clear();
                tbModelNum.Clear();
                tbPrice.Clear();
                tbBrand.Clear();
                cbStatus.ResetText();
                tbQuantity.Clear();
                dtpDatePurchased.Value = DateTime.Now;
                tbLifeSpan.Clear();
                tbRemarks.Clear();
            }
            else
            {
                MessageBox.Show("Please fill up the empty fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("This will remove any UNSAVED data\nDo you still want to cancel this task?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                //Dashboard.formRestrict = 0;
            }


        }

        private void btnXMark_Click(object sender, EventArgs e)
        {
            this.Close();
            //Dashboard.formRestrict = 0;
        }

        private void lnklblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbAppaName.Clear();
            tbModelNum.Clear();
            tbPrice.Clear();
            tbBrand.Clear();
            cbStatus.ResetText();
            tbQuantity.Clear();
            dtpDatePurchased.Value = DateTime.Now;
            cbStatus.ResetText();
            tbLifeSpan.Clear();
            tbRemarks.Clear();

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage(new FileInfo(ofd.FileName)))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            int rowCount = worksheet.Dimension.Rows;

                            using (SqlConnection connect = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"))
                            {
                                connect.Open();
                                for (int row = 2; row <= rowCount; row++)
                                {
                                    // Read data from Excel
                                    string appa_name = worksheet.Cells[row, 1].Text;
                                    string model_num = worksheet.Cells[row, 2].Text;
                                    string date_purch = worksheet.Cells[row, 3].Text;
                                    decimal price = decimal.Parse(worksheet.Cells[row, 4].Text);
                                    string brand = worksheet.Cells[row, 5].Text;
                                    string status = worksheet.Cells[row, 6].Text;
                                    long quantity = long.Parse(worksheet.Cells[row, 7].Text);
                                    string life_span = worksheet.Cells[row, 8].Text;
                                    string remarks = worksheet.Cells[row, 9].Text;

                                    // Insert data into the database
                                    SqlCommand command = new SqlCommand("INSERT INTO Inventory ([Apparatus Name], [Model Number], [Date Purchased], [Price], [Brand], [Status], [Quantity], [Life Span], [Remarks]) " +
                                        "VALUES (@AppaName, @ModelNum, @DatePurch, @Price, @Brand, @Status, @Quantity, @LifeSpan, @Remarks)", connect);
                                    command.Parameters.AddWithValue("@AppaName", appa_name);
                                    command.Parameters.AddWithValue("@ModelNum", model_num);
                                    command.Parameters.AddWithValue("@DatePurch", date_purch);
                                    command.Parameters.AddWithValue("@Price", price);
                                    command.Parameters.AddWithValue("@Brand", brand);
                                    command.Parameters.AddWithValue("@Status", status);
                                    command.Parameters.AddWithValue("@Quantity", quantity);
                                    command.Parameters.AddWithValue("@LifeSpan", life_span);
                                    command.Parameters.AddWithValue("@Remarks", remarks);

                                    command.ExecuteNonQuery();
                                }

                                connect.Close();
                            }

                            MessageBox.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during import: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
