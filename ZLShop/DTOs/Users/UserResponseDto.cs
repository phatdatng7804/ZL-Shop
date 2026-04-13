
namespace  ZLShop.DTOs.Users;

public class UserResponseDto{
    public int? Id { get; set; } 
    public string? Name { get; set; } 
    public string? Phone { get; set; } 
    public string? Email { get; set; }
    public string? Username { get; set; } 
    public int? RoleId { get; set; } 
    public bool? IsActive { get; set; } 
    public DateTime? CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; } 
}