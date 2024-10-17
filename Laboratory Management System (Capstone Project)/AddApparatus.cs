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

        private List<string> categoryList = new List<string>();

        private string PlaceHolderText = "000.00";
        public AddApparatus()
        {
            InitializeComponent();
            LoadCategories();
            tbPrice.Enter += tbPrice_Enter;
            tbPrice.Leave += tbPrice_Leave;
            // Set the initial placeholder text
            SetPlaceholderText();
        }


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
        // Save button event to insert apparatus data, including the selected category
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbAppaName.Text != "" && cbStatus.Text != "" && tbQuantity.Text != "" && cbCategory.SelectedIndex != -1 || tbRemarks.Text != "")
            {
                String appa_name = tbAppaName.Text;
                String model_num = tbModelNum.Text == "" ? "N/A" : tbModelNum.Text;
                String date_purch = dtpDatePurchased.Text;
                Decimal price = Decimal.Parse(tbPrice.Text);
                String brand = tbBrand.Text;
                String status = cbStatus.Text;
                Int64 quantity = Int64.Parse(tbQuantity.Text);
                String remarks = tbRemarks.Text;
                String category_name = cbCategory.SelectedItem.ToString();

                SqlConnection connect = new SqlConnection("data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True");
                SqlCommand command = new SqlCommand();
                command.Connection = connect;

                connect.Open();

                // Retrieve CategoryID based on the selected CategoryName
                command.CommandText = "SELECT CategoryID FROM Category WHERE CategoryName = @CategoryName";
                command.Parameters.AddWithValue("@CategoryName", category_name);
                int categoryID = (int)command.ExecuteScalar();

                // Insert apparatus data with the CategoryID
                command.CommandText = "INSERT INTO Inventory ([Apparatus Name], [Model Number], [Date Purchased], [Price], [Brand], [Status], [Quantity], [CategoryID], [Remarks]) " +
                                      "VALUES (@AppaName, @ModelNum, @DatePurch, @Price, @Brand, @Status, @Quantity, @CategoryID, @Remarks)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@AppaName", appa_name);
                command.Parameters.AddWithValue("@ModelNum", model_num);
                command.Parameters.AddWithValue("@DatePurch", date_purch);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@CategoryID", categoryID);
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
                cbCategory.ResetText();
                tbRemarks.Clear();
            }
            else
            {
                MessageBox.Show("Please fill up the empty fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     

        private void btnXMark_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will remove any UNSAVED data\nDo you still want to cancel this task?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                //Sets back to 0 to prevent restriction from occuring
                //Dashboard.formRestrict = 0;
            }
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
            cbCategory.ResetText();
            tbRemarks.Clear();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

    }
}
