using EmailSenderApi.Model.EmailSender;

namespace EmailSenderApi.Service
{
    public interface IEmailService
    {
        Task<EmailSenderResponse?> SendEmail(EmailSenderRequest email);
    }
}
