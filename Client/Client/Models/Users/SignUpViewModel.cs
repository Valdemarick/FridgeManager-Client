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
        //[RegularExpression(@"\S+\d", ErrorMessage = "The password must contain at least one number")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [RegularExpression(@"(^[A-Z][a-z])*(^[А-Я][а-я])*$", ErrorMessage = "You entered the wrong name. Your name must contain " +
            "only letters")]
        public string? Name { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]|[А-Я][а-яА-Я]*$", ErrorMessage = "You entered the wrong surname. Your name must contain " +
            "only letters")]
        public string? Surname { get; set; }
    }
}