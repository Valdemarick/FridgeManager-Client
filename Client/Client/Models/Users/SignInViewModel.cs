using System.ComponentModel.DataAnnotations;

namespace Client.Models.Users
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The minimum size of the password is 8 characters")]
        //[RegularExpression(@"^((?=.*\d)(?=.*[a-z]))", ErrorMessage = "The password must contain at least one number")]
        public string Password { get; set; }
    }
}