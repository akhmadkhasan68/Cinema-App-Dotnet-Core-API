using CinemaApp.Dtos.Facility;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IFacilityRepository
    {
        Task<List<FacilityDto>> GetAll();

        Task<FacilityDto> FindOne(int id);

        Task<FacilityDto> Create(Facility data);

        Task<FacilityDto> Update(int id, Facility data);

        Task<bool> Delete(int id);
    }
}
