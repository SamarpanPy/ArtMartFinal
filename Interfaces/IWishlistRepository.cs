using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IWishlistRepository
    {
        Task AddToWishlistAsync(string userId, int productId);
        Task RemoveFromWishlistAsync(string userId, int productId);
        Task<List<Product>> GetWishlistItemsAsync(string userId);
    }
}
