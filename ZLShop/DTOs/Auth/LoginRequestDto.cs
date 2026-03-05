using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Username là bắt buộc")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password là bắt buộc")]
    public string Password { get; set; }
}
