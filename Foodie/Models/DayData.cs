using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Models
{
    public class DayData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public bool TrainingDay { get; set; }
        public double TrainingFactor { get; set; }
        public bool IsMan { get; set; }
        public ApplicationUser User { get; set; }
    }
}