using Microsoft.EntityFrameworkCore;
using Monii.com.Models;

namespace Monii.com.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }       // ✅ Added
        public DbSet<OrderItem> OrderItems { get; set; } // ✅ Added

    }
}
