using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monii.com.Data;
using Monii.com.Models;
using System.Linq;

namespace Monii.com.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInput Input { get; set; } = new LoginInput();

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Input.Email) || string.IsNullOrEmpty(Input.Password))
            {
                ErrorMessage = "Please enter both email and password.";
                return Page();
            }

            // ✅ Check plain-text password (for now)
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == Input.Email && u.PasswordHash == Input.Password);

            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // ✅ Save user info to session
            HttpContext.Session.SetInt32("UserID", user.UserID); // ← this line is CRITICAL
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.Name);

            TempData["SuccessMessage"] = $"Welcome back, {user.Name}!";
            return RedirectToPage("/Index");
        }

        public class LoginInput
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
