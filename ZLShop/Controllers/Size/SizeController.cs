using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Size;
using ZLShop.Exceptions;
namespace ZLShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SizeController : ControllerBase
{
    private readonly ISizeService _sizeService;
    public SizeController(ISizeService sizeService)
    {
        _sizeService = sizeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var size = await _sizeService.GetAllAsync();
        return Ok(size);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var size = await _sizeService.GetByIdAsync(id);
        return Ok(size);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSizeDto request)
    {
        var size = await _sizeService.CreateSizeAsync(request);
        return CreatedAtAction("GetById", new{id = size.Id}, size);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSizeDto request)
    {
        var size = await _sizeService.UpdateSizeAsync(id, request);
        return Ok(size);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var size = await _sizeService.DeleteAsync(id);
        return Ok(size);
    }
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var size = await _sizeService.GetDeletedAsync();
        return Ok(size);
    }
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var size = await _sizeService.RestoreAsync(id);
        return Ok(size);
    }
}