using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class ActionResultController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return View("Index");
        }

        public ViewResult Index3()
        {
            return View("Index3", "Marco Tello");
        }

        public PartialViewResult Index4()
        {
            return PartialView();
        }

        public ContentResult Index5()
        {
            return Content("Marco Tello", "text/html", Encoding.UTF8);
        }

        public JsonResult Index6()
        {
            var products = new List<Product>()
            {
                new Product {Name = "Laptop", UnitPrice = 1000},
                new Product {Name = "Mouse", UnitPrice = 10}
            };

            return Json(products);
        }

        public RedirectResult Index7()
        {
            return Redirect("http://microsft.com");
        }

        public RedirectToActionResult Index8()
        {
            //return RedirectToAction("Index");
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("Index", new {controller="Home", id=5});
            return RedirectToAction("Index", new RouteValueDictionary()
            {
                {"controller", "Home"},
                {"id","5"}
            });
        }

        public RedirectToRouteResult Index9()
        {
            return RedirectToRoute("Default", new {controller = "Home", action = "Index" });
        }

        public StatusCodeResult Index10()
        {
            return new UnauthorizedResult();
        }

        public CustomResult Index11()
        {
            return new CustomResult();
        }

        public class Product
        {
            public string Name { get; set; }
            public int UnitPrice { get; set; }
        }

        public class CustomResult : ActionResult
        {
            public override void ExecuteResult(ActionContext context)
            {
                //base.ExecuteResult(context);
                context.HttpContext.Response.WriteAsync("My Custom Result");
            }
        }
    }
}
