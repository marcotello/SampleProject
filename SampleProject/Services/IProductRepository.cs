using SampleProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Services
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Add(Product product);
    }
}
