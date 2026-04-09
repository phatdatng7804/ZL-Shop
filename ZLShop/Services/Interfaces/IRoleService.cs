using ZLShop.DTOs.Roles;

namespace ZLShop.Services.Interfaces;

public interface IRoleService
{
    Task<List<RoleResponseDto>> GetAllAsync();
    Task<RoleResponseDto> GetByIdAsync(int id);
    Task<RoleResponseDto> CreateAsync(CreateRoleDto request);
    Task<RoleResponseDto> UpdateAsync(int id, UpdateRoleDto request);
    Task<bool> DeleteAsync(int id);
}
