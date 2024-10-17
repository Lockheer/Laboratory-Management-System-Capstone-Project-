using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class SendingForm : Form
    {
        public string r;
        public string m;
        public bool finish = false;
        public bool sentFailed = false;
        public SendingForm(string Recipient, string MessageContent)
        {
            InitializeComponent();
            r = Recipient;
            m = MessageContent;
            Thread send = new Thread(new ThreadStart(sending));
            send.Start();
            btnOk.Visible = false;
            lblSending.Left = 170;

            UIHelper.SetGradientBackground(this, Color.FromArgb(5, 21, 101), Color.FromArgb(20, 57, 175), LinearGradientMode.Horizontal);
            UIHelper.SetRoundedCorners(btnOk, 10);
        }
        public void sending()
        {
            string smtpCredentials = "revenger45626@gmail.com";
            string smtpPassword = "Revengerkyoto45626";
            //string smtpCredentials = "matthew.larrobis21@outlook.com";
            //string smtpPassword = "MaiSakurajima21";
            string smtpRecipient = r;

            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpCredentials, smtpPassword);

            MailMessage message = new MailMessage(smtpCredentials, smtpRecipient, "Penalty/Violation Notice", m);
            message.Priority = MailPriority.High;

            // Retrieve the PenaltyID using the Email Address
            int penaltyID = GetPenaltyIDByEmail(smtpRecipient);

            try
            {
                smtpClient.Send(message);
                finish = true;

            }
            catch
            {
                sentFailed = true;
                finish = true;
            }
        }

        int interval = 0;
        private void tmrSending_Tick(object sender, EventArgs e)
        {
            if (interval == 1)
                lblSending.Text = "Sending.";
            if (interval == 16)
                lblSending.Text = "Sending..";
            if (interval == 32)
                lblSending.Text = "Sending...";
            if (interval == 48)
                interval = 0;

            interval++;

            if (pgbSending.Value <= 100)
                pgbSending.Value = 0;
            else
                pgbSending.Value += 1;



            if (finish == true)
            {
                if (sentFailed == true)
                {
                    lblSending.Text = "Message Not Sent";
                    lblSending.Left = 118;
                }
                else
                {
                    lblSending.Text = "Message Sent";
                    lblSending.Left = 150;
                }
                btnOk.Visible = true;
                pgbSending.Visible = false;
            }
        }

        private int GetPenaltyIDByEmail(string email)
        {
            int penaltyID = -1;
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"; // Replace with your actual connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PenaltyID FROM LaboratoryPenalties WHERE [Email Address] = @EmailAddress";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmailAddress", email);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        penaltyID = Convert.ToInt32(result);
                        StoreEmailDetails(penaltyID, "revenger45626@gmail.com",r, "Penalty/Violation Notice",m);
                    }
                }
            }

            return penaltyID;
        }


        private void StoreEmailDetails(int penaltyID, string sender, string recipient, string subject, string description)
        {
            string connectionString = "data source = LAPTOP-4KSPM38V; database = LabManagSys;integrated security=True"; // Replace with your actual connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO PenaltyEmails (Sender, Recipient, Subject, Mail_Description, penaltyID) " +
                               "VALUES (@Sender, @Recipient, @Subject, @MailDescription, @PenaltyID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Sender", sender);
                    cmd.Parameters.AddWithValue("@Recipient", recipient);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@MailDescription", description);
                    cmd.Parameters.AddWithValue("@PenaltyID", penaltyID);

                    cmd.ExecuteNonQuery();
                }
            }

        }



        private void btnOk_Click(object sender, EventArgs e)
        {

            GetPenaltyIDByEmail(r);
            this.Close();


        }

        private void SendingForm_Load(object sender, EventArgs e)
        {

        }


      

    }
}
