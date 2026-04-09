using ZLShop.DTOs.Cart;

namespace ZLShop.Services.Interfaces;

public interface ICartService
{
    Task<ResponseCartDto> GetCartAsync();
    Task<ResponseCartDto> DeleteCartAsync();
}