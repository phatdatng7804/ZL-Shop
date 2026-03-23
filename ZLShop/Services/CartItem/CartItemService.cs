using ZLShop.Data;
using ZLShop.Models.Entities;
using ZLShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Items = ZLShop.Models.Entities.CartItem;
using ZLShop.Exceptions;
namespace ZLShop.Services.CartItem;

public class CartItemService : ICartItemService
{
    private readonly AppDbContext _context;
    public CartItemService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<CartItemResponseDto> CreateAsync(CreateCartItemDto request)
    {
       var isExist = await _context.Set<Items>().FirstOrDefaultAsync(x => x.CartId == request.CartId && x.ProductVariantId == request.ProductVariantId);
       if(isExist != null)
       {
        isExist.Quantity += request.Quantity;
        isExist.TotalPrice = isExist.Price * isExist.Quantity;
        await _context.SaveChangesAsync();
        return new CartItemResponseDto
        {
            Id = isExist.Id,
            CartId = isExist.CartId,
            ProductVariantId = isExist.ProductVariantId,
            Quantity = isExist.Quantity,
            Price = isExist.Price,
            TotalPrice = isExist.TotalPrice
        };
       }
       var cartItem = new Items
       {
        CartId = request.CartId,
        ProductVariantId = request.ProductVariantId,
        Quantity = request.Quantity,
        Price = request.Price,
        TotalPrice = request.Price * request.Quantity
       };
       _context.Set<Items>().Add(cartItem);
       await _context.SaveChangesAsync();
       return new CartItemResponseDto
       {
        Id = cartItem.Id,
        CartId = cartItem.CartId,
        ProductVariantId = cartItem.ProductVariantId,
        Quantity = cartItem.Quantity,
        Price = ProductVariant.Price,
        TotalPrice = cartItem.TotalPrice,
        CreatedAt = cartItem.CreatedAt
       };
    }
}