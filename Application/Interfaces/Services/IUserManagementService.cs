using IdentityModel.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserManagementService
    {
        Task SignUp(string name, string surname, string userName,
            string password, string email, ICollection<string> roles);
        Task<string> LoginAsync(string userName, string password);
    }
}