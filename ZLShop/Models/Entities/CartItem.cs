namespace ZLShop.Models.Entities;

public class CartItem : BaseEntity
{
    public int Id {get; set;}
    public int CartId {get; set;}
    public Cart? Cart {get; set;}
    public int ProductVariantId {get; set;}
    public ProductVariant? ProductVariant {get; set;}
    public int Quantity {get; set;}
    public decimal Price {get; set;}
    public decimal TotalPrice {get; set;}
}