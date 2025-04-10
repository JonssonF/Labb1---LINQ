using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Category
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;

        // Navigation property: one category can be linked to many products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    
    }
}
