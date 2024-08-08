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

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class SendingForm : Form
    {
        public string r;
        public string m;
        public bool finish = false;
        public bool sentFailed = false;
        public SendingForm(string Recipient,string MessageContent)
        {
            InitializeComponent();
            r = Recipient;
            m = MessageContent;
            Thread send = new Thread(new ThreadStart(sending));
            send.Start();
            btnOk.Visible = false;
            lblSending.Left = 170;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
