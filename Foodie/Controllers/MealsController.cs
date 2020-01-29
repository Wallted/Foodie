using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public int Add([FromBody] Meal meal)
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return _mealsService.AddMeal(meal, userId);
        }

        [HttpGet("{controller}/{action}/{date}")]
        public IEnumerable<Meal> Get([FromRoute] DateTime date)
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return _mealsService.GetAllMealsFromSpecificDay(date, userId);
        }

        [HttpDelete("{controller}/{action}/{id}")]
        public void Delete([FromRoute] int id)
        {
            _mealsService.DeleteMeal(id);
        }

        [HttpGet]
        public IEnumerable<Meal> GetAll()
        {
            return _mealsService.GetAllMeals();
        }
    }
}
