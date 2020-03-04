using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Foodie.Models;
using Foodie.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodie.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        private readonly IDayDataService _dayDataService;
        public UserInfoController(IDayDataService dayDataService)
        {
            _dayDataService = dayDataService;
        }

        [HttpGet]
        public UserInfo Get()
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return _dayDataService.GetUserInfo(userId);
        }

        [HttpPut]
        public void Put([FromBody] UserInfo userInfo)
        {
            _dayDataService.UpdateUserInfo(userInfo);
        }
    }
}
