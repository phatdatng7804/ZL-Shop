using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Size;

public class UpdateSizeDto{
    [Required(ErrorMessage = "Tên size là bắt buộc")]
    public string Name {get; set;}
}
