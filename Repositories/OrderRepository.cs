using ArtMart.Data;
using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtMart.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> PlaceOrderAsync(string userId)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any()) throw new Exception("Cart is empty");

            var order = new Order
            {
                UserId = userId,
                TotalAmount = cartItems.Sum(c => c.Product.Price * c.Quantity),
                OrderItems = cartItems.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    ProductTitle = c.Product.Title,
                    ProductPrice = c.Product.Price,
                    Quantity = c.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cartItems); // clear cart
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}
