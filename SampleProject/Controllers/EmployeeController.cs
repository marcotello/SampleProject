using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class EmployeeController : Controller
    {
        public string Index()
        {
            return "Employee Section";
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(EmployeeViewModel employeeViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("SaveResult");
        }

        public string SaveResult()
        {
            return "Employee Saved!";
        }
    }
}
