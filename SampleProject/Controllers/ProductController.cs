using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Services;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                Products = _productRepository.GetAll()
            };
            return View(productListViewModel);
        }

        public string Add()
        {
            _productRepository.Add(new Entities.Product { ProductID = 3, ProductName = "Monitor", UnitPrice = 50 });
            _productRepository.Add(new Entities.Product { ProductID = 4, ProductName = "Keyboard", UnitPrice = 15 });

            return _productRepository.GetAll().Count.ToString();
        }
    }
}
