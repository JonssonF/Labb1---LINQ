using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Supplier
    {

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? ContactPerson { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        //Navigation property: one Supplier can be linked to many products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
