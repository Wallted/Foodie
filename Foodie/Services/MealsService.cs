using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.DTOs;
using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Services
{
    public class MealsService : IMealsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDayDataService _dataService;
        public MealsService(ApplicationDbContext applicationDbContext, IDayDataService dayDataService)
        {
            _dbContext = applicationDbContext;
            _dataService = dayDataService;
        }
        public int AddMeal(Meal meal, string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            meal.User = user;
            _dbContext.Meals.Add(meal);
            _dbContext.SaveChanges();
            return meal.Id;
        }

        public MacroDTO CalculateMacroFromDay(DateTime date, string userId)
        {
            var macro = new MacroDTO();
            var meals = GetAllMealsFromSpecificDay(date.ToUniversalTime(), userId);
            var data = _dataService.GetUserInfo(userId);

            if (data.IsMan)
            {
                macro.CaloriesDemand = Math.Round((10 * data.Weight + 6.25 * data.Height - 5 * data.Age + 5) * data.TrainingFactor + data.CalorieIntake);
                macro.ProteinDemand = Math.Round(2 * data.Weight);
                macro.FatDemand = Math.Round(macro.CaloriesDemand * 0.2 / 9);
                macro.CarbohydratesDemand = Math.Round((macro.CaloriesDemand - macro.ProteinDemand * 4 - macro.FatDemand * 9) / 4);

                foreach (var meal in meals)
                {
                    foreach (Ingriedient ingriedient in meal.Ingriedients)
                    {
                        macro.CarbohydratesAte += (ingriedient.Quantity / 100.0 * ingriedient.Product.Carbs);
                        macro.FatAte += (ingriedient.Quantity / 100.0 * ingriedient.Product.Fat);
                        macro.ProteinAte += (ingriedient.Quantity / 100.0 * ingriedient.Product.Protein);
                        macro.CaloriesAte += (ingriedient.Quantity / 100.0 * ingriedient.Product.Calories);
                    }
                }
            }
            macro.CarbohydratesAte = Math.Round(macro.CarbohydratesAte);
            macro.FatAte = Math.Round(macro.FatAte);
            macro.ProteinAte = Math.Round(macro.ProteinAte);
            macro.CaloriesAte = Math.Round(macro.CaloriesAte);
            return macro;
        }

        public void DeleteMeal(int mealId)
        {
            var mealToDelete = _dbContext.Meals.Include(r => r.Ingriedients).SingleOrDefault(x => x.Id == mealId);
            _dbContext.Remove(mealToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _dbContext.Meals.ToList();
        }

        public IEnumerable<Meal> GetAllMealsFromSpecificDay(DateTime date, string userId)
        {
            var list = _dbContext.Meals.Include(u => u.User).Include(r => r.Ingriedients).ThenInclude(x => x.Product).Where(x => x.Date.Day == date.Day && x.User.Id == userId);
            return list;
        }

        public Meal GetMeal(int mealId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeal(Meal meal)
        {
            throw new NotImplementedException();
        }
    }
}
