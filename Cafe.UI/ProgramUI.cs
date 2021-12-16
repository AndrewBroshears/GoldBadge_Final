using Cafe.POCO;
using Cafe.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.UI
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                    "Select a menu option:\n" +
                    "1. Create Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Item By Number\n" +
                    "4. Delete Menu Item\n" +
                    "99. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DisplayMenueItemsByNumber();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "99":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newMenu = new Menu();
            Console.WriteLine("Assign a number for the meal you want to create:");
            newMenu.MealNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Give the meal a name:");
            newMenu.Name = Console.ReadLine();
            Console.WriteLine("Enter the description of the meal:");
            newMenu.MealDesc = Console.ReadLine();
            Console.WriteLine("Enter the ingredients you want to include:");
            newMenu.TypeOfIngredient = Console.ReadLine();
            Console.WriteLine("What do you want the price to be?:");
            newMenu.Price = decimal.Parse(Console.ReadLine());

            _menuRepo.AddToMenu(newMenu);
        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Menu> menuList = _menuRepo.GetMenuItems();
            foreach(Menu item in menuList)
            {
                Console.WriteLine($"Meal Number: {item.MealNum}\n" +
                    $"Meal Name: {item.Name}");
            }
        }
        private void DisplayMenueItemsByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you'd like to see:");
            int mealNum = int.Parse(Console.ReadLine());
            Menu item = _menuRepo.GetMenuItemsByNum(mealNum);
            if(item != null)
            {
                Console.WriteLine($"Meal Number: {item.MealNum}\n" +
                    $"Meal Number: {item.Name}\n" +
                    $"Description: {item.MealDesc}\n" +
                    $"Ingredients: {item.TypeOfIngredient}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No items found by for that number.");
            }
        }
        private void DeleteMenuItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("\nEnter the meal number you would like to delete:");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _menuRepo.RemoveItemFromMenu(input);
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }
    }
}
