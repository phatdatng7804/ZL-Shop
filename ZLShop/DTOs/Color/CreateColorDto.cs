using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Color;
public class CreateColorDto{
    [Required(ErrorMessage = "Tên màu là bắt buộc")]
    public string? Name {get; set;}
    [Required(ErrorMessage = "Mã màu là bắt buộc")]
    [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Mã màu không hợp lệ")]
    public string? HexCode {get; set;}
}