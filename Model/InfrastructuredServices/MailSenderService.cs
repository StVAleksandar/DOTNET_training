using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructuredServices
{
    public class MailSenderService
    {
        private string smtp = "smtp.eng.it";
        private int port = 25;

        public void sendEmail(string subject, string mail, string sentToEmail, string sentFromEmail, string password, string sentFrom)
        {
            SmtpClient mailClient = new SmtpClient(smtp);
            mailClient.Port = port;
            mailClient.EnableSsl = true;
            mailClient.Credentials = new NetworkCredential(
                sentFromEmail, password);

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new
                MailAddress(sentFromEmail, sentFrom);
            mailMessage.To.Add(new
                MailAddress(sentToEmail));

            mailMessage.Subject = subject;
            mailMessage.Body = mail;

            try
            {
                mailClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
            }

        }
    }
}
