using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.Studio;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class StudioService(IStudioRepository studioRepository) : IStudioService
    {
        private readonly IStudioRepository _studioRepository = studioRepository;

        public async Task<List<StudioDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            return await _studioRepository.GetAll(paginationRequestDto);
        }

        public Task<StudioDto> FindOne(int id)
        {
            return _studioRepository.FindOne(id);
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Studio data)
        {
            return await _studioRepository.CreateAsync(data);
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Studio data)
        {
            return await _studioRepository.UpdateAsync(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _studioRepository.Delete(id);
        }
    }
}
