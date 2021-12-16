using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.POCO
{

    public class Menu
    {
        public int MealNum { get; set; }
        public string Name { get; set; }
        public string MealDesc { get; set; }
        public string TypeOfIngredient { get; set; }
        public decimal Price { get; set; }

        public Menu() { }

        public Menu(int mealNum, string name, string mealDesc, string typeOfIngredient, decimal price)
        {
            MealNum = mealNum;
            Name = name;
            MealDesc = mealDesc;
            TypeOfIngredient = typeOfIngredient;
            Price = price;
        }
    }
}
