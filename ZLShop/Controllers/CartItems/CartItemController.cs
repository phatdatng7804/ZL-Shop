using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.CartItems;
using ZLShop.Exceptions;

namespace ZLShop.Controllers.CartItems;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : ControllerBase
{
    private readonly ICartItemService _cartItemService;
    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }
    [HttpPost]
    public async Task<ActionResult<CartItemResponseDto>> CreateAsync(CreateCartItemDto request)
    {
            var cartItem = await _cartItemService.AddCartAsync(request);
            return Ok(cartItem);
    }
    // [HttpPut]
    // public async Task<ActionResult<CartItemResponseDto>> UpdateAsync(int id, UpdateCartItemDto request)
    // {
    //     try
    //     {
    //         var cartItem = await _cartItemService.UpdateAsync(id, request);
    //         return Ok(cartItem);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }
    // [HttpDelete]
    // public async Task<ActionResult<bool>> DeleteAsync(int id)
    // {
    //     try
    //     {
    //         var result = await _cartItemService.DeleteAsync(id);
    //         return Ok(result);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }
    // [HttpGet]
    // public async Task<ActionResult<List<CartItemResponseDto>>> GetAllAsync()
    // {
    //     try
    //     {
    //         var cartItems = await _cartItemService.GetAllAsync();
    //         return Ok(cartItems);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }
    // [HttpGet("{id}")]
    // public async Task<ActionResult<CartItemResponseDto>> GetByIdAsync(int id)
    // {
    //     try
    //     {
    //         var cartItem = await _cartItemService.GetByIdAsync(id);
    //         return Ok(cartItem);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }
}
