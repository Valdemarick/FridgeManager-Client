using Application.Interfaces.Repositories;
using Application.Models;
using Application.Models.Token;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Repositories
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
                .AppendPathSegment("authentication/login")
                .PostJsonAsync(userLogin)
                .ReceiveJson<TokenResponse>();
        }

        public async Task SignUp(string name, string surname, string userName, string password, string email, ICollection<string> roles)
        {
            var userSignUp = new UserForRegistration()
            {
                Name = name,
                Surname = surname,
                UserName = userName,
                Email = email,
                Password = password,
                Roles = roles
            };

            await Constants.ApiUrl
                .AppendPathSegments("authentication")
                .PostJsonAsync(userSignUp);
        }
    }
}