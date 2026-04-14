using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ZLShop.Models.Entities;
using ZLShop.Data;
using ZLShop.DTOs.Address;
using ZLShop.Services.Interfaces;
using ZLShop.Exceptions;
namespace ZLShop.Services.Address;

public class UserAddressService(AppDbContext _context, IMapper _mapper) : IUserAddressService
{
    public async Task<List<AddressResponseDto>> GetAllAsync(){
        return await _context.UserAddresses
        .ProjectTo<AddressResponseDto>(_mapper.ConfigurationProvider)
        .ToListAsync();            
    }
    public async Task<List<AddressResponseDto>> GetByUserIdAsync(int userId){
        return await _context.UserAddresses
        .Where(x => x.UserId == userId)
        .ProjectTo<AddressResponseDto>(_mapper.ConfigurationProvider)
        .ToListAsync();            
    }
    public async Task<AddressResponseDto> GetAddressByIdAsync(int id){
        var address = await _context.UserAddresses.FindAsync(id);
        return _mapper.Map<AddressResponseDto>(address);
    }
    public async Task<AddressResponseDto> CreateAddressAsync(CreateAddressDto dto){
        var address = _mapper.Map<UserAddress>(dto);
        _context.UserAddresses.Add(address);
        await _context.SaveChangesAsync();
        return _mapper.Map<AddressResponseDto>(address);
    }
    public async Task<AddressResponseDto> UpdateAddressAsync(int id, UpdateAddressDto dto){
        var address = await _context.UserAddresses.FindAsync(id);
        if (address == null) 
            throw new NotFoundException($"Address với Id={id} không tồn tại");
        _mapper.Map(dto, address);
        await _context.SaveChangesAsync();
        return _mapper.Map<AddressResponseDto>(address);
    }
    public async Task<bool> DeleteAddressAsync(int id){
        var address = await _context.UserAddresses.FindAsync(id);
        if (address == null) 
            throw new NotFoundException($"Address với Id={id} không tồn tại");
        _context.UserAddresses.Remove(address);
        await _context.SaveChangesAsync();
        return true;
    }
}