using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable enable

namespace Client.Models.User
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; } = null!;
        
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+" +
            @"(\.[a-z0-9_-]+)*.[a-z]{2,6}$", ErrorMessage = "You entered a wrong email address")]
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public ICollection<string> Roles { get; set; } = null!;
    }
}