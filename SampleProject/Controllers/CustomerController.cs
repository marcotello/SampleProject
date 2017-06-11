using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Save()
        {
            ViewBag.Cities = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Puerto Vallarta", Value="Puerto Vallarta"},
                new SelectListItem(){ Text="Queretaro", Value="Queretaro"},
                new SelectListItem(){ Text="Monterrey", Value="Monterrey"}
            };

            ViewBag.Companies = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Ocio", Value="Ocio"},
                new SelectListItem(){ Text="Teilus", Value="Teilus"},
                new SelectListItem(){ Text="Vidanta", Value="Vidanta"}
            };
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                ContactName = "Marco Tello",
                CompanyName = "Ocio",
                City = "Puerto Vallarta",
                Country = "Mexico"
            };
            return View(customerViewModel);
        }

        [HttpPost]
        public string Save(CustomerViewModel customerViewModel)
        {
            return customerViewModel.ContactName + " is saved.";
        }
    }
}
