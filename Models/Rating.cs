namespace ArtMart.Models
{
    public class Rating
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = string.Empty;

        public string ProductId { get; set; }

        public int Stars { get; set; } // 1 to 5

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
