using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        [Column("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [MaxLength(200, ErrorMessage = "Password cannot exceed 200 characters.")]
        [Column("hashed_password")]
        public string HashedPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [MinLength(6, ErrorMessage = "Phone number must be at least 6 digits.")]
        [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 digits.")]
        [Column("phone")]
        public string Phone { get; set; }

        [MinLength(2, ErrorMessage = "Full name must be at least 2 characters.")]
        [MaxLength(255, ErrorMessage = "Full name cannot exceed 255 characters.")]
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [MinLength(2, ErrorMessage = "Country must be at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "Country cannot exceed 200 characters.")]
        [Column("country")]
        public string Country { get; set; }
    }
}
