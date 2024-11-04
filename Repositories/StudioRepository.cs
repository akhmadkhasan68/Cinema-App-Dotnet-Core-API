using CinemaApp.Dtos;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class StudioRepository(ApplicationDBContext context) : IStudioRepository
    {
        private readonly ApplicationDBContext _context = context;

        public Task<List<StudioDto>> GetStudios()
        {
            var studios = _context.Studios.ToList().Select(studio => studio.ToDto()).ToList();

            return Task.FromResult(studios);
        }

        public Task<StudioDto> GetStudio(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");
            return Task.FromResult(studio.ToDto());
        }

        public Task<StudioDto> AddStudio(Studio studio)
        {
            _context.Studios.Add(studio);
            _context.SaveChanges();

            return Task.FromResult(studio.ToDto());
        }

        public Task<StudioDto> UpdateStudio(int id, Studio studio)
        {
            var existingStudio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");

            existingStudio.Name = studio.Name;
            existingStudio.Capacity = studio.Capacity;

            _context.SaveChanges();

            return Task.FromResult(existingStudio.ToDto());
        }

        public Task<bool> DeleteStudio(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");

            _context.Studios.Remove(studio);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
