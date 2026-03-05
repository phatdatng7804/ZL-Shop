namespace ZLShop.Models.Entities;
using ZLShop.Models.Enums;

public class User : BaseEntity
{
    public int Id {get; set;}
    public string Username {get; set;}
    public string Password {get; set;}
    public string Email {get; set;}
    public string Phone {get; set;}
    public Gender Gender {get; set;}
    public int RoleId {get; set;}
    public Role Role {get; set;}
    public ICollection<UserAddress> Addresses { get; set; }
    public Cart Cart { get; set; }
    public DateTime? CreatedAt {get; set;}
    public DateTime? UpdatedAt {get; set;}
}