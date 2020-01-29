using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Services
{
    public class MealsService : IMealsService
    {
        private readonly ApplicationDbContext _dbContext;
        public MealsService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public int AddMeal(Meal meal, string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            meal.User = user;
            _dbContext.Meals.Add(meal);
            _dbContext.SaveChanges();
            return meal.Id;
        }

        public void DeleteMeal(int mealId)
        {
            var mealToDelete = _dbContext.Meals.Include(r=>r.Ingriedients).SingleOrDefault(x => x.Id == mealId);
            _dbContext.Remove(mealToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _dbContext.Meals.ToList();
        }

        public IEnumerable<Meal> GetAllMealsFromSpecificDay(DateTime date, string userId)
        {
            var list = _dbContext.Meals.Include(u=>u.User).Include(r => r.Ingriedients).ThenInclude(x=>x.Product).Where(x => x.Date.Day == date.Day && x.User.Id == userId);
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
