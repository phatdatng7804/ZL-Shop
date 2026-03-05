namespace ZLShop.Models.Entities;

public class RolePermission : BaseEntity
{
    public int Id {get; set;}
    public int RoleId {get; set;}
    public Role Role {get; set;}
    public int PermissionId {get; set;}
    public Permission Permission {get; set;}
    public bool IsEnabled { get; set; }
}