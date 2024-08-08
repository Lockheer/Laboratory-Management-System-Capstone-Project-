using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            }else
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
                command.CommandText = "INSERT INTO ApparatusList ([Apparatus Name], [Model Number], [Date Purchased], [Price], [Brand], [Status], [Quantity], [Life Span], [Remarks]) " +
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
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void AddApparatus_Load(object sender, EventArgs e)
        {

        }
    }
}
