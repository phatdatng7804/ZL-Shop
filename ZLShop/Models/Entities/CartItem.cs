namespace ZLShop.Models.Entities;

public class CartItem : BaseEntity
{
    public int Id {get; set;}
    public int CartId {get; set;}
    public Cart Cart {get; set;}
    public decimal Price {get; set;}
}