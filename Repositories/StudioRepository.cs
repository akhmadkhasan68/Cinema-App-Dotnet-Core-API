using CinemaApp.Dtos.Studio;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class StudioRepository(ApplicationDBContext context) : IStudioRepository
    {
        private readonly ApplicationDBContext _context = context;

        public Task<List<StudioDto>> GetAll()
        {
            var studios = _context.Studios.ToList().Select(studio => studio.ToDto()).ToList();

            return Task.FromResult(studios);
        }

        public Task<StudioDto> FindOne(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");
            return Task.FromResult(studio.ToDto());
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_context.Studios.Any(studio => studio.Id == id));
        }

        public Task<StudioDto> Create(Studio data)
        {
            _context.Studios.Add(data);
            _context.SaveChanges();

            return Task.FromResult(data.ToDto());
        }

        public Task<StudioDto> Update(int id, Studio data)
        {
            var existingStudio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");

            existingStudio.Name = data.Name;
            existingStudio.Capacity = data.Capacity;

            _context.SaveChanges();

            return Task.FromResult(existingStudio.ToDto());
        }

        public Task<bool> Delete(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new Exception("Studio not found");

            _context.Studios.Remove(studio);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
