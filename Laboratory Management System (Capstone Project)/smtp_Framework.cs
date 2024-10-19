using System;
using System.Net.Mail;
using System.Net;


namespace Laboratory_Management_System__Capstone_Project_
{
    internal class smtp_Framework
    {
        string domains = "smtp-mail.outlook.com";
        string UsernameCredentials = "revenger45626@gmail.com";
        string PasswordCredentials = "Revengerkyoto45626";
        public void SmtpClient(string domain = "outlook")
        {
            switch (domain) 
            {
                case "outlook":
                    domains = "smtp-mail.outlook.com";
                    break;
            }
        }
        public void SmtpCredentials(string username, string password)
        {
            UsernameCredentials = username;
            PasswordCredentials = password;
        }

        public void Send(string reciever,string subject,string mail)
        {
            SmtpClient smtp = new SmtpClient(domains, 587);

            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(UsernameCredentials, PasswordCredentials);

            MailMessage Mail = new MailMessage(UsernameCredentials, reciever, subject, mail);
            Mail.Priority = MailPriority.High;

            try
            {
                smtp.Send(Mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
        }

        

    }
}
