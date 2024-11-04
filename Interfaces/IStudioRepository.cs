using CinemaApp.Dtos;
using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IStudioRepository
    {
        Task<List<StudioDto>> GetStudios();

        Task<StudioDto> GetStudio(int id);

        Task<StudioDto> AddStudio(Studio studio);

        Task<StudioDto> UpdateStudio(int id, Studio studio);

        Task<bool> DeleteStudio(int id);
    }
}
