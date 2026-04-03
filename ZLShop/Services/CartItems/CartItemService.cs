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
    public async Task<List<CartItemResponseDto>> GetAllCartAsync()
    {
        var cartItems = await _context.CartItems.ToListAsync();
        if(!cartItems.Any())
        {
            throw new BadRequestException("Cart item không tồn tại!");
        }

        return cartItems.Select(cartItem => new CartItemResponseDto
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            ProductVariantId = cartItem.ProductVariantId,
            Quantity = cartItem.Quantity,
            Price = cartItem.Price,
            TotalPrice = cartItem.TotalPrice,
            CreatedAt = cartItem.CreatedAt,
            UpdatedAt = cartItem.UpdatedAt
        }).ToList();
    }
    public async Task<CartItemResponseDto> AddCartAsync(CreateCartItemDto request)
    {
        var variantData = await _context.ProductVariants
            .Where(p => p.Id == request.ProductVariantId)
            .Select(p => new 
            {
                ProductPrice = p.Price,
                ExistingCartItem = _context.CartItems.FirstOrDefault(c => c.ProductVariantId == p.Id)
            })
            .FirstOrDefaultAsync();
        if(variantData == null)
        {
            throw new BadRequestException("Product variant không tồn tại!");
        }
        if(variantData.ExistingCartItem != null)
        {
            var existingItem = variantData.ExistingCartItem;
            existingItem.Quantity += request.Quantity;
        
            existingItem.TotalPrice = existingItem.Quantity * existingItem.Price; 
            
            await _context.SaveChangesAsync();
            return new CartItemResponseDto{
                Quantity = existingItem.Quantity,
                Price = existingItem.Price
            };
        }
        var cart = new CartItem
        {
            Quantity = request.Quantity,
            Price = variantData.ProductPrice,
            TotalPrice = variantData.ProductPrice * request.Quantity,
            ProductVariantId = request.ProductVariantId
        };
        _context.CartItems.Add(cart);
        await _context.SaveChangesAsync();
        return new CartItemResponseDto{
            Quantity = cart.Quantity,
            Price = cart.Price
        };
    }
    public async Task<CartItemResponseDto> UpdateCartAsync(int id, UpdateCartItemDto request)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id);
        if(cartItem == null)
        {
            throw new BadRequestException("Cart item không tồn tại!");
        }
        cartItem.Quantity = request.Quantity;
        cartItem.TotalPrice = cartItem.Quantity * cartItem.Price;
        await _context.SaveChangesAsync();
        return new CartItemResponseDto{
            Quantity = cartItem.Quantity,
            Price = cartItem.Price,
            UpdatedAt = cartItem.UpdatedAt
        };
    }
    public async Task<CartItemResponseDto> DeleteCartAsync(int id)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id);
        if(cartItem == null)
        {
            throw new BadRequestException("Cart item không tồn tại!");
        }
        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return new CartItemResponseDto{
            Quantity = cartItem.Quantity,
            Price = cartItem.Price,
            UpdatedAt = cartItem.UpdatedAt
        };
    }
}