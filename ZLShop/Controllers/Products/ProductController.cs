using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Auth;

namespace ZLShop.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService _productService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }
    [HasPermission("product.create")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto request)
    {
        var product = await _productService.CreateAsync(request);
        return CreatedAtAction("GetById", new { id = product.Id }, product);
    }
    [HasPermission("product.update")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProductDto request)
    {
        var product = await _productService.UpdateAsync(id, request);
        return Ok(product);
    }
    [HasPermission("product.delete")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var product = await _productService.DeleteAsync(id);
        return Ok(product);
    }
    [HasPermission("product.delete")]
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var products = await _productService.GetDeletedAsync();
        return Ok(products);
    }
    [HasPermission("product.delete")]
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var product = await _productService.RestoreAsync(id);
        return Ok(product);
    }
}