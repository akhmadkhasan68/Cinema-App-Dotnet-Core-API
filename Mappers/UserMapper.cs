using CinemaApp.Dtos.User;
using CinemaApp.Models;
using CinemaApp.Utils.Helpers;

namespace CinemaApp.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                RoleId = user.RoleId,
                Password = user.Password,
                Role = user.Role?.ToDto() ?? null,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };
        }   

        public static UserResponseDto ToResponse(this UserDto userDto)
        {
            return new UserResponseDto
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Name = userDto.Name,
                RegisteredAt = userDto.CreatedAt,
                Role = userDto.Role?.ToResponse() ?? null,
            };
        }     

        public static User ToModel(this UserRequestDto userRequestDto)
        {
            var password = PasswordHelper.Encrypt(userRequestDto.Password);

            return new User
            {
                Email = userRequestDto.Email,
                Name = userRequestDto.Name,
                RoleId = userRequestDto.RoleId,
                Password = password,
            };
        }
    }
}
