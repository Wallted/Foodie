using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Foodie.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<DayData> DayData { get; set; }
    }
}