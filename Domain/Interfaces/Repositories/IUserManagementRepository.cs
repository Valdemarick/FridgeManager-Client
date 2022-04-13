using Domain.Entities.Token;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserManagementRepository
    {
        Task SignUpAsync(string name, string surname, string userName,
                    string password, string email);
        Task<TokenResponse> LoginAsync(string userName, string password);
    }
}