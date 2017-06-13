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
    }
}
