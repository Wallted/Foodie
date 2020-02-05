using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public bool IsMan { get; set; }
        public double CalorieIntake { get; set; }
        public double TrainingFactor { get; set; }
        public string UserRef { get; set; }
        public ApplicationUser User { get; set; }
    }
}