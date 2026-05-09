using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> History()
        {
            var orders = await _context.Orders.ToListAsync();

            return View(orders);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = 1000,
                UserId = "DemoUser"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("History");
        }
    }
}