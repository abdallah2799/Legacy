using Core.Interfaces.Services;
using Common.Helpers;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IConfiguration configuration)
        {
            _settings = configuration.GetSection("Smtp").Get<EmailSettings>();
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var smtpClient = new SmtpClient(_settings.Host)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSsl
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_settings.Username, "Examination System"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mail.To.Add(to);
            await smtpClient.SendMailAsync(mail);
        }
    }
}
