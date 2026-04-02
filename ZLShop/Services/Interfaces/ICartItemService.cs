using ZLShop.DTOs.CartItems;

namespace ZLShop.Services.Interfaces;

public interface ICartItemService
{
    // Task<List<CartItemResponseDto>> GetAllAsync();
    // Task<CartItemResponseDto> GetByIdAsync(int id);
    Task<CartItemResponseDto> AddCartAsync(CreateCartItemDto request);
    // Task<CartItemResponseDto> UpdateAsync(int id, UpdateCartItemDto request);
    // Task<bool> DeleteAsync(int id);
}