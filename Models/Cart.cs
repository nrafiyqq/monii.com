using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monii.com.Models
{
    [Table("Cart")] // 👈 Tell EF to use your existing MySQL table "cart"
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; } = 1;

        // Relationships
        public Product? Product { get; set; }
        public User? User { get; set; }
    }
}
