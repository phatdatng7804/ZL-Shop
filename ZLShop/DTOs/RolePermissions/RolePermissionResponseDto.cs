namespace ZLShop.DTOs.RolePermissions;

public class RolePermissionResponseDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
    public int PermissionId { get; set; }
    public string? PermissionName { get; set; }
    public string? PermissionCode { get; set; }
    public bool IsEnabled { get; set; }
}
