using ArtMart.Data;
using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtMart.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly AppDbContext _context;

        public WishlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToWishlistAsync(string userId, string productId)
        {
            var alreadyExists = await _context.WishlistItems
                .AnyAsync(w => w.UserId == userId && w.ProductId == productId);

            if (!alreadyExists)
            {
                var item = new WishlistItem
                {
                    UserId = userId,
                    ProductId = productId
                };

                _context.WishlistItems.Add(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWishlistAsync(string userId, string productId)
        {
            var item = await _context.WishlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (item != null)
            {
                _context.WishlistItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetWishlistItemsAsync(string userId)
        {
            var productIds = await _context.WishlistItems
                .Where(w => w.UserId == userId)
                .Select(w => w.ProductId)
                .ToListAsync();

            return await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }
    }
}
