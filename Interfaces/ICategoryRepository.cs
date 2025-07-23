using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(string id);
        Task<Category> AddAsync(Category category);
        Task<bool> DeleteAsync(string id);
    }
}
