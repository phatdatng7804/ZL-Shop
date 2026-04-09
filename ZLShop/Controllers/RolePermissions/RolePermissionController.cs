using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.RolePermissions;
using ZLShop.Auth;

namespace ZLShop.Controllers.RolePermissions;

[ApiController]
[Route("api/[controller]")]
public class RolePermissionController(IRolePermissionService _rolePermissionService) : ControllerBase
{
    [HasPermission("role.manage")]
    [HttpPost("assign")]
    public async Task<IActionResult> AssignAsync([FromBody] AssignPermissionDto request)
    {
        var result = await _rolePermissionService.AssignPermissionAsync(request);
        return Ok(result);
    }

    [HasPermission("role.manage")]
    [HttpDelete("revoke")]
    public async Task<IActionResult> RevokeAsync([FromQuery] int roleId, [FromQuery] int permissionId)
    {
        var result = await _rolePermissionService.RevokePermissionAsync(roleId, permissionId);
        return Ok(result);
    }

    [HasPermission("role.manage")]
    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetByRoleAsync(int roleId)
    {
        var result = await _rolePermissionService.GetPermissionsByRoleAsync(roleId);
        return Ok(result);
    }
}
