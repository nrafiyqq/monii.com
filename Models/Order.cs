using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monii.com.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = "Pending"; // e.g., Pending, Completed, Cancelled

        // Navigation
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
