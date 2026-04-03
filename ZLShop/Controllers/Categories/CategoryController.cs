using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;

namespace ZLShop.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _categoryService.GetAllAsync();
        return Ok(result);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        return Ok(result);
    }
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryDto request)
    {
        var result = await _categoryService.CreateAsync(request);
        return Ok(result);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCategoryDto request)
    {
        var result = await _categoryService.UpdateAsync(id, request);
        return Ok(result);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return Ok(result);
    }
    [Authorize]
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var result = await _categoryService.GetDeletedAsync();
        return Ok(result);
    }
    [Authorize] 
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var result = await _categoryService.RestoreAsync(id);
        return Ok(result);
    }
}
