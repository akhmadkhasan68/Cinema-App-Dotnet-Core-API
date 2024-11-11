using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.Schedule;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;

namespace CinemaApp.Services
{
    public class ScheduleService(IScheduleRepository scheduleRepository, IMovieRepository movieRepository, IStudioRepository studioRepository) : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly IStudioRepository _studioRepository = studioRepository;

        public async Task<List<ScheduleDto>> GetAll(PaginationRequestDto paginationRequest)
        {
            return await _scheduleRepository.GetAll(paginationRequest);
        }

        public Task<ScheduleDto> FindOne(int id)
        {
            return _scheduleRepository.FindOne(id);
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(ScheduleRequestDto data)
        {
            var IsMovieExist = await _movieRepository.IsExist(data.MovieId);

            if (!IsMovieExist) throw new DataNotFoundException("Movie not found");

            var IsStudioExist = await _studioRepository.IsExist(data.StudioId);

            if (!IsStudioExist) throw new DataNotFoundException("Studio not found");

            return await _scheduleRepository.CreateAsync(data.ToModel());
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, ScheduleRequestDto data)
        {
            var IsMovieExist = await _movieRepository.IsExist(data.MovieId);

            if (!IsMovieExist) throw new DataNotFoundException("Movie not found");

            var IsStudioExist = await _studioRepository.IsExist(data.StudioId);

            if (!IsStudioExist) throw new DataNotFoundException("Studio not found");

            return await _scheduleRepository.UpdateAsync(id, data.ToModel());
        }

        public Task<bool> Delete(int id)
        {
            return _scheduleRepository.Delete(id);
        }
    }
}
