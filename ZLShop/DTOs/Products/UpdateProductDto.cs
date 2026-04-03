
using System.ComponentModel.DataAnnotations;
namespace ZLShop.DTOs.Products;

public class UpdateProductDto{
    [Required(ErrorMessage = "Tên sẳn phẩm là bắt buộc")]
    public string? Name {get; set;}
    public string? Description {get; set;}
    [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
    public decimal Price {get; set;}
}