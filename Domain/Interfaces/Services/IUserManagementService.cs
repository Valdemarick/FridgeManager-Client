using Domain.Entities.Token;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserManagementService
    {
        Task SignUp(string name, string surname, string userName,
            string password, string email);
        Task<TokenResponse> LoginAsync(string userName, string password);
    }
}