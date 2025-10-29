using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monii.com.Models;
using Monii.com.Data;

namespace Monii.com.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; } = new User();

        public string? Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Check required fields
            if (string.IsNullOrEmpty(NewUser.Email) ||
                string.IsNullOrEmpty(NewUser.PasswordHash) ||
                string.IsNullOrEmpty(NewUser.Name))
            {
                Message = "Please fill in all fields.";
                return Page();
            }

            // Check if email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == NewUser.Email);
            if (existingUser != null)
            {
                Message = "Email is already registered.";
                return Page();
            }

            // Save to database (plain password for now)
            _context.Users.Add(NewUser);
            _context.SaveChanges();

            Message = "Registration successful! You can now log in.";
            return RedirectToPage("/Login"); // redirect user to login page after success
        }
    }
}
