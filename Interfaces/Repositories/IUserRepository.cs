using System.Runtime.CompilerServices;
using CinemaApp.Dtos.User;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<UserDto> FindByEmailOrFailAsync(string email);

        public Task<UserDto?> FindByEmailAsync(string email);

        public Task<AsyncVoidMethodBuilder> CreateAsync(User user);
    }
}
