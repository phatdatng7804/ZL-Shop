using ZLShop.Data;
using ZLShop.DTOs.RolePermissions;
using ZLShop.Exceptions;
using ZLShop.Models.Entities;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ZLShop.Services.RolePermissions;

public class RolePermissionService : IRolePermissionService
{
    private readonly AppDbContext _context;

    public RolePermissionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RolePermissionResponseDto> AssignPermissionAsync(AssignPermissionDto request)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(r => r.Id == request.RoleId && !r.IsDeleted);
        if (role == null)
            throw new NotFoundException($"Role với Id = {request.RoleId} không tồn tại");

        var permission = await _context.Permissions
            .FirstOrDefaultAsync(p => p.Id == request.PermissionId && !p.IsDeleted);
        if (permission == null)
            throw new NotFoundException($"Permission với Id = {request.PermissionId} không tồn tại");

        var existing = await _context.RolePermissions
            .FirstOrDefaultAsync(rp => rp.RoleId == request.RoleId && rp.PermissionId == request.PermissionId);

        if (existing != null)
        {
            if (existing.IsEnabled && !existing.IsDeleted)
                throw new ConflictException("Permission này đã được gán cho role");

            // Re-enable if it was disabled or soft-deleted
            existing.IsEnabled = true;
            existing.IsDeleted = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return MapToDto(existing, role, permission);
        }

        var rolePermission = new RolePermission
        {
            RoleId = request.RoleId,
            PermissionId = request.PermissionId,
            IsEnabled = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.RolePermissions.Add(rolePermission);
        await _context.SaveChangesAsync();

        return MapToDto(rolePermission, role, permission);
    }

    public async Task<bool> RevokePermissionAsync(int roleId, int permissionId)
    {
        var rolePermission = await _context.RolePermissions
            .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId && !rp.IsDeleted);

        if (rolePermission == null)
            throw new NotFoundException("Không tìm thấy liên kết Role-Permission này");

        rolePermission.IsEnabled = false;
        rolePermission.IsDeleted = true;
        rolePermission.DeletedAt = DateTime.UtcNow;
        rolePermission.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<RolePermissionResponseDto>> GetPermissionsByRoleAsync(int roleId)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(r => r.Id == roleId && !r.IsDeleted);
        if (role == null)
            throw new NotFoundException($"Role với Id = {roleId} không tồn tại");

        return await _context.RolePermissions
            .Where(rp => rp.RoleId == roleId && rp.IsEnabled && !rp.IsDeleted)
            .Include(rp => rp.Permission)
            .Include(rp => rp.Role)
            .Select(rp => new RolePermissionResponseDto
            {
                Id = rp.Id,
                RoleId = rp.RoleId,
                RoleName = rp.Role!.Name,
                PermissionId = rp.PermissionId,
                PermissionName = rp.Permission!.Name,
                PermissionCode = rp.Permission.Code,
                IsEnabled = rp.IsEnabled
            })
            .ToListAsync();
    }

    private static RolePermissionResponseDto MapToDto(RolePermission rp, Role role, Permission permission) => new()
    {
        Id = rp.Id,
        RoleId = rp.RoleId,
        RoleName = role.Name,
        PermissionId = rp.PermissionId,
        PermissionName = permission.Name,
        PermissionCode = permission.Code,
        IsEnabled = rp.IsEnabled
    };
}
