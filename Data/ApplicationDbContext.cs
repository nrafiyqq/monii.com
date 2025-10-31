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

    // Set primary keys
    modelBuilder.Entity<User>().HasKey(u => u.UserID);
    modelBuilder.Entity<Product>().HasKey(p => p.ProductID);
    modelBuilder.Entity<Cart>().HasKey(c => c.CartID);
    modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
    modelBuilder.Entity<OrderItem>().HasKey(oi => oi.OrderItemID);

    // Ensure auto-increment IDs
    modelBuilder.Entity<User>().Property(u => u.UserID).ValueGeneratedOnAdd();
    modelBuilder.Entity<Product>().Property(p => p.ProductID).ValueGeneratedOnAdd();
    modelBuilder.Entity<Cart>().Property(c => c.CartID).ValueGeneratedOnAdd();
    modelBuilder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedOnAdd();
    modelBuilder.Entity<OrderItem>().Property(oi => oi.OrderItemID).ValueGeneratedOnAdd();
}

    }
}
