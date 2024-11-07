using CinemaApp.Dtos.Schedule;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IScheduleRepository : IBaseRepository<ScheduleDto, Schedule> {}
}
