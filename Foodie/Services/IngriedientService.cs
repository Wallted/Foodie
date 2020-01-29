using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.DTOs;
using Foodie.Models;

namespace Foodie.Services
{
    public class IngriedientService : IIngriedientsService
    {
        private readonly ApplicationDbContext _dbContext;
        public IngriedientService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public int AddIngriedient(IngriedientDTO ingriedient)
        {
            var meal = _dbContext.Meals.FirstOrDefault(x => x.Id == ingriedient.MealId);
            var product = _dbContext.Products.First(x => x.Id == ingriedient.Product.Id);
            var ingriedientToAdd = new Ingriedient()
            {
                Meal = meal,
                Product = product,
                Quantity = ingriedient.Quantity
            };

            _dbContext.Ingriedients.Add(ingriedientToAdd);
            _dbContext.SaveChanges();
            return ingriedientToAdd.Id;

        }

        public void DeleteIngriedientById(int id)
        {
            var ingriedientToDelete = _dbContext.Ingriedients.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(ingriedientToDelete);
            _dbContext.SaveChanges();
        }
    }
}
