using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IMealsService
    {
        public void AddMeal(Meal meal);
        public Meal GetMeal(int mealId);
        public IEnumerable<Meal> GetAllMeals();
        public IEnumerable<Meal> GetAllMealsFromSpecificDay(DateTime date);
        public void UpdateMeal(Meal meal);
        public void DeleteMeal(int mealId);
    }
}
