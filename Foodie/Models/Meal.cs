using System;
using System.Collections.Generic;

namespace Foodie.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Ingriedient> Ingriedients { get; set; }
        public ApplicationUser User { get; set; }
    }
}