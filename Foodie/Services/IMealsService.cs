using Foodie.DTOs;
using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IMealsService
    {
        public int AddMeal(Meal meal, string userId);
        public Meal GetMeal(int mealId);
        public IEnumerable<Meal> GetAllMeals();
        public IEnumerable<Meal> GetAllMealsFromSpecificDay(DateTime date, string userId);
        public void UpdateMeal(Meal meal);
        public void DeleteMeal(int mealId);
        public MacroDTO CalculateMacroFromDay(DateTime date, string userId);
    }
}
