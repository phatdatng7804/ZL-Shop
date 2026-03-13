using ZLShop.DTOs.Products;
using ZLShop.Models.Entities;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZLShop.Data;
using ZLShop.Exceptions;

namespace ZLShop.Services.Products;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductResponseDto>> GetAllAsync()
    {
        var products = await _context.Products
            .ToListAsync();
        if(products.Count == 0)
        {
            throw new BadRequestException("Không có sản phẩm nào trong kho!");
        }
        return products.Select(p => new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            CreatedAt = p.CreatedAt
        }).ToList();
    }
    public async Task<ProductResponseDto> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
        if(product == null)
        {
            throw new BadRequestException("Không tìm thấy sản phẩm!");
        }
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            CreatedAt = product.CreatedAt
        };
    }
    public async Task<ProductResponseDto> CreateAsync(CreateProductDto request)
    {
       var isExist = await _context.Products
            .FirstOrDefaultAsync(x => x.Name == request.Name);
        if(isExist != null)
        {
            throw new BadRequestException("Sản Phẩm đã toàn tại!");
        }
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ImageUrl = request.ImageUrl,
            CategoryId = request.CategoryId
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            CreatedAt = product.CreatedAt
        };
    }
    public async Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto request)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
        if(product == null)
        {
            throw new BadRequestException("Không tìm thấy sản phẩm!");
        }
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            CreatedAt = product.CreatedAt
        };
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if(product == null)
        {
            throw new BadRequestException("Không tìm thấy sản phẩm này");
        }
        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<ProductResponseDto>> GetDeletedAsync()
    {
        var products = await _context.Products
            .IgnoreQueryFilters()
            .Where(p => p.IsDeleted)
            .OrderByDescending(p => p.DeletedAt)
            .Select(p => new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            CreatedAt = p.CreatedAt,
            DeletedAt = p.DeletedAt
        })
        .ToListAsync();
        return products;
    }
    public async Task<bool> RestoreAsync(int id)
    {
        var product = await _context.Products
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);
        if(product == null)
        {
            throw new BadRequestException("Không tìm thấy sản phẩm này trong thùng rác");
        }
        product.IsDeleted = false;
        product.DeletedAt = null;
        await _context.SaveChangesAsync();
        return true;
    }
}