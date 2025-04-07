using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Foreign key referencing the product's category
        [Required]
        public int CategoryId { get; set; }

        // Foreign key referencing the product's supplier
        [Required]
        public int SupplierId { get; set; }

        // Navigation property: the category this product belongs to
        public Category Category { get; set; } = null!;

        // Navigation property: the supplier providing this product
        public Supplier Supplier { get; set; } = null!;

    }
}