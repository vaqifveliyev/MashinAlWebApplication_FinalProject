﻿using MashinAl.Infastructure.Services.Abstracts;
using MashinAl.Infastructure.Services.Configurations;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MashinAl.Infastructure.Services.Concrates
{
    public class EmailService : SmtpClient, IEmailService
    {
        readonly EmailOptions options;

        public EmailService(IOptions<EmailOptions> options)
        {
            this.options = options.Value;

            this.Host = this.options.SmtpServer;
            this.Port = this.options.SmtpPort;
            this.EnableSsl = true;
            this.Credentials = new NetworkCredential(this.options.UserName, this.options.Password);
        }

        public async Task<bool> SendMailAsync(string to, string subject, string body)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(options.SmtpServer, options.SmtpPort))
                using (MailMessage message = new MailMessage())
                {
                    message.Subject = subject;
                    message.To.Add(to);
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(options.UserName, options.DisplayName);
                    message.Body = body;

                    await base.SendMailAsync(message);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

}
