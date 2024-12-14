

using EmailSender.Api.Models;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using EmailSenderApi.Model.EmailSender;

namespace EmailSenderApi.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings) => _emailSettings = emailSettings.Value;

        public async Task<EmailSenderResponse?> SendEmail(EmailSenderRequest email)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_emailSettings.SenderEmail));
                message.To.AddRange(email.Recipients.Select(r => MailboxAddress.Parse(r)));
                message.Subject = email.Subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = email.Body;

                //// Adicionar anexos (se houver) --- Converter os arquivos em Content
                //if (email.Atachments != null && email.Atachments.Any())
                //{
                //    foreach (var attachment in email.Atachments)
                //    {
                //        bodyBuilder.Attachments.Add(attachment.FileName, attachment.Content);
                //    }
                //}

                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                client.Connect(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                client.Authenticate(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);

                return new EmailSenderResponse(email.Id, EmailStatus.Sent, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                return new EmailSenderResponse(email.Id, EmailStatus.Error, DateTime.UtcNow, ex.Message);
            }
        }
    }
}
