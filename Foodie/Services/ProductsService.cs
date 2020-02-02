using Foodie.Data;
using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public class ProductsService : IProductsService
    {
        private ApplicationDbContext _dbContext;
        public ProductsService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _dbContext.Products.FirstOrDefault(x => x.Id == productId);
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}