using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monii.com.Data;
using Monii.com.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monii.com.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProductsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; } = new();
        public string CurrentCategory { get; set; } = string.Empty;

        public void OnGet(string? category)
        {
            CurrentCategory = category ?? "All";

            Products = _context.Products
                .Where(p => category == null || p.Category.ToLower() == category.ToLower())
                .ToList();
        }

        // ✅ Handles Add to Cart button click
        public IActionResult OnPostAddToCart(int productId)
        {
            // Check if user is logged in
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                // Not logged in → redirect to Login page
                return RedirectToPage("/Login");
            }

            // Check if product exists
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                TempData["Error"] = "Product not found.";
                return RedirectToPage("/Products", new { category = CurrentCategory });
            }

            // Check if item already exists in cart
            var existing = _context.Carts.FirstOrDefault(
                c => c.UserID == userId && c.ProductID == productId);

            if (existing == null)
            {
                _context.Carts.Add(new Cart
                {
                    UserID = userId.Value,
                    ProductID = productId,
                    Quantity = 1
                });
            }
            else
            {
                existing.Quantity += 1;
            }

            _context.SaveChanges();

            TempData["Success"] = "Item added to cart!";
            return RedirectToPage("/Cart");
        }
    }
}
