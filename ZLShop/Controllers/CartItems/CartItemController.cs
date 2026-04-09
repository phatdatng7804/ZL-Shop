using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.CartItems;
using ZLShop.Exceptions;
using Microsoft.AspNetCore.Authorization;
using ZLShop.Auth;

namespace ZLShop.Controllers.CartItems;

[Route("api/[controller]")]
[ApiController]
public class CartItemController(ICartItemService _cartItemService) : ControllerBase
{
    [HasPermission("cart.view")]
    [HttpGet]
    public async Task<ActionResult<List<CartItemResponseDto>>> GetAllCartAsync()
    {
        var cartItems = await _cartItemService.GetAllCartAsync();
        return Ok(cartItems);
    }
    [HasPermission("cart.create")]
    [HttpPost]
    public async Task<ActionResult<CartItemResponseDto>> AddCartAsync(CreateCartItemDto request)
    {
        var cartItem = await _cartItemService.AddCartAsync(request);
        return Ok(cartItem);
    }
    [HasPermission("cart.update")]
    [HttpPut("{id}")]
    public async Task<ActionResult<CartItemResponseDto>> UpdateCartAsync(int id, UpdateCartItemDto request)
    {
        var cartItem = await _cartItemService.UpdateCartAsync(id, request);
        return Ok(cartItem);
    }
    [HasPermission("cart.delete")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<CartItemResponseDto>> DeleteCartAsync(int id)
    {
        var cartItem = await _cartItemService.DeleteCartAsync(id);
        return Ok(cartItem);
    }
}
