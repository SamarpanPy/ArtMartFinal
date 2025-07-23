using ArtMart.Data;
using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtMart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            var result = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            
            var y =_context.Products.Add(product);
            await _context.SaveChangesAsync();
            var result = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id== y.Entity.Id);
            return result;
        }

        public async Task<Product?> UpdateAsync(string id, Product updatedProduct)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;

            existing.Title = updatedProduct.Title;
            existing.Description = updatedProduct.Description;
            existing.Price = updatedProduct.Price;
            existing.ImageUrl = updatedProduct.ImageUrl;
            existing.Category = updatedProduct.Category;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
