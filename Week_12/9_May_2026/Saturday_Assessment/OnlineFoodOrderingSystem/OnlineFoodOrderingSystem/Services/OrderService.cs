using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task PlaceOrder(string userId)
        {
            var cartItems = await _context.Carts
                .Include(c => c.FoodItem)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            decimal total = cartItems.Sum(c =>
                c.Quantity * c.FoodItem.Price);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = total
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    FoodId = item.FoodId,
                    Quantity = item.Quantity,
                    Price = item.FoodItem.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.Carts.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }
    }
}