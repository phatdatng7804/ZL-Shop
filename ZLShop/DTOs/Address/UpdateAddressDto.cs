
namespace ZLShop.DTOs.Address;

public class UpdateAddressDto{
    public string? ReceiverName { get; set; } 
    public string? Phone { get; set; } 
    public string? Address { get; set; } 
    public string? City { get; set; } 
    public string? District { get; set; } 
    public bool? IsDefault { get; set; } 
}