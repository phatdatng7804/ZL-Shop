namespace ZLShop.DTOs.CartItems;

public class CartItemResponseDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductVariantId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get ;set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}