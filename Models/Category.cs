using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [Column(TypeName = "varchar(20")]
        public required string CategoryName { get; set; }
    }
}