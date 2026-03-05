using System.ComponentModel.DataAnnotations;
using ZLShop.Models.Enums;

namespace ZLShop.DTOs.Auth;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Username là bắt buộc")]
    [MinLength(6, ErrorMessage = "Username phải có ít nhất 6 ký tự")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password là bắt buộc")]
    [MinLength(6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email {get; set;}
    public string Phone {get; set;}
    public Gender Gender {get; set;}
    public int RoleId {get; set;}
}