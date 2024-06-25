using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Dish")]
        public int DishID { get; set; }
        public MenuModel? Menu { get; set; }
        [Required]
        [Column(TypeName = "decimal(2, 0)")]
        public required decimal Qty { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        [Required]
        [Column(TypeName = "decimal(2, 0)")]
        public decimal TableNumber { get; set; }
    }
}