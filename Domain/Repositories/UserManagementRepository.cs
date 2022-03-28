using Domain.Common;
using Domain.Entities.Token;
using Domain.Entities.Users;
using Domain.Interfaces.Repositories;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public async Task<TokenResponse> LoginAsync(string userName, string password)
        {
            var userLogin = new UserForAuthentication()
            {
                UserName = userName,
                Password = password
            };

            return await Constants.ApiUrl
                .AppendPathSegment("/authentication/login")
                .PostJsonAsync(userLogin)
                .ReceiveJson<TokenResponse>();
        }

        public async Task SignUp(string name, string surname, string userName, string password, string email)
        {
            var defaultRole = new List<string> { "User" };
            var userSignUp = new UserForRegistration()
            {
                Name = name,
                Surname = surname,
                UserName = userName,
                Email = email,
                Password = password,
                Roles = defaultRole
            };

            await Constants.ApiUrl
                .AppendPathSegments("/authentication")
                .PostJsonAsync(userSignUp);
        }
    }
}