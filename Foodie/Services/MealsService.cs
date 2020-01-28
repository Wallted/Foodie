using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;

namespace Foodie.Services
{
    public class MealsService : IMealsService
    {
        private readonly ApplicationDbContext _dbContext;
        public MealsService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public void AddMeal(Meal meal)
        {
            _dbContext.Meals.Add(meal);
            _dbContext.SaveChanges();
        }

        public void DeleteMeal(int mealId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _dbContext.Meals.ToList();
        }

        public IEnumerable<Meal> GetAllMealsFromSpecificDay(DateTime date)
        {
            var list = _dbContext.Meals.Where(x => x.Date.Day == date.Day).ToList();
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
