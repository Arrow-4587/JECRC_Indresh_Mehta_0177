using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // DASHBOARD
        // =========================

        public IActionResult Dashboard()
        {
            return View();
        }

        // =========================
        // FOOD LIST
        // =========================

        public async Task<IActionResult> Foods()
        {
            var foods = await _context.FoodItems
                .Include(f => f.Category)
                .ToListAsync();

            return View(foods);
        }

        // =========================
        // CREATE FOOD
        // =========================

        public IActionResult CreateFood()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories,
                "CategoryId",
                "CategoryName"
            );

            return View();
        }

[HttpPost]
public async Task<IActionResult> CreateFood(FoodItem food)
{
    if (!ModelState.IsValid)
    {
        ViewBag.Categories = new SelectList(
            _context.Categories,
            "CategoryId",
            "CategoryName"
        );

        return View(food);
    }

    _context.FoodItems.Add(food);

    await _context.SaveChangesAsync();

    return RedirectToAction("Foods");
}

        // =========================
        // EDIT FOOD
        // =========================

        public async Task<IActionResult> EditFood(int id)
        {
            var food = await _context.FoodItems
                .FindAsync(id);

            ViewBag.Categories = new SelectList(
                _context.Categories,
                "CategoryId",
                "CategoryName"
            );

            return View(food);
        }

        [HttpPost]
        public async Task<IActionResult> EditFood(
            FoodItem food)
        {
            if (ModelState.IsValid)
            {
                _context.FoodItems.Update(food);

                await _context.SaveChangesAsync();

                return RedirectToAction("Foods");
            }

            return View(food);
        }

        // =========================
        // DELETE FOOD
        // =========================

        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.FoodItems
                .FindAsync(id);

            if (food != null)
            {
                _context.FoodItems.Remove(food);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Foods");
        }

        // =========================
        // CATEGORY LIST
        // =========================

        public async Task<IActionResult> Categories()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // =========================
        // CREATE CATEGORY
        // =========================

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);

                await _context.SaveChangesAsync();

                return RedirectToAction("Categories");
            }

            return View(category);
        }
    }
}