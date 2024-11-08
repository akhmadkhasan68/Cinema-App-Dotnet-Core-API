using Quartz;

namespace CinemaApp.Infrastructures.Jobs.TicketExpired
{
    public class TicketExpiredJob(ILogger<TicketExpiredJob> logger) : IJob
    {
        private readonly ILogger<TicketExpiredJob> _logger = logger;

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Ticket expired job is running");
            
            return Task.CompletedTask;
        }
    }
}
