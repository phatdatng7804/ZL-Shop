using ZLShop.DTOs.Products;
using ZLShop.DTOs.Size;
using ZLShop.DTOs.Color;

namespace ZLShop.DTOs.ProductVariant;

public class ProductVariantResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int ProductId { get; set; }
    public ProductResponseDto? Product { get; set; }
    public int SizeId { get; set; }
    public SizeResponseDto? Size { get; set; }
    public int ColorId { get; set; }
    public ColorResponseDto? Color { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string? SKU {get; set;}
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}