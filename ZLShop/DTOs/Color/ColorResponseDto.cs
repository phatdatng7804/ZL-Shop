namespace ZLShop.DTOs.Color;

public class ColorResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string HexCode { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}