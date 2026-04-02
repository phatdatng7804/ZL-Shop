using ZLShop.Data;
using ZLShop.DTOs.CartItems;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZLShop.Models.Entities;
using ZLShop.Exceptions;
namespace ZLShop.Services.CartItems;

public class CartItemService : ICartItemService
{
    private readonly AppDbContext _context;
    public CartItemService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<CartItemResponseDto> AddCartAsync(CreateCartItemDto request)
    {
        var isExist = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductVariantId == request.ProductVariantId);
        if(isExist != null)
        {
            isExist.Quantity += request.Quantity;
            isExist.Price  *= request.Quantity;
            await _context.SaveChangesAsync();
            return new CartItemResponseDto{
                Quantity = isExist.Quantity,
                Price = isExist.Price
            };
        }

        var price = await _context.ProductVariants.Select(p => new {p.Price,p.Id}).FirstAsync(p => p.Id == request.ProductVariantId);
        var cart = new CartItem
        {
            Quantity = request.Quantity,
            Price = price.Price,
            TotalPrice = price.Price * request.Quantity,
            ProductVariantId = request.ProductVariantId
        };
        await _context.CartItems.AddAsync(cart);
        await _context.SaveChangesAsync();
        return new CartItemResponseDto{
            Quantity = cart.Quantity,
            Price = cart.Price
        };
    }

}