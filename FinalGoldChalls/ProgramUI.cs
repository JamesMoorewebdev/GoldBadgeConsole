using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komo
{
    public class ProgramUI
    {
        protected readonly FoodRepository _mealRepo = new FoodRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select and option below 1-4.\n" +
                    "1. Add a Menu Item. \n" +
                    "2. Delete a Menu Item. \n" +
                    "3. See all Menu Items. \n" +
                    "4. Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMeals();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number between 1 and 4 \n" +
                            "Press any key to continue...");
                        break;

                }
            }

        }
        private void AddMenuItem()
        {
            Console.Clear();
            Options newMeal = new Options();
            Console.WriteLine("Select a type of meal: \n" +
                "1) Breakfast \n" +
                "2) Lunch \n" +
                "3) Dinner");
            string foodTypeString = Console.ReadLine();
            switch (foodTypeString.ToLower())
            {
                case "1":
                case "breakfast":
                    newMeal.Type = FoodTypeDay.Breakfast;
                    break;
                case "2":
                case "lunch":
                    newMeal.Type = FoodTypeDay.Lunch;
                    break;
                case "3":
                case "dinner":
                    newMeal.Type = FoodTypeDay.Dinner;
                    break;
                default:
                    Console.WriteLine("Your response was not recognized.");
                    break;
            }
            Console.WriteLine("Enter in the name of the meal: ");
            newMeal.Name = Console.ReadLine();
            Console.WriteLine("Enter in the number of the meal: ");
            newMeal.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter in a description of the meal: ");
            newMeal.Description = Console.ReadLine();
            Console.WriteLine("Enter in the ingredients of the meal: ");
            string ingredients = Console.ReadLine();
            List<string> newMealIng = ingredients.Split(',').ToList<string>();
            newMeal.Ingredients = newMealIng;

            Console.WriteLine("Enter the price of the meal: ");
            decimal mealPrice = decimal.Parse(Console.ReadLine());
            newMeal.Price = mealPrice;
            _mealRepo.AddMealsToMenu(newMeal);
            Console.WriteLine("\n Press any key to continue.");
            Console.ReadKey();
        }
        private void DeleteMenuItem()
        {
            Console.WriteLine("Which meal would you like to remove?");
            List<Options> mealList = _mealRepo.GetItemsFromMenu();
            int count = 0;
            foreach (Options meal in mealList)
            {
                count++;
                Console.WriteLine($"{count}. {meal.Name}");
            }

            int targetMealId = Convert.ToInt32(Console.ReadLine());
            int targetIndex = targetMealId - 1;
            if (targetIndex >= 0 && targetIndex < mealList.Count)
            {
                Options desiredMeal = mealList[targetIndex];
                if (_mealRepo.DeleteExistingMenuItem(desiredMeal))
                {
                    Console.WriteLine($"{desiredMeal.Name} was successfully removed.");
                }
                else
                {
                    Console.WriteLine(" Item no longer available.");
                }
            }
            else
            {
                Console.WriteLine("Invalid response.");
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllMeals()
        {
            Console.Clear();
            List<Options> listOfMeals = _mealRepo.GetItemsFromMenu();
            foreach (Options meal in listOfMeals)
            {
                DisplayMeal(meal);
                Console.WriteLine("__________________________________________________________________________________________________________");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void DisplayMeal(Options meal)
        {
            Console.WriteLine($" Item Type: {meal.Type} \n" +
                $" Name: {meal.Name} \n" +
                $" Number: {meal.Number} \n" +
                $" Description: {meal.Description} \n" +
                $" Ingredients: { meal.DisplayIngdnts(meal.Ingredients)} \n" +
                $" Price: ${meal.Price} \n" +
                $" On Special: {meal.DealBuy}");
        }
        private void SeedMenu()
        {
            List<string> mealOneIng = new List<string>();
            mealOneIng.Add("Everything Bagel");
            mealOneIng.Add("Bacon");
            mealOneIng.Add("Turkey");
            mealOneIng.Add("Lettuce");
            mealOneIng.Add("Holandase");
            Options mornChamp = new Options(FoodTypeDay.Breakfast, "Everything Bagel", 1, "Everything Bagel with Bacon, Turkery, Lettuce, and Tomatoes", mealOneIng, 11.00M);
            _mealRepo.AddMealsToMenu(mornChamp);

            List<string> mealTwoIng = new List<string>();
            mealTwoIng.Add("Pizza Crust");
            mealTwoIng.Add("Pizza Sauce");
            mealTwoIng.Add("Cheesey Cheese");
            Options sliceOfPizza = new Options(FoodTypeDay.Lunch, "Famous Pizza", 2, "Best Lunch-Time Pizza on this side of the Ohio river", mealTwoIng, 11.50M);
            _mealRepo.AddMealsToMenu(sliceOfPizza);

            List<string> mealThreeIng = new List<string>();
            mealThreeIng.Add("Chicken");
            mealThreeIng.Add("Seasoning");
            mealThreeIng.Add("Green Beans");
            mealThreeIng.Add("Corn on th cob");
            Options bakedChknVeggies = new Options(FoodTypeDay.Dinner, "Baked Chicken and Veggies", 3, " All organic, duh!", mealThreeIng, 21.19M);
            _mealRepo.AddMealsToMenu(bakedChknVeggies);
        }
    }
}
