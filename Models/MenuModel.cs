using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order.Models
{
    public class MenuModel
    {
        [Key]
        public int DishID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public CategoryModel? Category { get; set; }
        [Required]
        [Column(TypeName = "varchar(30")]
        public required string DishName { get; set; }
        [Required]
        [Column(TypeName = "decimal(4, 0)")]
        public decimal Price { get; set; }
    }
}