using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Store.Utilisite
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("asmaazaid921@gmail.com", "vslh ufzh mwgp zdgv")
            };
            var mailMessage = new MailMessage(from: "asmaazaid921@gmail.com", to: email, subject: subject, body: htmlMessage)
            {
                IsBodyHtml = true,
            };
            return client.SendMailAsync(mailMessage);
           
            //throw  NotImplementedException();
        }
    }
}
