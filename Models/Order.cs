namespace Labb1___LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        // Foreign key referencing the customer who placed the order
        public int CustomerId { get; set; }

        public int TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        // Navigation property: one order can have multiple order details (products)
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
    // Enum representing possible statuses for an order
    public enum OrderStatus
    {
        Processing,
        Shipped,
        Delivered,
    }
}
