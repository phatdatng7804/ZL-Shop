using ZLShop.DTOs.Size;

namespace ZLShop.Services.Interfaces;

public interface ISizeService{
    Task<List<SizeResponseDto>> GetAllAsync();
    Task<SizeResponseDto> GetByIdAsync(int id);
    Task<SizeResponseDto> CreateSizeAsync(CreateSizeDto dto);
    Task<SizeResponseDto> UpdateSizeAsync(int id, UpdateSizeDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<SizeResponseDto>> GetDeletedAsync();
    Task<bool> RestoreAsync(int id);
}