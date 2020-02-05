using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Services
{
    public class DayDataService : IDayDataService
    {
        private readonly ApplicationDbContext _dbContext;
        public DayDataService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public UserInfo GetUserInfo(string userId)
        {
            var user = _dbContext.Users.Include(u => u.UserInfo).FirstOrDefault(x => x.Id == userId);
            if (user.UserInfo == null)
            {
                var newUserInfo = new UserInfo()
                {
                    Weight = 70,
                    Height = 170,
                    Age = 21,
                    IsMan = true,
                    CalorieIntake = 0,
                    TrainingFactor = 1.2,
                    User = user
                };
                _dbContext.UserInfos.Add(newUserInfo);
                _dbContext.SaveChanges();
                return newUserInfo;
            }
            else return user.UserInfo;
        }
        public void UpdateUserInfo(UserInfo userInfo)
        {
            var userInfoToUpdate = _dbContext.UserInfos.First(uf => uf.Id == userInfo.Id);
            _dbContext.Entry(userInfoToUpdate).CurrentValues.SetValues(userInfo);
            _dbContext.SaveChanges();

        }
    }
}
