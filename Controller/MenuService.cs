using Labb1___LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Controller
{
    public class MenuService
    {
        // This class is responsible for managing the menu and its items
        //MenuOption 1
        public static void ShowElectronics()
        {
            Console.Clear();
            Console.WriteLine("Displays all products in category Electronics, price decending.\n\n");
            using (var context = new EShopContext())
            {
                var electronics = context.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price)
                    .ToList();
                Console.WriteLine("Electronics:");
                Console.WriteLine($"Found {electronics.Count} electronics.");
                Console.WriteLine("----------------------------------------------------------");
                foreach (var product in electronics)
                {
                    Console.WriteLine($"Name: {product.Name} - Price: {product.Price:C} ");
                }
                Console.WriteLine("----------------------------------------------------------");
            }
        }
        //MenuOption 2
        public static void ShowSuppliers()
        {
            Console.Clear();
            Console.WriteLine("Displays a list of suppliers that have a stock quantity below 10.");
            Console.WriteLine("----------------------------------------------------------");
            using (var context = new EShopContext())
            {
                var suppliers = context.Suppliers
                    .Include(s => s.Products)
                    .Where(s => s.Products.Any(p => p.StockQuantity < 10))
                    .ToList();

                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"Supplier: {supplier.Name} - Contact Person: {supplier.ContactPerson}");

                    foreach (var product in supplier.Products.Where(p => p.StockQuantity < 10))
                    {
                        Console.WriteLine($"Product: {product.Name} - Stock: {product.StockQuantity}");
                    }
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }
        //MenuOption 3
        public static void MonthlyOrders()
        {
            //Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
            Console.Clear();
            Console.WriteLine("Here is last month summary of orders:\n\n");
            Console.WriteLine("----------------------------------------------------------");
            using (var context = new EShopContext())
            {
                var lastMonth = DateTime.Now.AddMonths(-1);
                var totalOrderValue = context.Orders
                    .Where(o => o.OrderDate >= lastMonth)
                    .Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Product.Price));
                Console.WriteLine($"Total amount of orders {totalOrderValue.ToString().Count()}");
                Console.WriteLine($"Total order value for the last month: {totalOrderValue:C}");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
        //MenuOption 4
        public static void TopProducts()
        {
            //Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        }
        //MenuOption 5
        public static void CategoriesAndProducts()
        {
            //Lista alla kategorier och antalet produkter i varje kategori
        }
        //MenuOption 6
        public static void BigSpenders()
        {
            //Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        }
    }
}

