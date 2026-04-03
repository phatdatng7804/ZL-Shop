using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.ProductVariant;

public class UpdateProductVariantDto
{
    public string? Name { get; set; }
    public int? ColorId { get; set; }
    public int? SizeId { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public string? SKU { get; set; }
}