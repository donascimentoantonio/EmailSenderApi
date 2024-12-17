namespace EmailSenderApi.Model.EmailSender
{
    public record EmailSenderResponse(string Id, EmailStatus Status, DateTime LastAttemptAt, string? DetailError = "");
}
