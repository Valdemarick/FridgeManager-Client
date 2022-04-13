using Domain.Entities.Token;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<TokenResponse> LoginAsync(string userName, string password) =>
            await _userManagementRepository.LoginAsync(userName, password);

        public async Task SignUpAsync(string name, string surname, string userName,
            string password, string email) =>
            await _userManagementRepository.SignUpAsync(name, surname, userName, password, email);

    }
}