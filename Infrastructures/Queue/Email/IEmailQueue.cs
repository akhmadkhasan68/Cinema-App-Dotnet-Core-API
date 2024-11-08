namespace CinemaApp.Infrastructures.Queue.Email
{
    public interface IEmailQueue
    {
        Task EnqueueAsync(EmailMessage emailMessage);

        Task<EmailMessage> DequeueAsync();
    }
}
