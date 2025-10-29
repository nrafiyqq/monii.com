using System.ComponentModel.DataAnnotations;

namespace Monii.com.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Email { get; set; } = "";

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = "";

        [Required, MaxLength(50)]
        public string Role { get; set; } = "Customer";
    }
}
