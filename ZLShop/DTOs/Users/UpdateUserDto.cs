
namespace ZLShop.DTOs.Users;

public class UpdateUserDto{
    public string? Name { get; set; } 
    public string? Phone { get; set; } 
    public string? Email { get; set; }
    public int? RoleId { get; set; } 
    public bool? IsActive { get; set; } 
}