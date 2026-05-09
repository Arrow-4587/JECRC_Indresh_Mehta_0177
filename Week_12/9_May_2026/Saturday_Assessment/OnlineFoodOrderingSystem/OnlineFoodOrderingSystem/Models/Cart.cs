using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public string UserId { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(FoodId))]
        public FoodItem FoodItem { get; set; }
    }
}