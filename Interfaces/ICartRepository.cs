using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsByUserAsync(int userId);
        Task<CartItem?> GetCartItemAsync(int userId, int productId);
        Task<CartItem> AddOrUpdateCartItemAsync(CartItem cartItem);
        Task<bool> RemoveCartItemAsync(int userId, int productId);
        Task<bool> ClearCartAsync(int userId);
    }
}
