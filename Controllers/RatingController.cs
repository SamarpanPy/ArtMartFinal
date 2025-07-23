using ArtMart.Interfaces;
using ArtMart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtMart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepo;

        public RatingController(IRatingRepository ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }

        private string GetUserId() =>
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        [Authorize(Roles = "Customer")]
        [HttpPost("{productId}")]
        public async Task<IActionResult> RateProduct(int productId, [FromBody] RatingDto dto)
        {
            if (dto.Stars < 1 || dto.Stars > 5)
                return BadRequest("Stars must be between 1 and 5");

            await _ratingRepo.RateProductAsync(GetUserId(), productId, dto.Stars, dto.Comment);
            return Ok(new { message = "Rating submitted." });
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetRatings(int productId)
        {
            var ratings = await _ratingRepo.GetRatingsForProductAsync(productId);
            return Ok(ratings);
        }

        [HttpGet("{productId}/average")]
        public async Task<IActionResult> GetAverageRating(int productId)
        {
            var avg = await _ratingRepo.GetAverageRatingAsync(productId);
            return Ok(new { averageRating = Math.Round(avg, 2) });
        }
    }

    public class RatingDto
    {
        public int Stars { get; set; }
        public string? Comment { get; set; }
    }
}
