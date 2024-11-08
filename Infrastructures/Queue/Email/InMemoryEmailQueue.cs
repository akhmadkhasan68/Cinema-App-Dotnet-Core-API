using System.Collections.Concurrent;

namespace CinemaApp.Infrastructures.Queue.Email
{
    public class InMemoryEmailQueue : IEmailQueue
    {
        private readonly ConcurrentQueue<EmailMessage> _queue = new();

        private readonly ILogger<InMemoryEmailQueue> _logger;

        public InMemoryEmailQueue(ILogger<InMemoryEmailQueue> logger)
        {
            _logger = logger;
        }

        public Task EnqueueAsync(EmailMessage emailMessage)
        {
            _logger.LogInformation("Enqueue email message: {emailMessage}", emailMessage);

            // TODO: Add email message to the queue

            _queue.Enqueue(emailMessage);
            return Task.CompletedTask;
        }

        public Task<EmailMessage> DequeueAsync()
        {
            _logger.LogInformation("Dequeue email message");

            _queue.TryDequeue(out var emailMessage);
            return Task.FromResult(emailMessage);
        }
    }
}
