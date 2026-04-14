using ZLShop.DTOs.Address;

namespace ZLShop.Services.Interfaces;

public interface IUserAddressService
{
    Task<List<AddressResponseDto>> GetAllAsync();
    Task<List<AddressResponseDto>> GetByUserIdAsync(int userId);
    Task<AddressResponseDto> GetAddressByIdAsync(int id);
    Task<AddressResponseDto> CreateAddressAsync(CreateAddressDto dto);
    Task<AddressResponseDto> UpdateAddressAsync(int id, UpdateAddressDto dto);
    Task<bool> DeleteAddressAsync(int id);
}