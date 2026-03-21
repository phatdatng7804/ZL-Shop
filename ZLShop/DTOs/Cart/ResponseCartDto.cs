namespace ZLShop.DTOs.Cart;
using ZLShop.DTOs.CartItem;
public class ResponseCartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<ResponseCartItemDto> CartItems { get; set; }
    public decimal TotalPrice { get; set; }
}