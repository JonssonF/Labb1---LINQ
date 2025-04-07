using Labb1___LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Controller
{
    public class MenuService
    {
        // This class is responsible for managing the menuoptions and its methods
        // It contains methods that are called from the main program to display data from the database
        // and perform various operations based on user input.
        // It uses Entity Framework Core to interact with the database and LINQ to query data.

        //MenuOption 1
        //Displays all products in category Electronics, price decending
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
        //Displays a list of suppliers that have a stock quantity below 10
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
        //Displays the total order amount and value for the last month
        public static void MonthlyOrders()
        {
            var lastMonth = DateTime.Now.AddMonths(-1);
            CurrentMonth month = (CurrentMonth)lastMonth.Month;
            Console.Clear();
            Console.WriteLine($"Here is the summary of orders made in: {month}\n\n");
            Console.WriteLine("----------------------------------------------------------");
            using (var context = new EShopContext())
            {
                var totalOrderValue = context.Orders
                    .Where(o => o.OrderDate >= lastMonth)
                    .Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Product.Price));
                Console.WriteLine($"Total amount of orders {totalOrderValue.ToString().Count()}");
                Console.WriteLine($"Total order value for the last month: {totalOrderValue:C}");
                Console.WriteLine("----------------------------------------------------------");
            }
        }

        //MenuOption 4
        //Displays the top 3 most sold products
        public static void TopProducts()
        {

            Console.Clear();
            Console.WriteLine("Top 3 most sold products:\n");
            Console.WriteLine("----------------------------------------------------------");
            using (var context = new EShopContext())
            {
                var topProducts = context.OrderDetails
                       .GroupBy(od => od.Product)
                       .Select(g => new
                       {
                           Product = g.Key,
                           TotalQuantity = g.Sum(od => od.Quantity)
                       })
                       .OrderByDescending(g => g.TotalQuantity)
                       .Take(3)
                       .ToList();
                foreach (var product in topProducts)
                {
                    Console.WriteLine($"Product: {product.Product.Name} - Total Sold: {product.TotalQuantity}");
                }
                Console.WriteLine("----------------------------------------------------------");
            }
        }

        //MenuOption 5
        //Displays all categories with their product count and product details
        public static void CategoriesAndProducts()
        {
            using (var context = new EShopContext())
            {
                var categories = context.Categories
                    .Include(c => c.Products)
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        ProductCount = c.Products.Count(),
                        CategoryProducts = c.Products.Select(p => new { p.Name, p.Price }).ToList()
                    })
                    .ToList();
                Console.Clear();
                Console.WriteLine("Categories and their product counts:\n");
                Console.WriteLine("----------------------------------------------------------");
                foreach (var category in categories)
                {
                    Console.WriteLine($"Category: {category.CategoryName} - Product Count: {category.ProductCount}");
                    Console.WriteLine("----------------------------------------------------------");

                    foreach (var p in category.CategoryProducts)
                    {
                        Console.WriteLine($"Product: {p.Name} - Price: {p.Price}");
                    }
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }

        //MenuOption 6
        //Displays all orders made with a total amount over 1000 kr, with order details
        public static void BigSpenders()
        {
            Console.Clear();
            Console.WriteLine("Big spenders with orders over 1000 kr:\n");
            Console.WriteLine("----------------------------------------------------------");
            using (var context = new EShopContext()) 
            {
                var bigSpenders = context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderDetails)
                    .Where(o => o.TotalAmount > 1000)
                    .Select(o => new
                    {
                        CustomerName = o.Customer.Name,
                        TotalAmount = o.TotalAmount,
                        OrderDate = o.OrderDate,
                        OrderDetails = o.OrderDetails.Select(od => new { od.Product.Name, od.Quantity, od.UnitPrice }),
                        Status = o.Status
                    })
                    .ToList();

                foreach (var order in bigSpenders)
                {
                    Console.WriteLine($"Customer: {order.CustomerName}\n" +
                        $"Total Amount: {order.TotalAmount:C}\n" +
                        $"Order Date: {order.OrderDate}\n" +
                        $"Orderstatus: {order.Status}");
                    Console.WriteLine("\nOrder Details:");
                    foreach (var od in order.OrderDetails)
                    {
                        Console.WriteLine($"Product: {od.Name} - Quantity: {od.Quantity} - Price: {od.UnitPrice:C}");
                    }
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }
    }
    //Enum for the current month to display it in the MonthlyOrders method.
    public enum CurrentMonth
    {
        Januari = 1,
        Februari,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}

