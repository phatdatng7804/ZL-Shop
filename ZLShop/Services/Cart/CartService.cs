using ZLShop.Services.Interfaces;
using ZLShop.Data;
using ZLShop.DTOs.Cart;
using ZLShop.Exceptions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ZLShop.Services.Cart;
public class CartService(AppDbContext _context, IMapper _mapper) : ICartService
{
    public async Task<ResponseCartDto> GetCartAsync()
    {
        var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync();
        return _mapper.Map<ResponseCartDto>(cart);
    }
    public async Task<ResponseCartDto> DeleteCartAsync()
    {
        var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync();
        if(cart == null)
        {
            throw new BadRequestException("Cart item không tồn tại!");
        }
        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
        return _mapper.Map<ResponseCartDto>(cart);
    }
}