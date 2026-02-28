using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(){Id=1,Name="Laptop",Price=1000},
            new Product(){Id=2,Name="Phone",Price=500},
            new Product(){Id=3,Name="Tablet",Price=300}
        };
        public IActionResult Index()
        {
            return View(products);
        }
    }
}
