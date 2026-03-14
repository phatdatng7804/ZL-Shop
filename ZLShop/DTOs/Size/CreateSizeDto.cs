
using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Size;

public class CreateSizeDto{
    [Required(ErrorMessage = "Tên size là bắt buộc")]
    public string Name {get; set;}
}

