using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodie.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly ILogger<ProductsController> log;
        public ProductsController(ApplicationDbContext applicationDbContext, ILogger<ProductsController> log)
        {
            _dbContext = applicationDbContext;
            this.log = log;
        }
        [HttpGet]
        public ActionResult<Product> Get()
        {
            try
            {
                log.LogDebug("Trying to get a product");
                return this.Ok(_dbContext.Products.ToList());
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occured while trying to get a product");
                return this.BadRequest(ex);
            }

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
