using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Ch14_WebApp.Models;
using Microsoft.Data.Entity;

namespace Ch14_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindContext db;

        public HomeController(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = (new Random()).Next(1, 1001),
                Products = db.Products.ToArray()
            };
            return View(model); // pass model to view
        }

        public IActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }
            var model = db.Products.SingleOrDefault(p => p.ProductID == id);
            if (model == null)
            {
                return HttpNotFound($"A product with the ID of {id} was not found.");
            }
            return View(model); // pass model to view
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return HttpNotFound("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
            }
            var model = db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.UnitPrice > price).ToArray();
            if (model.Count() == 0)
            {
                return HttpNotFound($"No products cost more than {price:C}.");
            }
            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(model); // pass model to view
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
