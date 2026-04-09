using ZLShop.DTOs.Permissions;

namespace ZLShop.Services.Interfaces;

public interface IPermissionService
{
    Task<List<PermissionResponseDto>> GetAllAsync();
    Task<PermissionResponseDto> GetByIdAsync(int id);
    Task<PermissionResponseDto> CreateAsync(CreatePermissionDto request);
    Task<PermissionResponseDto> UpdateAsync(int id, UpdatePermissionDto request);
    Task<bool> DeleteAsync(int id);
}
