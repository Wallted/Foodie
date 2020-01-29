using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.DTOs
{
    public class IngriedientDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public int MealId { get; set; }
    }
}
