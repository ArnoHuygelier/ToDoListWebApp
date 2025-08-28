using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApp.Ui.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The password must be at least {1} and at max {2} characters long", MinimumLength = 6)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public required string ConfirmPassword { get; set; }
    }
}
