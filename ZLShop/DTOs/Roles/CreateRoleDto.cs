using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Roles;

public class CreateRoleDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
