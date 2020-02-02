using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;

namespace Foodie.Services
{
    public class DayDataService : IDayDataService
    {
        private readonly ApplicationDbContext _dbContext;
        public DayDataService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public int AddData(DayData dayData, string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            dayData.User = user;
            _dbContext.Add(dayData);
            _dbContext.SaveChanges();
            return dayData.Id;
        }

        public void DeleteData(DayData dayData)
        {
            throw new NotImplementedException();
        }

        public DayData GetDayData(DateTime day)
        {
            return _dbContext.DayDatas.FirstOrDefault(x => x.Date.Day == day.Day);
        }
    }
}
