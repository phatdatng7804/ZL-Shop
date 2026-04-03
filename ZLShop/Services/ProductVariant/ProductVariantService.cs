using ZLShop.DTOs.ProductVariant;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Variant = ZLShop.Models.Entities.ProductVariant;
using ZLShop.Exceptions;
using ZLShop.Data;
using ZLShop.DTOs.Products;
using ZLShop.DTOs.Size;
using ZLShop.DTOs.Color;

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
        var variants = await _context.Set<Variant>()
            .Include(v => v.Product)
            .Include(v => v.Size)
            .Include(v => v.Color)
            .ToListAsync();
            
        return variants.Select(MapToDto).ToList();
    }

    public async Task<ProductVariantResponseDto> GetByIdAsync(int id)
    {
        var variant = await _context.Set<Variant>()
            .Include(v => v.Product)
            .Include(v => v.Size)
            .Include(v => v.Color)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }

        return MapToDto(variant);
    }

    public async Task<ProductVariantResponseDto> CreateAsync(CreateProductVariantDto request)
    {
        // Kiểm tra xem sản phẩm này đã có biến thể với cùng Size và Color chưa
        var isExist = await _context.Set<Variant>().AnyAsync(p => p.ProductId == request.ProductId 
                                                               && p.SizeId == request.SizeId 
                                                               && p.ColorId == request.ColorId);
        if(isExist)
        {
            throw new ConflictException("Sản phẩm đã có kích thước và màu sắc này!");
        }
        var isSkuExist = await _context.Set<Variant>().AnyAsync(p => p.SKU == request.SKU);
        if(isSkuExist)
        {
            throw new ConflictException("Mã SKU này đã tồn tại!");
        }

        var variant = new Variant
        {
            Name = request.Name,
            ProductId = request.ProductId,
            SizeId = request.SizeId,
            ColorId = request.ColorId,
            Price = request.Price,
            Stock = request.Stock,
            SKU = request.SKU,
            CreatedAt = DateTime.UtcNow
        };
        _context.Set<Variant>().Add(variant);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(variant.Id);
    }

    public async Task<ProductVariantResponseDto> UpdateAsync(int id, UpdateProductVariantDto request)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if (variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }

        if (request.Name != null) variant.Name = request.Name;
        if (request.ColorId.HasValue) variant.ColorId = request.ColorId.Value;
        if (request.SizeId.HasValue) variant.SizeId = request.SizeId.Value;
        if (request.Price.HasValue) variant.Price = request.Price.Value;
        if (request.Stock.HasValue) variant.Stock = request.Stock.Value;
        if (request.SKU != null) variant.SKU = request.SKU;
        variant.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(variant.Id);
    }

    public async Task<ProductVariantResponseDto> DeleteAsync(int id)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if (variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }

        variant.IsDeleted = true;
        variant.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return MapToDto(variant);
    }

    public async Task<ProductVariantResponseDto> RestoreAsync(int id)
    {
        var variant = await _context.Set<Variant>().FindAsync(id);
        if (variant == null)
        {
            throw new NotFoundException("Không tìm thấy variant!");
        }

        variant.IsDeleted = false;
        variant.DeletedAt = null;
        await _context.SaveChangesAsync();

        return MapToDto(variant);
    }

    public async Task<List<ProductVariantResponseDto>> GetDeletedAsync()
    {
        var variants = await _context.Set<Variant>().IgnoreQueryFilters().Where(p => p.IsDeleted)
            .Include(v => v.Product)
            .Include(v => v.Size)
            .Include(v => v.Color)
            .ToListAsync();

        return variants.Select(MapToDto).ToList();
    }

    private ProductVariantResponseDto MapToDto(Variant v)
    {
        return new ProductVariantResponseDto
        {
            Id = v.Id,
            Name = v.Name,
            ProductId = v.ProductId,
            SizeId = v.SizeId,
            ColorId = v.ColorId,
            Stock = v.Stock,
            Price = v.Price,
            SKU = v.SKU,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt,
            DeletedAt = v.DeletedAt,
            IsDeleted = v.IsDeleted,
            Product = v.Product != null ? new ProductResponseDto
            {
                Id = v.Product.Id,
                Name = v.Product.Name,
                CreatedAt = v.Product.CreatedAt,
                UpdateAt = v.Product.UpdatedAt, 
                DeletedAt = v.Product.DeletedAt
            } : null,
            Size = v.Size != null ? new SizeResponseDto
            {
                Id = v.Size.Id,
                Name = v.Size.Name,
                CreatedAt = v.Size.CreatedAt,
                UpdatedAt = v.Size.UpdatedAt,
                DeletedAt = v.Size.DeletedAt
            } : null,
            Color = v.Color != null ? new ColorResponseDto
            {
                Id = v.Color.Id,
                Name = v.Color.Name,
                HexCode = v.Color.HexCode,
                CreatedAt = v.Color.CreatedAt,
                UpdatedAt = v.Color.UpdatedAt,
                DeletedAt = v.Color.DeletedAt
            } : null
        };
    }
}