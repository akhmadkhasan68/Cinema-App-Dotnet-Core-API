using CinemaApp.Dtos.Permission;
using CinemaApp.Dtos.Role;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto ToDto(this Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Key = role.Key,
                Name = role.Name,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt,
            };
        }   

        public static RoleResponseDto ToResponse(this RoleDto roleDto)
        {
            var permissions = roleDto.RolePermissions.Select(rp => {
                return new PermissionResponseDto{
                    Id = rp.Permission.Id,
                    Key = rp.Permission.Key,
                    Name = rp.Permission.Name,
                    CreatedAt = rp.Permission.CreatedAt,
                    UpdatedAt = rp.Permission.UpdatedAt,
                };
            }).ToList();
            
            return new RoleResponseDto
            {
                Id = roleDto.Id,
                Key = roleDto.Key,
                Name = roleDto.Name,
                Permissions = permissions,
                CreatedAt = roleDto.CreatedAt,
                UpdatedAt = roleDto.UpdatedAt,
            };
        }     

        public static Role ToModel(this RoleRequestDto roleRequestDto)
        {
            return new Role
            {
                Key = roleRequestDto.Key,
                Name = roleRequestDto.Name,
            };
        }
    }
}
