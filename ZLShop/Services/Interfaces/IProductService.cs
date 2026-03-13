using ZLShop.DTOs.Products;

namespace ZLShop.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponseDto> CreateAsync(CreateProductDto request);
    Task<List<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto> GetByIdAsync(int id);
    Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto request);
    Task<bool> DeleteAsync(int id);
    Task<List<ProductResponseDto>> GetDeletedAsync();
    Task<bool> RestoreAsync(int id);
}