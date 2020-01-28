using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Models;
using Foodie.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    public class MealsController : Controller
    {
        private readonly IMealsService _mealsService;
        public MealsController(IMealsService mealsService)
        {
            _mealsService = mealsService;
        }
        [HttpPost]
        public void Add([FromBody] Meal meal)
        {
            _mealsService.AddMeal(meal);
        }

        [HttpGet("{controller}/{action}/{date}")]
        public IEnumerable<Meal> Get([FromRoute] DateTime date)
        {
            return _mealsService.GetAllMealsFromSpecificDay(date);
        }

        [HttpGet]
        public IEnumerable<Meal> GetAll()
        {
            return _mealsService.GetAllMeals();
        }
    }
}
