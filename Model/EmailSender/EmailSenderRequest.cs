
namespace EmailSenderApi.Model.EmailSender
{
    public class EmailSenderRequest
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IReadOnlyList<Atachment>? Atachments { get; private set; }
        public DateTime LastAttemptAt =>DateTime.UtcNow

    }
}
