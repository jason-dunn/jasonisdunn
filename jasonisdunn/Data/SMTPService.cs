using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace jasonisdunn.Data
{
    public class SMTPService
    {
        static NetworkCredential  credentials = new NetworkCredential("dotnetcore@jasonisdunn.tech", "XS8ab6h*j");
        static SmtpClient client = new SmtpClient()
        {
            UseDefaultCredentials = false,
            Host = "mail.jasonisdunn.tech",
            Credentials = credentials,
            Port = 587,
            EnableSsl = false
        };
        public async Task Send(SMTP smtp)
        {
            try
            {         
                var mail = new MailMessage()
                {
                    From = new MailAddress("jasonisdunn.tech<noreply@jasonisdunn.tech>"),
                    Subject = "Website Feedback",
                    Body = EmailFormattedBody(smtp)
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("contact@jasonisdunn.tech"));
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
                "<b>From</b>: {0}<br/><b>Email</b>: {1}<br/>", smtp.Name, smtp.EmailAddress);
            return senderInfo + smtp.Message;
        }

        public async Task SendRegister(SMTP smtp, string code)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress("jasonisdunn.tech<noreply@jasonisdunn.tech>"),
                    Subject = "Account Registration",
                    Body = RegisterFormattedBody(smtp, code)
                };
                mail.IsBodyHtml = true;
                mail.ReplyToList.Add("noreply@jasonisdunn.tech");
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(smtp.EmailAddress));
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
        static string RegisterFormattedBody(SMTP smtp, string code)
        {
            var senderInfo = String.Format(
                "<b>Your account username</b>: {0}<br/><b>Your primary email</b>: {1}<br/><b></b>{2}<br/>", smtp.Name, smtp.EmailAddress, "<br/>");
            var _Code = String.Format(
                "<b></b>{0}:<b></b> {1}<br/>", "Here is your confirmation code ", code);
            return senderInfo + System.Environment.NewLine + _Code;
        }
    }
}
