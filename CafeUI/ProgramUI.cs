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
        private MenuItemRepo _itemsOnMenu = new MenuItemRepo();
        
        
        
        public void Run()
        {
            SeedMenuItem();
            Menu();
        }       
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                "1. View Menu Items\n" +
                "2. View Ingredients on food item\n" +
                "3. Create Menu Item\n" +                
                "4. Delete Menu Item\n" +
                "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewMenuItems();
                        break;
                    case "2":
                        ViewIngredientsOnItem();
                        break;
                    case "3":
                        CreateMenuItem();
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
        private bool DeleteMenuItem()
        {
            Console.Clear();

            Console.WriteLine("What is the meal number of the item you'd like to delete?");
            string input = Console.ReadLine();

            bool success = _itemsOnMenu.DeleteMenuItem(input);

            if (success)
            {
                Console.WriteLine("You've deleted item!!");
                return true;
            }
            else
            {
                return false;
            }
        }      
        private bool CreateMenuItem()
        {
            Console.Clear();

            MenuItem newItem = new MenuItem();

            Console.WriteLine("What will the meal number be for this item?");
            newItem.MealNumber = Console.ReadLine();

            Console.WriteLine("What is the name of your meal item?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the description of the meal item?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("What is the price for this item?");
            newItem.Price = Convert.ToDecimal(Console.ReadLine());         

            bool wantsMore = true;
            while (wantsMore)
            {
                Console.WriteLine("Do you have ingredients to add? (yes/no)");
                string input = Console.ReadLine();
                if (input == "yes")
                {
                    Ingredient newIng = new Ingredient();

                    Console.WriteLine("What is the ingredient?");
                    newIng.Name = Console.ReadLine();

                    newItem.Ingredients.Add(newIng);                                      
                    
                }
                else
                {
                    wantsMore = false;
                }
            }

            bool success = _itemsOnMenu.AddItemToMenu(newItem);

            if (success)
            {
                Console.WriteLine("New item made!");
                return true;
            }
            else
            {
                return false;
            }
        }        
        private void ViewMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Below are the items we have available");
            List<MenuItem> listOfItems = new List<MenuItem>();

            foreach (var item in _itemsOnMenu._items)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Description: {item.Description}\n" +
                    $"Price: ${item.Price}\n");
            }

        }
        public void ViewIngredientsOnItem()
        {
            Console.Clear();

            ViewMenuItems();
            Console.WriteLine("What menu item number would you like to see ingredients for?");
            string input = Console.ReadLine();

            MenuItem foodToCheck = _itemsOnMenu.GetMenuItemByNumber(input);
            foreach (Ingredient ingredient in foodToCheck.Ingredients)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
        private void SeedMenuItem()
        {
            Ingredient ing1 = new Ingredient("Nuts");
            Ingredient ing2 = new Ingredient("Dark Chocolate");
            Ingredient ing3 = new Ingredient("Bacon");
            Ingredient ing4 = new Ingredient("Eggs");
            Ingredient ing5 = new Ingredient("Cheese");


            MenuItem food1 = new MenuItem("1", "Bacon, Egg and Cheese Sandwich", "Relax with this tasty treat!", new List<Ingredient> { ing3, ing4, ing5 }, 4.50m);
            MenuItem food2 = new MenuItem("2", "Brownie", "Dark Chocolate never taste so good!", new List<Ingredient> { ing1, ing2 }, 2.50m);
            MenuItem food3 = new MenuItem("3", "Coffee", "You're the same without your first cup!", new List<Ingredient> { }, 3m);
            MenuItem food4 = new MenuItem("4", "Frappe", "Gain that extra weight with a morning coffee milkshake!", new List<Ingredient> { }, 5m);


            _itemsOnMenu.AddIngredientToItem(food1, "Bacon");
            _itemsOnMenu.AddIngredientToItem(food1, "Eggs");
            _itemsOnMenu.AddIngredientToItem(food1, "Cheese");
            _itemsOnMenu.AddIngredientToItem(food2, "Dark Chocolate");
            _itemsOnMenu.AddIngredientToItem(food2, "Nuts");

            _itemsOnMenu.AddItemToMenu(food1);
            _itemsOnMenu.AddItemToMenu(food2);
            _itemsOnMenu.AddItemToMenu(food3);
            _itemsOnMenu.AddItemToMenu(food4);
        }
    }
}
