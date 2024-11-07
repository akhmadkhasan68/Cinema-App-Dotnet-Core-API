using CinemaApp.Dtos.Permission;
using CinemaApp.Dtos.RolePermission;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class RolePermissionMapper
    {
        public static RolePermissionDto ToDto(this RolePermission rolePermission)
        {
            return new RolePermissionDto
            {
                PermissionId = rolePermission.PermissionId,
                RoleId = rolePermission.RoleId,
                Role = rolePermission.Role?.ToDto() ?? null,
                Permission = rolePermission.Permission?.ToDto() ?? null,
            };
        }   

        public static RolePermissionResponseDto ToResponse(this RolePermissionDto rolePermissionDto)
        {
            return new RolePermissionResponseDto
            {
                Role = rolePermissionDto.Role?.ToResponse() ?? null,
                Permission = rolePermissionDto.Permission?.ToResponse() ?? null,
            };
        }     

        public static Role ToModel(this PermissionRequestDto permissionRequestDto)
        {
            return new Role
            {
                Key = permissionRequestDto.Key,
                Name = permissionRequestDto.Name,
            };
        }
    }
}
