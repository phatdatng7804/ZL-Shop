using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Products;

namespace ZLShop.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto request)
    {
        var product = await _productService.CreateAsync(request);
        return CreatedAtAction("GetById", new { id = product.Id }, product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProductDto request)
    {
        var product = await _productService.UpdateAsync(id, request);
        return Ok(product);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var product = await _productService.DeleteAsync(id);
        return Ok(product);
    }
    [HttpGet("deleted")]
    public async Task<IActionResult> GetDeletedAsync()
    {
        var products = await _productService.GetDeletedAsync();
        return Ok(products);
    }
    [HttpPut("{id}/restore")]
    public async Task<IActionResult> RestoreAsync(int id)
    {
        var product = await _productService.RestoreAsync(id);
        return Ok(product);
    }
}