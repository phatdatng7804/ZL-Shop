using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Color;
public class UpdateColorDto{
    [Required(ErrorMessage = "Tên màu là bắt buộc")]
    public string Name {get; set;}
    [Required(ErrorMessage = "Mã màu là bắt buộc")]
    public string HexCode {get; set;}
}