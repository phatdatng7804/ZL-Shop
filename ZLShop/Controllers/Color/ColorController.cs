using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Color;
using ZLShop.Exceptions;

namespace ZLShop.Controllers.Color;

[ApiController]
[Route("api/[controller]")]
public class ColorController(IColorService _colorService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var colors = await _colorService.GetAllAsync();
        return Ok(colors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var color = await _colorService.GetByIdAsync(id);
        return Ok(color);
    }
    [HttpPost]
    public async Task<IActionResult> CreateColorAsync([FromBody]CreateColorDto request)
    {
        var color = await _colorService.CreateColorAsync(request);
        return CreatedAtAction("GetById", new { id = color.Id }, color);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColorAsync(int id, [FromBody]UpdateColorDto request)
    {
        var color = await _colorService.UpdateColorAsync(id, request);
        return Ok(color);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var color = await _colorService.DeleteAsync(id);
        return Ok(color);
    }
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var colors = await _colorService.GetDeletedAsync();
        return Ok(colors);
    }
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var color = await _colorService.RestoreAsync(id);
        return Ok(color);
    }
}