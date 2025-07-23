using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(string id, Product updatedProduct);
        Task<bool> DeleteAsync(string id);
    }
}
