using AutoMapper;
using ZLShop.Models.Entities;
using ZLShop.DTOs.Address;

namespace ZLShop.Mapping.Address;

public class AddressProfile : Profile{
    public AddressProfile(){
        CreateMap<UserAddress, AddressResponseDto>();
        CreateMap<CreateAddressDto, UserAddress>();
        CreateMap<UpdateAddressDto, UserAddress>();
    }
}