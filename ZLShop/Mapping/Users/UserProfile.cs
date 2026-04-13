using AutoMapper;
using ZLShop.Models.Entities;
using ZLShop.DTOs.Users;

namespace ZLShop.Mapping.Users;

public class UserProfile : Profile{
    public UserProfile(){
        CreateMap<User, UserResponseDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}