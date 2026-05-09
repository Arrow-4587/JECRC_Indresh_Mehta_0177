using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.Carts
                .Include(c => c.FoodItem)
                .ToListAsync();

            return View(cartItems);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var item = new Cart
            {
                FoodId = id,
                Quantity = 1,
                UserId = "DemoUser"
            };

            _context.Carts.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.Carts.FindAsync(id);

            if (item != null)
            {
                _context.Carts.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}