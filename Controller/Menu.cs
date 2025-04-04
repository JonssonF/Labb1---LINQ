using System.Threading.Channels;

namespace Labb1___LINQ.Controller
{
    public class Menu
    {
        public Menu()
        { }


        public static void Run()
        {
            ShowMenu();
            MenuOptions();
            Console.WriteLine("\n\nThanks for watching!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the LINQ application!");
            Console.WriteLine("1. Show all orders");
            Console.WriteLine("2. Show all products");
            Console.WriteLine("3. Show all customers");
            Console.WriteLine("4. Show all order details");
            Console.WriteLine("5. Exit");
        }

        public static void MenuOptions()
        {
            int choice = GetChoice();
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        //Functions.ShowAllOrders();
                        break;
                    case 2:
                        //Functions.ShowAllProducts();
                        break;
                    case 3:
                        //Functions.ShowAllCustomers();
                        break;
                    case 4:
                        //Functions.ShowAllOrderDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                ShowMenu();
                choice = GetChoice();
            }
        }

        public static int GetChoice()
        {
            Console.Write("Please enter your choice: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1-5.");
                return GetChoice();
            }
        }
    }
}
