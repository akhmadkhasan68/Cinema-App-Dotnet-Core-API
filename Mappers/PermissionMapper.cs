using CinemaApp.Dtos.Permission;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class PermissionMapper
    {
        public static PermissionDto ToDto(this Permission permission)
        {
            return new PermissionDto
            {
                Id = permission.Id,
                Key = permission.Key,
                Name = permission.Name,
                RolePermissions = permission.RolePermissions.Select(rp => rp.ToDto()).ToList(),
                CreatedAt = permission.CreatedAt,
                UpdatedAt = permission.UpdatedAt,
            };
        }   

        public static PermissionResponseDto ToResponse(this PermissionDto permissionDto)
        {
            return new PermissionResponseDto
            {
                Id = permissionDto.Id,
                Key = permissionDto.Key,
                Name = permissionDto.Name,
                CreatedAt = permissionDto.CreatedAt,
                UpdatedAt = permissionDto.UpdatedAt,
            };
        }     

        public static Permission ToModel(this PermissionRequestDto permissionRequestDto)
        {
            return new Permission
            {
                Key = permissionRequestDto.Key,
                Name = permissionRequestDto.Name,
            };
        }
    }
}
