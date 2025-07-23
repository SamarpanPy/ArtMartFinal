using System;

namespace ArtMart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
    lic DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
