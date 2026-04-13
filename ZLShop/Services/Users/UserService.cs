using ZLShop.Data;
using ZLShop.DTOs.Users;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZLShop.Exceptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ZLShop.Models.Entities;
namespace ZLShop.Services.Users;

public class UserService(AppDbContext _context, IMapper _mapper) : IUserService{
    public async Task<List<UserResponseDto>> GetAllAsync(){
        return await _context.Users
        .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
        .ToListAsync();            
    }
    public async Task<UserResponseDto> GetByIdAsync(int id){
        var user = await _context.Users
        .Where(x => x.Id == id)
        .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();
        if (user == null) 
            throw new NotFoundException($"User với Id={id} không tồn tại");
        return user;
    }
    public async Task<UserResponseDto> CreateUserAsync(CreateUserDto request){
        var user = _mapper.Map<User>(request);
        if(await _context.Users.AnyAsync(x => x.Username == request.Username))
            throw new BadRequestException("Username đã tồn tại");
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserResponseDto>(user);
    }
    public async Task<UserResponseDto> UpdateUserAsync(int id, UpdateUserDto request){
        var user = await _context.Users.FindAsync(id);
        if (user == null) 
            throw new NotFoundException($"User với Id={id} không tồn tại");
        _mapper.Map(request, user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserResponseDto>(user);
    }
    public async Task<UserResponseDto> DeleteAsync(int id){
        var user = await _context.Users.FindAsync(id);
        if (user == null) 
            throw new NotFoundException($"User với Id={id} không tồn tại");
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserResponseDto>(user);
    }
}