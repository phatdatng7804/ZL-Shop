using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Size;
using ZLShop.Exceptions;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Auth;

namespace ZLShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SizeController(ISizeService _sizeService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var size = await _sizeService.GetAllAsync();
        return Ok(size);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var size = await _sizeService.GetByIdAsync(id);
        return Ok(size);
    }
    [HasPermission("size.create")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSizeDto request)
    {
        var size = await _sizeService.CreateSizeAsync(request);
        return CreatedAtAction("GetById", new{id = size.Id}, size);
    }
    [HasPermission("size.update")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSizeDto request)
    {
        var size = await _sizeService.UpdateSizeAsync(id, request);
        return Ok(size);
    }
    [HasPermission("size.delete")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var size = await _sizeService.DeleteAsync(id);
        return Ok(size);
    }
    [HasPermission("size.delete")]
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var size = await _sizeService.GetDeletedAsync();
        return Ok(size);
    }
    [HasPermission("size.delete")]
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var size = await _sizeService.RestoreAsync(id);
        return Ok(size);
    }
}