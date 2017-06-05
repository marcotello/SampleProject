using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }

        public ViewResult Index2()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                CustomerId = "D001",
                CompanyName = "Vidanta",
                City = "Puerto Vallarta",
                Country = "Mexico",
                ContactName = "Marco Tello"
            };


            return View(customerViewModel);
        }

        public ViewResult Index3()
        {
            return View();
        }

        public ViewResult Index4()
        {
            return View();
        }
    }
}
