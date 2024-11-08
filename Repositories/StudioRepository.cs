using System.Runtime.CompilerServices;
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

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Studio data)
        {
            await _context.Studios.AddAsync(data);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Studio data)
        {
            var existingStudio = await _context.Studios.FindAsync(id) ?? throw new Exception("Studio not found");

            existingStudio.Name = data.Name;
            existingStudio.Capacity = data.Capacity;

            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
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
