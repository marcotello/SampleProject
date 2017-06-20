using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Entities;

namespace SampleProject.Services
{
    public class EfProductRepository : IProductRepository
    {
        private NorthwindContext _context;

        public EfProductRepository(NorthwindContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}
