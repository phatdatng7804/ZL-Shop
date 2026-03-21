using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.ProductVariant;

public class CreateProductVariantDto
{
    [Required(ErrorMessage = "Product ID không được để trống!")]
    public int ProductId { get; set;}
    [Required(ErrorMessage = "Tên không được để trống!")]
    public string Name { get; set;}
    [Required(ErrorMessage = "Color ID không được để trống!")]
    public int ColorId { get; set;}
    [Required(ErrorMessage = "Size ID không được để trống!")]
    public int SizeId { get; set;}
    [Required(ErrorMessage = "Giá không được để trống!")]
    public decimal Price { get; set;}
    [Required(ErrorMessage = "Số lượng không được để trống!")]
    public int Stock { get; set;}
}