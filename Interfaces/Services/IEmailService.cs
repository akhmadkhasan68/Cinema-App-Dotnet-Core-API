using CinemaApp.Infrastructures.Queue.Email;

namespace CinemaApp.Interfaces.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailMessage emailMessage);
    }
}
