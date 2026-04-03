using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.ProductVariant;

namespace ZLShop.Controllers.ProductVariant;

[ApiController]
[Route("api/[controller]")]
public class ProductVariantController(IProductVariantService _productVariantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var variants = await _productVariantService.GetAllAsync();
        return Ok(variants);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var variant = await _productVariantService.GetByIdAsync(id);
        return Ok(variant);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductVariantDto request)
    {
        var variant = await _productVariantService.CreateAsync(request);
        return CreatedAtAction("GetById", new { id = variant.Id }, variant);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateProductVariantDto request)
    {
        var variant = await _productVariantService.UpdateAsync(id, request);
        return Ok(variant);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var variant = await _productVariantService.DeleteAsync(id);
        return Ok(variant);
    }
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var variants = await _productVariantService.GetDeletedAsync();
        return Ok(variants);
    }
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var variant = await _productVariantService.RestoreAsync(id);
        return Ok(variant);
    }
}