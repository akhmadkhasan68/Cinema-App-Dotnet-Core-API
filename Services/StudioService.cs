using CinemaApp.Dtos.Studio;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class StudioService(IStudioRepository studioRepository) : IStudioService
    {
        private readonly IStudioRepository _studioRepository = studioRepository;

        public Task<List<StudioDto>> GetAll()
        {
            return _studioRepository.GetAll();
        }

        public Task<StudioDto> FindOne(int id)
        {
            return _studioRepository.FindOne(id);
        }

        public Task<StudioDto> Create(Studio data)
        {
            return _studioRepository.Create(data);
        }

        public Task<StudioDto> Update(int id, Studio data)
        {
            return _studioRepository.Update(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _studioRepository.Delete(id);
        }
    }
}
