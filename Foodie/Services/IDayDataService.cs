using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IDayDataService
    {
        public UserInfo GetUserInfo(string userId);
        public void UpdateUserInfo(UserInfo userInfo);
    }
}
