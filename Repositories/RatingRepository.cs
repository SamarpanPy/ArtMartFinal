using ArtMart.Data;
using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtMart.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task RateProductAsync(string userId, int productId, int stars, string? comment)
        {
            var existingRating = await _context.Ratings
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);

            if (existingRating != null)
            {
                existingRating.Stars = stars;
                existingRating.Comment = comment;
                existingRating.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                var newRating = new Rating
                {
                    UserId = userId,
                    ProductId = productId,
                    Stars = stars,
                    Comment = comment
                };

                _context.Ratings.Add(newRating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Rating>> GetRatingsForProductAsync(int productId)
        {
            return await _context.Ratings
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<double> GetAverageRatingAsync(int productId)
        {
            return await _context.Ratings
                .Where(r => r.ProductId == productId)
                .Select(r => (double)r.Stars)
                .DefaultIfEmpty(0)
                .AverageAsync();
        }
    }
}
