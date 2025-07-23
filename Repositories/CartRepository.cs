using ArtMart.Data;
using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtMart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByUserAsync(string userId)
        {
            return await _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.UserId == userId)
                .OrderByDescending(ci => ci.AddedAt)
                .ToListAsync();
        }

        public async Task<CartItem?> GetCartItemAsync(string userId, string productId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);
        }

        public async Task<CartItem> AddOrUpdateCartItemAsync(CartItem cartItem)
        {
            var existing = await GetCartItemAsync(cartItem.UserId, cartItem.ProductId);
            if (existing != null)
            {
                existing.Quantity += cartItem.Quantity;
                await _context.SaveChangesAsync();
                return existing;
            }

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<bool> RemoveCartItemAsync(string userId, string productId)
        {
            var existing = await GetCartItemAsync(userId, productId);
            if (existing == null) return false;

            _context.CartItems.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            var items = _context.CartItems.Where(ci => ci.UserId == userId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
