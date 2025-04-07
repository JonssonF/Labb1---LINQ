namespace Labb1___LINQ.Models
{
    public class OrderDetail
    {

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        // Navigation property: the related product to the order details
        public Product Product { get; set; } = null!;

        // Navigation property: the related order to the order details
        public Order Order { get; set; } = null!;



    }
}
