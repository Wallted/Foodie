using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IDayDataService
    {
        public int AddData(DayData dayData, string userId);
        public void DeleteData(DayData dayData);
        public DayData GetDayData(DateTime day);
    }
}
