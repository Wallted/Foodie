using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodie.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductsController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dbContext.Products.ToList();
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            var pr = new Product();
            pr.Name = product.Name;
            _dbContext.Add(pr);
            _dbContext.SaveChanges();
        }
    }
}
