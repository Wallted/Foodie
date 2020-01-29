using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.DTOs;
using Foodie.Models;
using Foodie.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    public class IngriedientsController : Controller
    {
        private readonly IIngriedientsService _ingriedientsService;
        public IngriedientsController(IIngriedientsService ingriedientsService)
        {
            _ingriedientsService = ingriedientsService;
        }

        [HttpPost]
        public int Add([FromBody] IngriedientDTO ingriedient)
        {
            return _ingriedientsService.AddIngriedient(ingriedient);
        }
    }
}
