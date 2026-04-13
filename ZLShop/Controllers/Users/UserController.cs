using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
namespace ZLShop.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class UserController(IUserService _userService) : ControllerBase{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(){
        return Ok(await _userService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id){
        return Ok(await _userService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserDto request){
        return Ok(await _userService.CreateUserAsync(request));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserDto request){
        return Ok(await _userService.UpdateUserAsync(id, request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id){
        return Ok(await _userService.DeleteAsync(id));
    }
}