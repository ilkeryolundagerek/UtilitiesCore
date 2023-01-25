using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesCore
{
    public class EmailSender : IEmailSender
    {
        private string username;
        private string password;
        private string host;
        private int port;

        public EmailSender(string username, string password, string host, int port)
        {
            this.username = username;
            this.password = password;
            this.host = host;
            this.port = port;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new()
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            };
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress(username);

            SmtpClient smtp = new(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            await smtp.SendMailAsync(message);
        }
    }
}
