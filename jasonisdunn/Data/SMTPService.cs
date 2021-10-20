using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace jasonisdunn.Data
{
    public class SMTPService
    {
        public async Task Send(SMTP smtp)
        {
            try
            {
                var credentials = new NetworkCredential("dotnetcore@jasonisdunn.tech", "XS8ab6h*j");
                var mail = new MailMessage()
                {
                    From = new MailAddress("jasonisdunn.tech<noreply@jasonisdunn.tech>"),
                    Subject = "Website Feedback",
                    Body = EmailFormattedBody(smtp)
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("contact@jasonisdunn.tech"));
                var client = new SmtpClient()
                {
                    UseDefaultCredentials = false,
                    Host = "mail.jasonisdunn.tech",
                    Credentials = credentials,
                    Port = 587,
                    EnableSsl = false
                };
                try
                {
                   await client.SendMailAsync(mail);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        static string EmailFormattedBody(SMTP smtp)
        {
            var senderInfo = String.Format(
                "<b>From</b>: {0}<br/><b>Email</b>: {1}<br/>", smtp.Name, smtp.Email);
            return senderInfo + smtp.Message;
        }
    }
}
