using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monii.com.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        // Navigation properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
