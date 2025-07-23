namespace ArtMart.Models
{
    public class OrderItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
