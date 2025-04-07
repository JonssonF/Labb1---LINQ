using System.Threading.Channels;

namespace Labb1___LINQ.Controller
{
    public class Menu
    {
        public Menu()
        { }

        // Method to run the menu
        public static void Run()
        {
            // Display the menu
            ShowMenu();
            // Call the method to handle menu options
            MenuOptions();

            //Jumps here when while loop is exited
            Console.WriteLine("\n\nThanks for watching!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the LINQ application!\n\n");
            Console.WriteLine("1. Show Electronic category");
            Console.WriteLine("2. Show Supplier product quantity below 10");
            Console.WriteLine("3. Total ordervalue of last month");
            Console.WriteLine("4. Top 3 sold items");
            Console.WriteLine("5. List products by category");
            Console.WriteLine("6. Flex the bigspenders with big bills");
            Console.WriteLine("7. Exit\n");
        }
        // Method to handle menu options
        public static void MenuOptions()
        {
            int choice = GetChoice();
            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:

                        MenuService.ShowElectronics();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        MenuService.ShowSuppliers();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 3:
                        MenuService.MonthlyOrders();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 4:
                        MenuService.TopProducts();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 5:
                        MenuService.CategoriesAndProducts();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 6:
                        MenuService.BigSpenders();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                ShowMenu();
                choice = GetChoice();
            }
        }

        // Method to get user input for menu choice
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
                Console.WriteLine("Invalid input, please enter a number between 1-7.");
                return GetChoice();
            }
        }
    }
}
