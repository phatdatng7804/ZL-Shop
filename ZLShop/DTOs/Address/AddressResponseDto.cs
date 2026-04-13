namespace ZLShop.DTOs.Address;

public class AddressResponseDto{
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public string? ReceiverName { get; set; } 
    public string? Phone { get; set; } 
    public string? Address { get; set; } 
    public string? City { get; set; } 
    public string? District { get; set; } 
    public bool? IsDefault { get; set; } 
    public DateTime? CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; } 
}