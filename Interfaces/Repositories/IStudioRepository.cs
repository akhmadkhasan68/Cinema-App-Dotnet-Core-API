using CinemaApp.Dtos.Studio;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IStudioRepository : IBaseRepository<StudioDto, Studio> {
        public Task<bool> IsExist(int id);
    }
}
