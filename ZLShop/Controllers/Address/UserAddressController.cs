using Microsoft.AspNetCore.Mvc;
using ZLShop.Services.Interfaces;
using ZLShop.DTOs.Address;

namespace ZLShop.Controllers.Address;

[ApiController]
[Route("api/[controller]")]
public class UserAddressController(IUserAddressService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        return Ok(await _service.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        return Ok(await _service.GetAddressByIdAsync(id));
    }
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId){
        return Ok(await _service.GetByUserIdAsync(userId));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressDto dto){
        return Ok(await _service.CreateAddressAsync(dto));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAddressDto dto){
        return Ok(await _service.UpdateAddressAsync(id, dto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        return Ok(await _service.DeleteAddressAsync(id));
    }
}