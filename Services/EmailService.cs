using CinemaApp.Infrastructures.Queue.Email;
using CinemaApp.Interfaces.Services;

namespace CinemaApp.Services
{
    public class EmailService(IEmailQueue emailQueue) : IEmailService
    {
        private readonly IEmailQueue _emailQueue = emailQueue;

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            await _emailQueue.EnqueueAsync(emailMessage);
        }
    }
}
