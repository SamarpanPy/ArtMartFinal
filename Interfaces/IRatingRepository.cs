using ArtMart.Models;

namespace ArtMart.Interfaces
{
    public interface IRatingRepository
    {
        Task RateProductAsync(string userId, string productId, int stars, string? comment);
        Task<List<Rating>> GetRatingsForProductAsync(string productId);
        Task<double> GetAverageRatingAsync(string productId);
    }
}
