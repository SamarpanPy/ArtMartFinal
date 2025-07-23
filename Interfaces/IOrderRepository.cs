using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrderAsync(string userId);
        Task<List<Order>> GetOrdersByUserAsync(string userId);
    }
}
