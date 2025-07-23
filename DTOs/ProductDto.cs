namespace ArtMart.DTOs
{
    public class ProductDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string CategoryId { get; set; }
    }
}
