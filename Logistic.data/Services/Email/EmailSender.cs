using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Logistic.API.Service
{
    public class EmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            SmtpClient smtp = new SmtpClient
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_config["Email:User"], _config["Email:Password"]),
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            MailMessage m = new MailMessage();
            m.From = new MailAddress(_config["Email:User"], "Logsitic");
            m.To.Add(new MailAddress(email));
            m.Body = string.Format(message);
            m.Subject = string.Format(subject);

            return Task.Factory.StartNew(() => { smtp.Send(m); });
        }
    }
}
