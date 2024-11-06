using CinemaApp.Dtos.Facility;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class FacilityRepository(ApplicationDBContext context) : IFacilityRepository
    {
        private readonly ApplicationDBContext _context = context;

        public Task<List<FacilityDto>> GetAll()
        {
            var datas = _context.Facilities.ToList().Select(data => data.ToDto()).ToList();

            return Task.FromResult(datas);
        }

        public Task<FacilityDto> FindOne(int id)
        {
            var data = _context.Facilities.Find(id) ?? throw new Exception("Facility not found");
            return Task.FromResult(data.ToDto());
        }

        public Task<FacilityDto> Create(Facility data)
        {
            _context.Facilities.Add(data);
            _context.SaveChanges();

            return Task.FromResult(data.ToDto());
        }

        public Task<FacilityDto> Update(int id, Facility data)
        {
            var existingStudio = _context.Facilities.Find(id) ?? throw new Exception("Facility not found");

            existingStudio.Name = data.Name;
            existingStudio.IsActive = data.IsActive;

            _context.SaveChanges();

            return Task.FromResult(existingStudio.ToDto());
        }

        public Task<bool> Delete(int id)
        {
            var facility = _context.Facilities.Find(id) ?? throw new Exception("Facility not found");

            _context.Facilities.Remove(facility);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
