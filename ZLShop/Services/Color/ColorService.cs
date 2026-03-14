using ZLShop.Data;
using ZLShop.DTOs.Color;
using ZLShop.Models.Entities;
using ColorEntity = ZLShop.Models.Entities.Color;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZLShop.Exceptions;

namespace ZLShop.Services.Color;

public class ColorService : IColorService
{
    private readonly AppDbContext _context;
    public ColorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ColorResponseDto>> GetAllAsync()
    {
        var colors = await _context.Set<ColorEntity>().ToListAsync();
        return colors.Select(c => new ColorResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            HexCode = c.HexCode,
            CreatedAt = c.CreatedAt
        }).ToList();
    }
    public async Task<ColorResponseDto> GetByIdAsync(int id)
    {
        var color = await _context.Set<ColorEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if(color == null)
        {
            throw new NotFoundException("Không tìm thấy màu!");
        }
        return new ColorResponseDto
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            CreatedAt = color.CreatedAt
        };
    }
    public async Task<ColorResponseDto> CreateColorAsync(CreateColorDto request)
    {
        var normalName =request.Name.Trim();
        var normalHex = request.HexCode.Trim().ToUpper();
        var isExist = await _context.Set<ColorEntity>().AnyAsync(c => c.Name == normalName || c.HexCode == normalHex);
        if(isExist)
        {
            throw new ConflictException("Tên màu hoặc mã màu đã tồn tại");
        }
       var color = new ColorEntity
        {
        Name = normalName,
        HexCode = normalHex,
        CreatedAt = DateTime.UtcNow
       };
       _context.Set<ColorEntity>().Add(color);
       await _context.SaveChangesAsync();

       return new ColorResponseDto
       {
        Id = color.Id,
        Name = color.Name,
        HexCode = color.HexCode,
        CreatedAt = color.CreatedAt
       };
    }
    public async Task<ColorResponseDto> UpdateColorAsync(int id, UpdateColorDto request)
    {
        var color = await _context.Set<ColorEntity>().FindAsync(id);
        if(color == null)
        {
            throw new NotFoundException("Không tìm thấy màu!");
        }
        color.Name = request.Name.Trim();
        color.HexCode = request.HexCode.Trim().ToUpper();
        color.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return new ColorResponseDto
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            UpdatedAt = color.UpdatedAt
        };
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var color = await _context.Set<ColorEntity>().FindAsync(id);
        if(color == null)
        {
            throw new NotFoundException("Không tìm thấy màu!");
        }
        color.IsDeleted = true;
        color.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<ColorResponseDto>> GetDeletedAsync()
    {
        var colors = await _context.Set<ColorEntity>()
            .IgnoreQueryFilters()
            .Where(c => c.IsDeleted)
            .ToListAsync();
        return colors.Select(c => new ColorResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            HexCode = c.HexCode,
            CreatedAt = c.CreatedAt
        }).ToList();
    }
    public async Task<bool> RestoreAsync(int id)
    {
        var color = await _context.Set<ColorEntity>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);
        if(color == null)
        {
            throw new NotFoundException("Không tìm thấy màu!");
        }
        color.IsDeleted = false;
        color.DeletedAt = null;
        await _context.SaveChangesAsync();
        return true;
    }
}