using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Users;

public class CreateUserDto
{
    [Required(ErrorMessage = "Username không được để trống")]
    public string? Username { get; set; } 
    [Required(ErrorMessage = "Tên không được để trống")]
    public string? Name { get; set; } 
    [Required(ErrorMessage = "Email không được để trống")]
    public string? Email { get; set; } 
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    public string? Phone { get; set; } 
    [Required(ErrorMessage = "Vai trò không được để trống")]
    public int? RoleId { get; set; } 
    [Required(ErrorMessage = "IsActive is required")]
    public bool? IsActive { get; set; } 
}