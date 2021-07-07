using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePOCO
{
    public class Ingredient
    {
        public string Name { get; set; }

        public Ingredient()
        {

        }
        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
