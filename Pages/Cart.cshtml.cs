using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Monii.com.Data;
using Monii.com.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monii.com.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Cart> UserCart { get; set; } = new();

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                // Redirect to login if not logged in
                return RedirectToPage("/Login");
            }

            // Load user’s cart with product info
            UserCart = _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserID == userId)
                .ToList();

            return Page();
        }

        public IActionResult OnGetRemove(int cartId)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
                return RedirectToPage("/Login");

            var cartItem = _context.Carts.FirstOrDefault(c => c.CartID == cartId && c.UserID == userId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
