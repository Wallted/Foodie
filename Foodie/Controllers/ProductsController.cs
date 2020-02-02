using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Models;
using Foodie.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foodie.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult<Product> GetAll()
        {
            return Ok(_productsService.GetAllProducts());
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            _productsService.AddProduct(product);
        }

        [HttpDelete("{controller}/{action}/{productId}")]
        public void Delete([FromRoute] int productId)
        {
            _productsService.DeleteProduct(productId);
        }
    }
}
