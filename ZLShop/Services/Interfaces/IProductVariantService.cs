using ZLShop.DTOs.ProductVariant;

namespace ZLShop.Services.Interfaces;

public interface IProductVariantService
{
    Task<ProductVariantResponseDto> CreateAsync(CreateProductVariantDto request);
    Task<List<ProductVariantResponseDto>> GetAllAsync();
    Task<ProductVariantResponseDto> GetByIdAsync(int id);
    Task<ProductVariantResponseDto> UpdateAsync(int id, UpdateProductVariantDto request);
    Task<ProductVariantResponseDto> DeleteAsync(int id);
    Task<List<ProductVariantResponseDto>> GetDeletedAsync();
    Task<ProductVariantResponseDto> RestoreAsync(int id);
}