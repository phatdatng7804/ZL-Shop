
using System.ComponentModel.DataAnnotations;
namespace ZLShop.DTOs.Products;

public class UpdateProductDto{
    [Required(ErrorMessage = "Tên sẳn phẩm là bắt buộc")]
    public string Name {get; set;}
    [Required(ErrorMessage = "Phải nhập mô tả")]
    [MinLength(6, ErrorMessage = "Mô tả phải có ít nhất 6 ký tự")]
    public string Description {get; set;}
    [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
    public decimal Price {get; set;}
}