using CafePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class MenuItemRepo
    {
        public List<Ingredient> _ingredients = new List<Ingredient>();
        public List<MenuItem> _items = new List<MenuItem>();
        

        public bool AddItemToMenu (MenuItem item)
        {
            _items.Add(item);
            return true;
        }
        public bool AddIngredientToItem(MenuItem name, string ingredientName)
        {
            Ingredient foodItem = GetIngredientByName(ingredientName);

            if (name != null)
            {
                name.Ingredients.Add(foodItem);
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<MenuItem> GetMenuItems()
        {
            return _items;
        }
        public bool DeleteMenuItem(string mealNumber)
        {

            MenuItem item = GetMenuItemByNumber(mealNumber);

            if (item == null)
            {
                return false;
            }

            int count = _items.Count;
            _items.Remove(item);

            if (count > _items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MenuItem GetMenuItemByNumber(string mealNumber)
        {
            foreach (var item in _items)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        } 
        public Ingredient GetIngredientByName(string ingredientName)
        {
            foreach (var item in _ingredients)
            {
                if (item.Name == ingredientName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
