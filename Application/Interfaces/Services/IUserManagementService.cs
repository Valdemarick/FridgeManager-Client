﻿using Application.Models.Token;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserManagementService
    {
        Task SignUp(string name, string surname, string userName,
            string password, string email, ICollection<string> roles);
        Task<TokenResponse> LoginAsync(string userName, string password);
    }
}