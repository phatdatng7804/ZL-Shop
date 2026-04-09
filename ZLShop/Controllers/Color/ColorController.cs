using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Color;
using ZLShop.Exceptions;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Auth;

namespace ZLShop.Controllers.Color;

[ApiController]
[Route("api/[controller]")]
public class ColorController(IColorService _colorService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var colors = await _colorService.GetAllAsync();
        return Ok(colors);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var color = await _colorService.GetByIdAsync(id);
        return Ok(color);
    }
    [HasPermission("color.create")]
    [HttpPost]
    public async Task<IActionResult> CreateColorAsync([FromBody]CreateColorDto request)
    {
        var color = await _colorService.CreateColorAsync(request);
        return CreatedAtAction("GetById", new { id = color.Id }, color);
    }
    [HasPermission("color.update")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColorAsync(int id, [FromBody]UpdateColorDto request)
    {
        var color = await _colorService.UpdateColorAsync(id, request);
        return Ok(color);
    }
    [HasPermission("color.delete")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var color = await _colorService.DeleteAsync(id);
        return Ok(color);
    }
    [HasPermission("color.delete")]
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var colors = await _colorService.GetDeletedAsync();
        return Ok(colors);
    }
    [HasPermission("color.delete")]
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var color = await _colorService.RestoreAsync(id);
        return Ok(color);
    }
}