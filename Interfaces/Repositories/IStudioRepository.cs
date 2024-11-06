using CinemaApp.Dtos;
using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IStudioRepository
    {
        Task<List<StudioDto>> GetAll();

        Task<StudioDto> FindOne(int id);

        Task<StudioDto> Create(Studio data);

        Task<StudioDto> Update(int id, Studio data);

        Task<bool> Delete(int id);
    }
}
