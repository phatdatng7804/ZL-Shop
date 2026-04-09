using ZLShop.DTOs.Permissions;

namespace ZLShop.DTOs.Roles;

public class RoleResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<PermissionResponseDto> Permissions { get; set; } = new();
}
