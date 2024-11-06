using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Facility;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class FacilityService(IFacilityRepository facilityRepository) : IFacilityService
    {
        private readonly IFacilityRepository _facilityRepository = facilityRepository;

        public Task<List<FacilityDto>> GetAll()
        {
            return _facilityRepository.GetAll();
        }

        public Task<FacilityDto> FindOne(int id)
        {
            return _facilityRepository.FindOne(id);
        }

        public Task<FacilityDto> Create(Facility data)
        {
            return _facilityRepository.Create(data);
        }

        public Task<FacilityDto> Update(int id, Facility data)
        {
            return _facilityRepository.Update(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _facilityRepository.Delete(id);
        }
    }
}
