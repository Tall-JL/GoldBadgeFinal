using CafePOCO;
using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeUI
{
    class ProgramUI
    {
        private MenuItemRepo _items = new MenuItemRepo(); 
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                "1. View Menu Items\n" +
                "2. Create Menu Item\n" +
                "3. Add Ingredient to Item\n" +
                "4. Delete Menu Item\n" +
                "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewMenuItems();
                        break;
                    case "2":
                        CreateMenuItem();
                        break;
                    case "3":
                        AddIngredientToItem();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DeleteMenuItem()
        {
            throw new NotImplementedException();
        }

        private void AddIngredientToItem()
        {
            throw new NotImplementedException();
        }

        private void CreateMenuItem()
        {
            throw new NotImplementedException();
        }

        private void ViewMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Below are the items we have available");
            List<MenuItem> listOfItems = new List<MenuItem>();

            foreach (var item in listOfItems)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Description: {item.Description}\n" +
                    $"Price: {item.Price}\n");
            }

        }

        public void ViewIngredientsOnItem()
        {
            Console.Clear();

            ViewMenuItems();
            Console.WriteLine("What menu item number would you like to see ingredients for?");
            string input = Console.ReadLine();

            MenuItem foodToCheck = _items.GetMenuItemByNumber(input);
            foreach (Ingredient ingredient in foodToCheck.Ingredients)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
    }
}
