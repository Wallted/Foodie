using Foodie.Data;
using Foodie.Models;
using Microsoft.EntityFrameworkCore;
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

        public int AddProduct(Product product, string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            product.User = user;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.Id;
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _dbContext.Products.FirstOrDefault(x => x.Id == productId);
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts(string userId)
        {
            return _dbContext.Products.Include(m => m.User).Where(p => p.User.Id == userId).ToList();
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