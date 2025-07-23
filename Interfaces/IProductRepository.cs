using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product updatedProduct);
        Task<bool> DeleteAsync(int id);
    }
}
