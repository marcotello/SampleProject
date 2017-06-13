using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Entities;

namespace SampleProject.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product> 
            {
                new Product { ProductID = 1, ProductName = "Laptop", UnitPrice = 1500 },
                new Product { ProductID = 2, ProductName = "Mouse", UnitPrice = 10 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
