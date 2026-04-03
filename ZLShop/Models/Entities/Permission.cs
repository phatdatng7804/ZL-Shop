namespace ZLShop.Models.Entities;

public class Permission : BaseEntity
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Code {get; set;}
    public ICollection<RolePermission>? RolePermissions {get; set;}
}