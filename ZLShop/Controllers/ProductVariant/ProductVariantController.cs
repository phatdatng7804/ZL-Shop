using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.ProductVariant;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Auth;

namespace ZLShop.Controllers.ProductVariant;

[ApiController]
[Route("api/[controller]")]
public class ProductVariantController(IProductVariantService _productVariantService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var variants = await _productVariantService.GetAllAsync();
        return Ok(variants);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var variant = await _productVariantService.GetByIdAsync(id);
        return Ok(variant);
    }
    [HasPermission("product_variant.create")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductVariantDto request)
    {
        var variant = await _productVariantService.CreateAsync(request);
        return CreatedAtAction("GetById", new { id = variant.Id }, variant);
    }
    [HasPermission("product_variant.update")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateProductVariantDto request)
    {
        var variant = await _productVariantService.UpdateAsync(id, request);
        return Ok(variant);
    }
    [HasPermission("product_variant.delete")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var variant = await _productVariantService.DeleteAsync(id);
        return Ok(variant);
    }
    [HasPermission("product_variant.delete")]
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var variants = await _productVariantService.GetDeletedAsync();
        return Ok(variants);
    }
    [HasPermission("product_variant.delete")]
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var variant = await _productVariantService.RestoreAsync(id);
        return Ok(variant);
    }
}