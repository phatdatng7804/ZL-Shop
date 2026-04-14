using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.Auth;
using Microsoft.AspNetCore.Authorization;
namespace ZLShop.Controllers.Carts;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController(ICartService _service) : ControllerBase
{
    [HasPermission("cart.view")]
    [HttpGet]
    public async Task<IActionResult> GetCart(){
        return Ok(await _service.GetCartAsync());
    }
    [HasPermission("cart.delete")]
    [HttpDelete]
    public async Task<IActionResult> Delete(){
        return Ok(await _service.DeleteCartAsync());
    }
}