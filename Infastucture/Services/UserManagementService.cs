using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models.Token;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Services
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

        public async Task SignUp(string name, string surname, string userName,
            string password, string email) =>
            await _userManagementRepository.SignUp(name, surname, userName, password, email);

    }
}