﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ArtMart.Models
{
    public class CartItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // User who owns the cart item
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        // Product added to cart
        public string ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; } = 1;

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
