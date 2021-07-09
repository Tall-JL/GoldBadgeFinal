

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePOCO
{
    public class MenuItem 
    {        
        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public decimal Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(string mealNumber, string mealName, string description, List<Ingredient> ingredients, decimal price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
