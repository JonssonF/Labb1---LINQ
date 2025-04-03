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
    
        
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    
    }
}
