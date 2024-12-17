namespace EmailSenderApi.Model.Infra
{
    public record ErrorResponseRequest(string Status, string Message, string Details);
}
