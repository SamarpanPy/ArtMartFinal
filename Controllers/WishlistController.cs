using ArtMart.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtMart.Controllers
{
    [Authorize(Roles = "Customer")]
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistRepository _wishlistRepo;

        public WishlistController(IWishlistRepository wishlistRepo)
        {
            _wishlistRepo = wishlistRepo;
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToWishlist(int productId)
        {
            await _wishlistRepo.AddToWishlistAsync(GetUserId(), productId);
            return Ok(new { message = "Product added to wishlist." });
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromWishlist(int productId)
        {
            await _wishlistRepo.RemoveFromWishlistAsync(GetUserId(), productId);
            return Ok(new { message = "Product removed from wishlist." });
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            var products = await _wishlistRepo.GetWishlistItemsAsync(GetUserId());
            return Ok(products);
        }
    }
}
