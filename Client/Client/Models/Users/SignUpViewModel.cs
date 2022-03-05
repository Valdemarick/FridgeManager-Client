using System.ComponentModel.DataAnnotations;
#nullable enable

namespace Client.Models.Users
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(8, ErrorMessage = "The minimum size of the password is 8 characters")]
        [RegularExpression(@"(?=.*[0-9])", ErrorMessage = "The password must contain at least one number")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+" +
            @"(\.[a-z0-9_-]+)*.[a-z]{2,6}$", ErrorMessage = "You entered a wrong email address")]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}