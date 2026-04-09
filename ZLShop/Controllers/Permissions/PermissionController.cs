using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Permissions;
using ZLShop.Auth;

namespace ZLShop.Controllers.Permissions;

[ApiController]
[Route("api/[controller]")]
public class PermissionController(IPermissionService _permissionService) : ControllerBase
{
    [HasPermission("permission.manage")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _permissionService.GetAllAsync();
        return Ok(result);
    }

    [HasPermission("permission.manage")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _permissionService.GetByIdAsync(id);
        return Ok(result);
    }

    [HasPermission("permission.manage")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePermissionDto request)
    {
        var result = await _permissionService.CreateAsync(request);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
    }

    [HasPermission("permission.manage")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdatePermissionDto request)
    {
        var result = await _permissionService.UpdateAsync(id, request);
        return Ok(result);
    }

    [HasPermission("permission.manage")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _permissionService.DeleteAsync(id);
        return Ok(result);
    }
}
