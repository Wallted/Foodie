using Foodie.DTOs;
using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IIngriedientsService
    {
        public int AddIngriedient(IngriedientDTO ingriedient);
        public void DeleteIngriedientById(int id);
    }
}
