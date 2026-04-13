using ZLShop.DTOs.Users;
namespace ZLShop.Services.Interfaces;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto> GetByIdAsync(int id);
    Task<UserResponseDto> CreateUserAsync(CreateUserDto request);
    Task<UserResponseDto> UpdateUserAsync(int id, UpdateUserDto request);
    Task<UserResponseDto> DeleteAsync(int id);

}