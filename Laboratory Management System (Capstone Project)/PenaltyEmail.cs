using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class PenaltyEmail : Form
    {
        public PenaltyEmail()
        {
            InitializeComponent();

            UIHelper.SetRoundedCorners(btnTransactDetails, 270);
            UIHelper.SetRoundedCorners(btnSendEmail, 20);
            UIHelper.MakeRoundedTextBox(tbEmailRecipient, 10);
            UIHelper.MakeRoundedTextBox(tbMessageContent, 10);

            UIHelper.SetShadow(panel1);

            UIHelper.SetRoundedCorners(btnExit, 30);
            UIHelper.SetRoundedCorners(panel1, 50);
        }

    

        private void PenaltyEmail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select [PenaltyID], [ID Number], [Student Name], [Email Address], [Penalty Issued Date], [Violation], [Penalty Condition], [Amount to be Paid], [Amount Received], [Penalty Status], [Balance] from LaboratoryPenalties";
            SqlDataAdapter DA = new SqlDataAdapter();
            DataSet DS = new DataSet();
            DA.SelectCommand = cmd; // Set the SelectCommand for the SqlDataAdapter
            DA.Fill(DS);

            dgvViewPenaltyRecords.DataSource = DS.Tables[0];
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            SendingForm sendform = new SendingForm(tbEmailRecipient.Text, tbMessageContent.Text);
            sendform.ShowDialog();

            if (tbEmailRecipient.Text == null)
            {
                MessageBox.Show("Please enter an email address.", "Missing Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbMessageContent.Text == null)
            {
                MessageBox.Show("Please enter a message description", "Missing Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        Int64 rowid;
        int ID;
        private void dgvViewPenaltyRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell and row are within the valid range
            if (e.RowIndex >= 0)
            {
                // Check if the cell value is not null or empty
                if (dgvViewPenaltyRecords.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    !string.IsNullOrWhiteSpace(dgvViewPenaltyRecords.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    string cellValue = dgvViewPenaltyRecords.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Try parsing the cell value to an integer
                    if (int.TryParse(cellValue, out ID))
                    {
                        string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True";

                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM LaboratoryPenalties WHERE PenaltyID = @ID", con);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            SqlDataAdapter DA = new SqlDataAdapter(cmd);
                            DataSet DS = new DataSet();

                            try
                            {
                                con.Open();
                                DA.Fill(DS);

                                // Checks if the query returned any results
                                if (DS.Tables[0].Rows.Count > 0)
                                {
                                    // Extracts data from the first row
                                    rowid = Int64.Parse(DS.Tables[0].Rows[0]["PenaltyID"].ToString());
                                    tbEmailRecipient.Text = DS.Tables[0].Rows[0]["Email Address"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        // Handle the case where the value is not a valid number
                        MessageBox.Show("The selected cell does not contain a valid PenaltyID.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Display an error message if the cell is empty or null
                    MessageBox.Show("The selected cell is empty. Please select a valid cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            PenaltiesRecords.detailRestrict = 0;
            PenaltiesRecords.emailFormRestrict = 0;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnTransactDetails_Click(object sender, EventArgs e)
        {
            TransactionDetails details = new TransactionDetails();
            details.Show();
        }
    }
}
