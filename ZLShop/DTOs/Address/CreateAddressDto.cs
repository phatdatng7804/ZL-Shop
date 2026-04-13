using System.ComponentModel.DataAnnotations;

namespace ZLShop.DTOs.Address;

public class CreateAddressDto{
    public string? ReceiverName { get; set; } 
    public string? Phone { get; set; } 
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; } 
    [Required(ErrorMessage = "City is required")]
    public string? City { get; set; } 
    [Required(ErrorMessage = "District is required")]
    public string? District { get; set; } 
    public bool? IsDefault { get; set; } 
}