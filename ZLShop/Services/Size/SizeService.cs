using ZLShop.Data;
using ZLShop.Models.Entities;
using ZLShop.DTOs.Size;
using ZLShop.Services.Interfaces;
using SizeEntity = ZLShop.Models.Entities.Size;
using Microsoft.EntityFrameworkCore;
using ZLShop.Exceptions;

namespace ZLShop.Services.Size;

public class SizeService : ISizeService{
    private readonly AppDbContext _context;
    public SizeService(AppDbContext context){
        _context = context;
    }
    public async Task<List<SizeResponseDto>> GetAllAsync()
    {
        var sizes = await _context.Set<SizeEntity>().ToListAsync();
        return sizes.Select(s => new SizeResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            CreatedAt = s.CreatedAt
        }).ToList();
    }
    public async Task<SizeResponseDto> GetByIdAsync(int id)
    {
        var size = await _context.Set<SizeEntity>().FindAsync(id);
        if(size == null)
        {
            throw new NotFoundException("Không tìm thấy size!");
        }
        return new SizeResponseDto
        {
            Id = size.Id,
            Name = size.Name,
            CreatedAt = size.CreatedAt
        };
    }
    public async Task<SizeResponseDto> CreateSizeAsync(CreateSizeDto request)
    {
        var isExist = await _context.Set<SizeEntity>().AnyAsync(s => s.Name == request.Name);
        if(isExist)
        {
            throw new ConflictException("Size đã tồn tại");
        }
        var size = new SizeEntity
        {
            Name = request.Name,
            CreatedAt = DateTime.UtcNow
        };
        _context.Set<SizeEntity>().Add(size);
        await _context.SaveChangesAsync();
        return new SizeResponseDto
        {
            Id = size.Id,
            Name = size.Name,
            CreatedAt = size.CreatedAt
        };
    }
    public async Task<SizeResponseDto> UpdateSizeAsync(int id, UpdateSizeDto request)
    {
        var size = await _context.Set<SizeEntity>().FindAsync(id);
        if(size == null)
        {
            throw new NotFoundException("Không tìm thấy size!");
        }
        size.Name = request.Name;
        size.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return new SizeResponseDto
        {
            Id = size.Id,
            Name = size.Name,
            UpdatedAt = size.UpdatedAt
        };
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var size = await _context.Set<SizeEntity>().FindAsync(id);
        if(size == null)
        {
            throw new NotFoundException("Không tìm thấy size!");
        }
        size.IsDeleted = true;
        size.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<SizeResponseDto>> GetDeletedAsync()
    {
        var sizes = await _context.Set<SizeEntity>()
            .IgnoreQueryFilters()
            .Where(s => s.IsDeleted)
            .ToListAsync();
        return sizes.Select(s => new SizeResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            CreatedAt = s.CreatedAt,
            DeletedAt = s.DeletedAt
        }).ToList();
    }
    public async Task<bool> RestoreAsync(int id)
    {
        var size = await _context.Set<SizeEntity>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted);
        if(size == null)
        {
            throw new NotFoundException("Không tìm thấy size!");
        }
        size.IsDeleted = false;
        size.DeletedAt = null;
        await _context.SaveChangesAsync();
        return true;
    }
}