using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _01_Komo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomoTest
{
    [TestClass]
    public class IngredientsTest
    {
        private FoodRepository _foodRepo;
        private Options _meal;

        [TestInitialize]
        public void Arrange()
        {
            List<string> _ingredients = new List<string>();
            _ingredients.Add("Turkey");
            _ingredients.Add("Bread");
            _ingredients.Add("Swiss Chesse");
            _foodRepo = new FoodRepository();
            _meal = new Options(FoodTypeDay.Lunch, "Turkey Sandwhich", 4, "Turkey, Bread, Swiss Cheese", _ingredients, 11M);
            _foodRepo.AddMealsToMenu(_meal);

        }

        [TestMethod]
        public void AddMealToMenu_ShouldBeTrue()
        {
            bool addResults = _foodRepo.AddMealsToMenu(_meal);
            Assert.IsTrue(addResults);
        }

        [TestMethod]
        public void GetMealName_ShouldBeTrue()
        {
            Options _mealSearch = _foodRepo.GetMealByName("Turkey Sandwich");
            Assert.AreEqual(_meal, _mealSearch);

        }

        [TestMethod]
        public void GetListOfMeals_ShouldBeTrue()
        {
            List<Options> meals = _foodRepo.GetItemsFromMenu();
            bool foodRepoMeal = meals.Contains(_meal);
            Assert.IsTrue(foodRepoMeal);
        }
        [TestMethod]
        public void DeleteMealFromSelections_ShouldBeTrue()
        {
            Options meal = _foodRepo.GetMealByName("Turkey Sandwich");
            bool wasDeleted = _foodRepo.DeleteExistingMenuItem(meal);
            Assert.IsTrue(wasDeleted);
        }
    }
}
