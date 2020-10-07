using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komo
{
    public class FoodRepository
    {
        protected readonly List<Options> _allMeals = new List<Options>();
        public bool AddMealsToMenu(Options meal)
        {
            int startingCount = _allMeals.Count;
            _allMeals.Add(meal);
            bool wasAdded = (_allMeals.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool DeleteExistingMenuItem(Options existingMeal)
        {
            bool wasDeleted = _allMeals.Remove(existingMeal);
            return wasDeleted;
        }

        public List<Options> GetItemsFromMenu()
        {
            return _allMeals;
        }

        public Options GetMealByName(string name)
        {
            foreach (Options meal in _allMeals)
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
                else
                {
                    Console.WriteLine("Sorry, response not recognized.");
                }
            }
            return null;
        }

    }

}
