﻿namespace ArtMart.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}
