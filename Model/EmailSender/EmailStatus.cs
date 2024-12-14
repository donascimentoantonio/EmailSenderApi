namespace EmailSenderApi.Model.EmailSender
{
    public enum EmailStatus
    {
        Pending,  // Email aguardando envio
        Sent,     // Email enviado com sucesso
        Error     // Ocorreu um erro ao enviar o email
    }
}
