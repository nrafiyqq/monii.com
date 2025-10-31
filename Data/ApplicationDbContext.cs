using Microsoft.EntityFrameworkCore;
using Monii.com.Models;

namespace Monii.com.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure all primary keys auto-increment
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.ProductID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Cart>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItem>().Property(oi => oi.OrderItemID).ValueGeneratedOnAdd();
        }
    }
}
