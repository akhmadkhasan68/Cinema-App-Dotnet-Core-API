using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Role;
using CinemaApp.Dtos.User;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class UserRepository(ApplicationDBContext context) : IUserRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<UserDto> FindByEmailOrFailAsync(string email)
        {
            var user = await _context.Users
                        .Where(user => user.Email == email)
                        .Include(user => user.Role)
                        .AsSplitQuery()
                        .FirstOrDefaultAsync() ?? throw new DataNotFoundException("User not found");

            return new UserDto
            {
                Id = user.Id,
                RoleId = user.RoleId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = new RoleDto
                {
                    Id = user.Role.Id,
                    Key = user.Role.Key,
                    Name = user.Role.Name,
                    CreatedAt = user.Role.CreatedAt,
                    UpdatedAt = user.Role.UpdatedAt
                },
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<UserDto?> FindByEmailAsync(string email) {
            var user = await _context.Users
                        .Where(user => user.Email == email)
                        .Include(user => user.Role)
                        .AsSplitQuery()
                        .FirstOrDefaultAsync();

            return user?.ToDto();
        }

        public async Task<UserDto> FindByIdOrFailAsync(int id) {
            var user = await _context.Users
                        .Where(user => user.Id == id)
                        .Include(user => user.Role)
                        .AsSplitQuery()
                        .FirstOrDefaultAsync() ?? throw new DataNotFoundException("User not found");

            return new UserDto
            {
                Id = user.Id,
                RoleId = user.RoleId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = new RoleDto
                {
                    Id = user.Role.Id,
                    Key = user.Role.Key,
                    Name = user.Role.Name,
                    CreatedAt = user.Role.CreatedAt,
                    UpdatedAt = user.Role.UpdatedAt
                },
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(User user) {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }
    }
}
