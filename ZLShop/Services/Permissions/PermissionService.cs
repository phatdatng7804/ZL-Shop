using ZLShop.Data;
using ZLShop.DTOs.Permissions;
using ZLShop.Exceptions;
using ZLShop.Models.Entities;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ZLShop.Services.Permissions;

public class PermissionService : IPermissionService
{
    private readonly AppDbContext _context;

    public PermissionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PermissionResponseDto>> GetAllAsync()
    {
        return await _context.Permissions
            .Where(p => !p.IsDeleted)
            .Select(p => MapToDto(p))
            .ToListAsync();
    }

    public async Task<PermissionResponseDto> GetByIdAsync(int id)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (permission == null)
            throw new NotFoundException($"Permission với Id = {id} không tồn tại");

        return MapToDto(permission);
    }

    public async Task<PermissionResponseDto> CreateAsync(CreatePermissionDto request)
    {
        var existingCode = await _context.Permissions
            .AnyAsync(p => p.Code == request.Code && !p.IsDeleted);

        if (existingCode)
            throw new ConflictException($"Permission code '{request.Code}' đã tồn tại");

        var permission = new Permission
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();

        return MapToDto(permission);
    }

    public async Task<PermissionResponseDto> UpdateAsync(int id, UpdatePermissionDto request)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (permission == null)
            throw new NotFoundException($"Permission với Id = {id} không tồn tại");

        if (request.Name != null) permission.Name = request.Name;
        if (request.Code != null)
        {
            var codeExists = await _context.Permissions
                .AnyAsync(p => p.Code == request.Code && p.Id != id && !p.IsDeleted);
            if (codeExists)
                throw new ConflictException($"Permission code '{request.Code}' đã tồn tại");
            permission.Code = request.Code;
        }
        if (request.Description != null) permission.Description = request.Description;

        permission.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return MapToDto(permission);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (permission == null)
            throw new NotFoundException($"Permission với Id = {id} không tồn tại");

        permission.IsDeleted = true;
        permission.DeletedAt = DateTime.UtcNow;
        permission.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    private static PermissionResponseDto MapToDto(Permission p) => new()
    {
        Id = p.Id,
        Name = p.Name,
        Code = p.Code,
        Description = p.Description,
        CreatedAt = p.CreatedAt,
        UpdatedAt = p.UpdatedAt
    };
}
