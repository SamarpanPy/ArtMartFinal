using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IRatingRepository
    {
        Task RateProductAsync(string userId, int productId, int stars, string? comment);
        Task<List<Rating>> GetRatingsForProductAsync(int productId);
        Task<double> GetAverageRatingAsync(int productId);
    }
}
