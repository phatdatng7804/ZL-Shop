using System.ComponentModel.DataAnnotations;
namespace ZLShop.DTOs.CartItems;
public class UpdateCartItemDto
{
    [Required(ErrorMessage = "Số lượng không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
    public int Quantity { get; set; }
}