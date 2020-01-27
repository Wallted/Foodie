using Microsoft.AspNetCore.Identity;

namespace Foodie.Models
{
    public class ApplicationUser : IdentityUser
    {
        public double Weight { get; set; }
        public double KcalDemand { get; set; }
    }
}