using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.RolePermissions;

public class AssignPermissionDto
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public int PermissionId { get; set; }
}
