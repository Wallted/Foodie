using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return Ok(_productsService.GetAllProducts(userId));
        }

        [HttpPost]
        public int Add([FromBody] Product product)
        {
            var userId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return _productsService.AddProduct(product, userId);
        }

        [HttpDelete("{controller}/{action}/{productId}")]
        public void Delete([FromRoute] int productId)
        {
            _productsService.DeleteProduct(productId);
        }
    }
}
