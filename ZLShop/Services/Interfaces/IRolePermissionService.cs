using ZLShop.DTOs.RolePermissions;

namespace ZLShop.Services.Interfaces;

public interface IRolePermissionService
{
    Task<RolePermissionResponseDto> AssignPermissionAsync(AssignPermissionDto request);
    Task<bool> RevokePermissionAsync(int roleId, int permissionId);
    Task<List<RolePermissionResponseDto>> GetPermissionsByRoleAsync(int roleId);
}
