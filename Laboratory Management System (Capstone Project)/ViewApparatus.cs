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

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class ViewApparatus : Form
    {
        private const string PlaceholderText = "000.00";
        public ViewApparatus()
        {
            InitializeComponent();
            tbPrice.Enter += tbPrice_Enter;
            tbPrice.Leave += tbPrice_Leave;

            // Set the initial placeholder text
            SetPlaceholderText();
        }

        private void ViewApparatus_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            // SQL Connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ApparatusList";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvApparatusList.DataSource = ds.Tables[0];
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
            if (dgvApparatusList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // Retrieves the PK
                id = int.Parse(dgvApparatusList.Rows[e.RowIndex].Cells[0].Value.ToString());
                // MessageBox.Show(dgvApparatusList.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ApparatusList where ApparatusID= " + id + "";
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
            tbLifeSpan.Text = ds.Tables[0].Rows[0][8].ToString(); // New field for Life Span
            tbRemarks.Text = ds.Tables[0].Rows[0][9].ToString(); // New field for Remarks
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

        private void tbAppaSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (tbAppaSearch.Text != "")
            {
                cmd.CommandText = "select * from ApparatusList where [Apparatus Name] LIKE @SearchText + '%' OR [Model Number] LIKE @SearchText + '%' " +
                                  "OR [Date Purchased] LIKE @SearchText + '%' OR [Price] LIKE @SearchText + '%' OR [Brand] LIKE @SearchText + '%' " +
                                  "OR [Status] LIKE @SearchText + '%' OR [Quantity] LIKE @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", tbAppaSearch.Text);
            }
            else
            {
                cmd.CommandText = "select * from ApparatusList";
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvApparatusList.DataSource = ds.Tables[0];
            }
            else
            {
                dgvApparatusList.DataSource = null; // Clear the DataGridView
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbAppaSearch.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The Data will be updated\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String appa_name = tbAppName.Text;
                String model_num = tbModelNum.Text;
                String date_purch = tbPurchaseDate.Text;
                Decimal price = Decimal.Parse(tbPrice.Text);
                String brand = tbBrand.Text;
                String status = cbEditStatus.Text;
                Int64 quantity = Int64.Parse(tbQuantity.Text);
                String life_span = tbLifeSpan.Text;

                // Automatically set remarks to "Out of Stock" if quantity is 0
                String remarks = (quantity == 0) ? "Out of Stock" : tbRemarks.Text;

                // SQL Connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update ApparatusList set [Apparatus Name] = '" + appa_name + "',  [Model Number] ='" + model_num + "', [Date Purchased] = '" + date_purch + "' ,[Price] =" + price + " ,[Brand] = '" + brand + "' ,[Status] = '" + status + "' ,[Quantity] =" + quantity + " ,[Life Span] = '" + life_span + "' ,[Remarks] = '" + remarks + "' where ApparatusID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // needs further debugging
                ViewApparatus_Load(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The Data will be deleted\n\nPlease click on the RETURN button to update the Apparatus List. Confirm?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // SQL Connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from ApparatusList where ApparatusID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // needs further debugging
                ViewApparatus_Load(this, null);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}