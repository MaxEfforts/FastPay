using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services
{

    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IWebHostEnvironment _environment;

        public EmailSenderService(IOptions<SmtpSettings> smtpSettings, IWebHostEnvironment environment)
        {
            _environment = environment;
            _smtpSettings = smtpSettings.Value;
        }

        #region send methods

        public void SendEmail(List<string> to, string subject, string body, string hostname = null)
        {
            if (!to.Any())
            {
                return;
            }

            MimeMessage mimeMessage = GetDefaultMailMessage(to, subject, body, hostname: hostname);
            SendMimeMessage(mimeMessage);
        }

        public async Task<Result> SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var mimeMessage = GetDefaultMailMessage(email, subject, body);

                SendMimeMessage(mimeMessage);
                return new Result() { StatusCode = 1, StatusMessage = "email is sended" };

            }
            catch (Exception ex)
            {
                return new Result() { StatusCode = 0, StatusMessage = "email not sended" };

            }
        }

        public void SendEmail(string to, string subject, string body, string hostname = null)
        {
            try
            {
                MimeMessage mimeMessage = GetDefaultMailMessage(to, subject, body, hostname: hostname);
                SendMimeMessage(mimeMessage);
            }
            catch
            {
            }
        }

        #endregion


        private void SendMimeMessage(MimeMessage mimeMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(_smtpSettings.Server, _smtpSettings.Port, false);
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(_smtpSettings.UserName, _smtpSettings.Password);
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        private MimeMessage GetDefaultMailMessage(string to, string subject, string body,
            string hostname = null)
        {
            return GetDefaultMailMessage(new List<string>() { to }, subject, body, hostname: hostname);
        }

        private MimeMessage GetDefaultMailMessage(List<string> to, string subject, string body, string hostname = null)
        {
            hostname = hostname ?? "mudaraba.sa";
            MimeMessage mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(
                _smtpSettings.SenderName ?? "Mudaraba Financial",
                _smtpSettings.SenderEmail ?? $"no-reply@{hostname}"));

            foreach (var toEmail in to)
            {
                mailMessage.To.Add(new MailboxAddress(toEmail, toEmail));
            }

            mailMessage.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;


            mailMessage.Body = bodyBuilder.ToMessageBody();

            return mailMessage;
        }
    }
}
