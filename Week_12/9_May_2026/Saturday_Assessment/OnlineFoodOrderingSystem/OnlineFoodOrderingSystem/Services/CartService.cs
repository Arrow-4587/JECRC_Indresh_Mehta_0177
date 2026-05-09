using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int foodId, string userId)
        {
            var existingItem = await _context.Carts
                .FirstOrDefaultAsync(c =>
                    c.FoodId == foodId &&
                    c.UserId == userId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var cart = new Cart
                {
                    FoodId = foodId,
                    Quantity = 1,
                    UserId = userId
                };

                _context.Carts.Add(cart);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetCartItems(string userId)
        {
            return await _context.Carts
                .Include(c => c.FoodItem)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task RemoveItem(int cartId)
        {
            var item = await _context.Carts.FindAsync(cartId);

            if (item != null)
            {
                _context.Carts.Remove(item);

                await _context.SaveChangesAsync();
            }
        }
    }
}