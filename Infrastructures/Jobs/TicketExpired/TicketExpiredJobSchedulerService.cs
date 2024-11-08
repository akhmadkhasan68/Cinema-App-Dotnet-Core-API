using Quartz;

namespace CinemaApp.Infrastructures.Jobs.TicketExpired
{
    public class TicketExpiredJobSchedulerService(IScheduler scheduler)
    {
        private readonly IScheduler _scheduler = scheduler;

        public async Task ScheduleJob<T>(string cronExpression, string jobName, string groupName) where T : IJob
        {
            var job = JobBuilder.Create<T>()
                .WithIdentity(jobName, groupName)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}-trigger", groupName)
                .WithCronSchedule(cronExpression)
                .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }
    }
}
