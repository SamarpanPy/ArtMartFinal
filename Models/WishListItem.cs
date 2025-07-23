namespace ArtMart.Models
{
    public class WishlistItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = string.Empty;
        public string ProductId { get; set; }
    }
}
