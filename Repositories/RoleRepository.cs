using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;

namespace CinemaApp.Repositories
{
    public class RoleRepository(ApplicationDBContext applicationDBContext) : IRoleRepository
    {
        private readonly ApplicationDBContext _context = applicationDBContext;

        public Task<bool> IsExist(int id)
        {
            var data = _context.Roles.FirstOrDefault(data => data.Id == id);

            return Task.FromResult(data != null);
        }
    }
}
