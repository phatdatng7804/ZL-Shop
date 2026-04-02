namespace ZLShop.DTOs.Cart;
using ZLShop.DTOs.CartItems;
public class ResponseCartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemResponseDto>? CartItems { get; set; }
    public decimal TotalPrice { get; set; }
}