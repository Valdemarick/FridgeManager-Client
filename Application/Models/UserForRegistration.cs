using System.Collections.Generic;

namespace Application.Models
{
    public class UserForRegistration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}