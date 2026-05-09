using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Services
{
    public class FoodService
    {
        private readonly ApplicationDbContext _context;

        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodItem>> GetAllFoods()
        {
            return await _context.FoodItems
                .Include(f => f.Category)
                .ToListAsync();
        }

        public async Task<FoodItem> GetFoodById(int id)
        {
            return await _context.FoodItems
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.FoodId == id);
        }

        public async Task AddFood(FoodItem food)
        {
            _context.FoodItems.Add(food);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateFood(FoodItem food)
        {
            _context.FoodItems.Update(food);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFood(int id)
        {
            var food = await _context.FoodItems.FindAsync(id);

            if (food != null)
            {
                _context.FoodItems.Remove(food);

                await _context.SaveChangesAsync();
            }
        }
    }
}