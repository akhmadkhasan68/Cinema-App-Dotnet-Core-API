using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CinemaApp.Dtos.Facility;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class FacilityService(IFacilityRepository facilityRepository) : IFacilityService
    {
        private readonly IFacilityRepository _facilityRepository = facilityRepository;

        public async Task<List<FacilityDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            return await _facilityRepository.GetAll(paginationRequestDto);
        }

        public Task<FacilityDto> FindOne(int id)
        {
            return _facilityRepository.FindOne(id);
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Facility data)
        {
            return await _facilityRepository.CreateAsync(data);
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Facility data)
        {
            return await _facilityRepository.UpdateAsync(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _facilityRepository.Delete(id);
        }
    }
}
