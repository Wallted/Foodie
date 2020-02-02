using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Foodie.Models;
using Foodie.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodie.Controllers
{
    public class DayDataController : Controller
    {
        private readonly IDayDataService _dayDataService;
        public DayDataController(IDayDataService dayDataService)
        {
            _dayDataService = dayDataService;
        }

        [HttpPost]
        public int Add([FromBody] DayData dayData)
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return _dayDataService.AddData(dayData, userId);
        }

        [HttpGet("{controller}/{action}/{datTime}")]
        public DayData Get([FromRoute] DateTime dateTime)
        {
            var d = _dayDataService.GetDayData(dateTime);
            return d;
        }

        [HttpDelete("{controller}/{action}/{id}")]
        public void Delete(int id)
        {
            //_ingriedientsService.DeleteIngriedientById(id);
        }
    }
}
