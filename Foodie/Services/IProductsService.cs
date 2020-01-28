using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Services
{
    public interface IProductsService
    {
        public void AddProduct(Product product);
        public Product GetProduct(int productId);
        public IEnumerable<Product> GetAllProducts();
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productId);
    }
}