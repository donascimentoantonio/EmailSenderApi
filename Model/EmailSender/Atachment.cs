namespace EmailSenderApi.Model.EmailSender
{
    public record Atachment(Guid Id, string File, string FileName, string FileExtension, string EmailId);
}
