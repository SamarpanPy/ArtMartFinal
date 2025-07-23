using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IWishlistRepository
    {
        Task AddToWishlistAsync(string userId, string productId);
        Task RemoveFromWishlistAsync(string userId, string productId);
        Task<List<Product>> GetWishlistItemsAsync(string userId);
    }
}
