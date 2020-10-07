using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komo
{
    public enum FoodTypeDay
    {
        Breakfast = 1,
        Lunch,
        Dinner
    }
    public class Options
    {
        public FoodTypeDay Type { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        
        public decimal Price { get; set; }
        public bool DealBuy
        {
            get
            {
                if (Price >= 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public string DisplayIngdnts(List<string> listOfIngdnts)
        {
            string ingredients = string.Join(", ", listOfIngdnts);
            return ingredients;
        }
        public Options()
        {

        }
        public Options(FoodTypeDay foodType, string name, int number, string description, List<string> ingredients, decimal price)
        {
            Type = foodType;
            Name = name;
            Number = number;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

    }
}