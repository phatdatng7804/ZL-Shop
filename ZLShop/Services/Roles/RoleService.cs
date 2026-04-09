using ZLShop.Data;
using ZLShop.DTOs.Permissions;
using ZLShop.DTOs.Roles;
using ZLShop.Exceptions;
using ZLShop.Models.Entities;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ZLShop.Services.Roles;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoleResponseDto>> GetAllAsync()
    {
        return await _context.Roles
            .Where(r => !r.IsDeleted)
            .Include(r => r.RolePermissions!)
                .ThenInclude(rp => rp.Permission)
            .Select(r => MapToDto(r))
            .ToListAsync();
    }

    public async Task<RoleResponseDto> GetByIdAsync(int id)
    {
        var role = await _context.Roles
            .Include(r => r.RolePermissions!)
                .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (role == null)
            throw new NotFoundException($"Role với Id = {id} không tồn tại");

        return MapToDto(role);
    }

    public async Task<RoleResponseDto> CreateAsync(CreateRoleDto request)
    {
        var exists = await _context.Roles
            .AnyAsync(r => r.Name == request.Name && !r.IsDeleted);

        if (exists)
            throw new ConflictException($"Role '{request.Name}' đã tồn tại");

        var role = new Role
        {
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        return MapToDto(role);
    }

    public async Task<RoleResponseDto> UpdateAsync(int id, UpdateRoleDto request)
    {
        var role = await _context.Roles
            .Include(r => r.RolePermissions!)
                .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (role == null)
            throw new NotFoundException($"Role với Id = {id} không tồn tại");

        if (request.Name != null)
        {
            var nameExists = await _context.Roles
                .AnyAsync(r => r.Name == request.Name && r.Id != id && !r.IsDeleted);
            if (nameExists)
                throw new ConflictException($"Role '{request.Name}' đã tồn tại");
            role.Name = request.Name;
        }

        role.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return MapToDto(role);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await _context.Roles
            .Include(r => r.Users)
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (role == null)
            throw new NotFoundException($"Role với Id = {id} không tồn tại");

        if (role.Users != null && role.Users.Any())
            throw new BadRequestException($"Không thể xoá role '{role.Name}' vì đang có user sử dụng");

        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    private static RoleResponseDto MapToDto(Role r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        CreatedAt = r.CreatedAt,
        UpdatedAt = r.UpdatedAt,
        Permissions = r.RolePermissions?
            .Where(rp => rp.IsEnabled && !rp.IsDeleted)
            .Select(rp => new PermissionResponseDto
            {
                Id = rp.Permission!.Id,
                Name = rp.Permission.Name,
                Code = rp.Permission.Code,
                Description = rp.Permission.Description,
                CreatedAt = rp.Permission.CreatedAt,
                UpdatedAt = rp.Permission.UpdatedAt
            }).ToList() ?? new()
    };
}
