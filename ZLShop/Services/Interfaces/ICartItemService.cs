using ZLShop.DTOs.CartItems;

namespace ZLShop.Services.Interfaces;

public interface ICartItemService
{
    Task<List<CartItemResponseDto>> GetAllCartAsync();
    Task<CartItemResponseDto> AddCartAsync(CreateCartItemDto request);
    Task<CartItemResponseDto> UpdateCartAsync(int id, UpdateCartItemDto request);
    Task<CartItemResponseDto> DeleteCartAsync(int id);
}