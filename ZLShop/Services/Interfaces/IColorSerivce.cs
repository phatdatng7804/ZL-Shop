using ZLShop.DTOs.Color;

namespace ZLShop.Services.Interfaces;
public interface IColorService{
    Task<List<ColorResponseDto>> GetAllAsync();
    Task<ColorResponseDto> GetByIdAsync(int id);
    Task<ColorResponseDto> CreateColorAsync(CreateColorDto dto);
    Task<ColorResponseDto> UpdateColorAsync(int id, UpdateColorDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<ColorResponseDto>> GetDeletedAsync();
    Task<bool> RestoreAsync(int id);
}