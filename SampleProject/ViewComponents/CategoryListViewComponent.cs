using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(string filter)
        {
            List<string> categories = new List<string>
            {
                "Beverages",
                "Condiments",
                "Daily Suppliers"
            };

            categories = categories.Where(c => c.Contains(filter)).ToList();

            return View(new CategoryListViewModel { Categories = categories });
        }

    }
}
