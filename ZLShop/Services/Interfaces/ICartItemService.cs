using ZLShop.DTOs.CartItem;

namespace ZLShop.Services.Interfaces;

public interface ICartItemService
{
    // Task<List<CartItemResponseDto>> GetAllAsync();
    // Task<CartItemResponseDto> GetByIdAsync(int id);
    Task<CartItemResponseDto> CreateAsync(CreateCartItemDto request);
    // Task<CartItemResponseDto> UpdateAsync(int id, UpdateCartItemDto request);
    // Task<bool> DeleteAsync(int id);
}