using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Facility;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
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
            var data = _context.Facilities.Find(id) ?? throw new DataNotFoundException("Facility not found");
            return Task.FromResult(data.ToDto());
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Facility data)
        {
            await _context.Facilities.AddAsync(data);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Facility data)
        {
            var existingStudio = await _context.Facilities.FindAsync(id) ?? throw new DataNotFoundException("Facility not found");

            existingStudio.Name = data.Name;
            existingStudio.IsActive = data.IsActive;

            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var facility = _context.Facilities.Find(id) ?? throw new DataNotFoundException("Facility not found");

            _context.Facilities.Remove(facility);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
