using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsByUserAsync(string userId);
        Task<CartItem?> GetCartItemAsync(string userId, string productId);
        Task<CartItem> AddOrUpdateCartItemAsync(CartItem cartItem);
        Task<bool> RemoveCartItemAsync(string userId, string productId);
        Task<bool> ClearCartAsync(string userId);
    }
}
