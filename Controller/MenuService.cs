using Labb1___LINQ.Models;
using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Controller
{
    public class MenuService
    {
        /// This class is responsible for managing the menu and its items
        public MenuService() 
        {
        }

        public static void ShowElectronics()
        {
            using (var context = new EShopContext()) 
            {
                var electronics = context.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .ToList();
                Console.WriteLine("Electronics:");
                Console.WriteLine($"Found {electronics.Count} electronics.");

                foreach (var product in electronics)
                {
                    Console.WriteLine($"- {product.Name} ({product.Price} SEK)");
                }
            }
        }
         
    }
}

