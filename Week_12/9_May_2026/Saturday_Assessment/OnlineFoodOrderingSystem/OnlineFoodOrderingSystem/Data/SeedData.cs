using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(

                    new Category
                    {
                        CategoryName = "Pizza"
                    },

                    new Category
                    {
                        CategoryName = "Burger"
                    },

                    new Category
                    {
                        CategoryName = "Drinks"
                    }

                );

                context.SaveChanges();
            }

            if (!context.FoodItems.Any())
            {
                context.FoodItems.AddRange(

                    new FoodItem
                    {
                        Name = "Farmhouse Pizza",
                        Description = "Loaded veg pizza",
                        Price = 399,
                        ImageUrl = "/images/pizza.jpg",
                        IsAvailable = true,
                        CategoryId = 1
                    },

                    new FoodItem
                    {
                        Name = "Cheese Burger",
                        Description = "Loaded cheese burger",
                        Price = 199,
                        ImageUrl = "/images/burger.jpg",
                        IsAvailable = true,
                        CategoryId = 2
                    }

                );

                context.SaveChanges();
            }
        }
    }
}