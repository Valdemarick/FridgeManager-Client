using Application.Interfaces.Repositories;
using Application.Models;
using Flurl;
using Flurl.Http;
using IdentityModel.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public async Task<dynamic> LoginAsync(string userName, string password)
        {
            var userLogin = new UserForAuthentication()
            {
                UserName = userName,
                Password = password
            };

            return await "https://localhost:5001/api"
                .AppendPathSegment("authentication/login")
                .PostJsonAsync(userLogin).ReceiveJson();
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

            await "https://localhost:5001/api"
                .AppendPathSegments("authentication")
                .PostJsonAsync(userSignUp);
        }
    }
}