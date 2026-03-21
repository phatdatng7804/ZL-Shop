using ZLShop.DTOs.ProductVariant;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZLShop.Models.Entities;
using Variant = ZLShop.Models.Entities.ProductVariant;
using ZLShop.Exceptions;
using ZLShop.Data;
namespace ZLShop.Services.ProductVariant;

public class ProductVariantService : IProductVariantService
{
   private readonly AppDbContext _context;
    public ProductVariantService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductVariantResponseDto>> GetAllAsync()
    {
        var variants = await _context.Set<Variant>().ToListAsync();
        return variants.Select(v => new ProductVariantResponseDto
        {
            Id = v.Id,
            Name = v.Name,
            CreatedAt = v.CreatedAt
        }).ToList();
    }
    public async Task<ProductVariantResponseDto> GetByIdAsync(int id)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if(variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }
        return new ProductVariantResponseDto
        {
            Id = variant.Id,
            Name = variant.Name,
            CreatedAt = variant.CreatedAt
        };
    }
    public async Task<ProductVariantResponseDto> CreateAsync(CreateProductVariantDto request)
    {
        var isExist = await _context.Set<Variant>().AnyAsync(p => p.Name == request.Name);
        if(isExist)
        {
            throw new ConflictException("Variant đã tồn tại!");
        }
        var variant = new Variant
        {
            Name = request.Name,
            ProductId = request.ProductId,
            SizeId = request.SizeId,
            ColorId = request.ColorId,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };
        _context.Set<Variant>().Add(variant);
        await _context.SaveChangesAsync();
        return new ProductVariantResponseDto
        {
            Id = variant.Id,
            Name = variant.Name,
            CreatedAt = variant.CreatedAt
        };
    }
    public async Task<ProductVariantResponseDto> UpdateAsync(int id, UpdateProductVariantDto request)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if(variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }
        variant.Name = request.Name;
        variant.Price = request.Price;
        variant.Stock = request.Stock;
        variant.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return new ProductVariantResponseDto
        {
            Id = variant.Id,
            Name = variant.Name,
            UpdatedAt = variant.UpdatedAt
        };
    }
    public async Task<ProductVariantResponseDto> DeleteAsync(int id)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if(variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }
        variant.IsDeleted = true;
        variant.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return new ProductVariantResponseDto
        {
            Id = variant.Id,
            Name = variant.Name,
            DeletedAt = variant.DeletedAt
        };
    }
    public async Task<ProductVariantResponseDto> RestoreAsync(int id)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if(variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }
        variant.IsDeleted = false;
        variant.DeletedAt = null;
        await _context.SaveChangesAsync();
        return new ProductVariantResponseDto
        {
            Id = variant.Id,
            Name = variant.Name,
            CreatedAt = variant.CreatedAt
        };
    }
    public async Task<List<ProductVariantResponseDto>> GetDeletedAsync()
    {
        var variants = await _context.Set<Variant>().IgnoreQueryFilters().Where(p => p.IsDeleted).ToListAsync();
        return variants.Select(v => new ProductVariantResponseDto
        {
            Id = v.Id,
            Name = v.Name,
            CreatedAt = v.CreatedAt,
            DeletedAt = v.DeletedAt
        }).ToList();
    }
}