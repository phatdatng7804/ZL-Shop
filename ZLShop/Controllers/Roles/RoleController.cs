using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Roles;
using ZLShop.Auth;

namespace ZLShop.Controllers.Roles;

[ApiController]
[Route("api/[controller]")]
public class RoleController(IRoleService _roleService) : ControllerBase
{
    [HasPermission("role.manage")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _roleService.GetAllAsync();
        return Ok(result);
    }

    [HasPermission("role.manage")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _roleService.GetByIdAsync(id);
        return Ok(result);
    }

    [HasPermission("role.manage")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRoleDto request)
    {
        var result = await _roleService.CreateAsync(request);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
    }

    [HasPermission("role.manage")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRoleDto request)
    {
        var result = await _roleService.UpdateAsync(id, request);
        return Ok(result);
    }

    [HasPermission("role.manage")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _roleService.DeleteAsync(id);
        return Ok(result);
    }
}
