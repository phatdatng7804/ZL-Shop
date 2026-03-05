using ZLShop.DTOs.Auth;

namespace ZLShop.Services.Interfaces;

public interface IAuthService
{
    //Task<string> Login(LoginRequestDto request);
    Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
}