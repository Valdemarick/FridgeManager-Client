using Domain.Entities.Fridges;
using Domain.Interfaces.Repositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class FridgeRepository : BaseRepository, IFridgeRepository
    {
        public FridgeRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<Fridge>> GetAllFridgesAsync() =>
            await flurlClient
            .Request("/fridges")
            .GetJsonAsync<List<Fridge>>();

        public async Task CreateFridgeAsync(FridgeForCreation fridgeForCreation) =>
            await flurlClient
            .Request("/fridges")
            .PostJsonAsync(fridgeForCreation);

        public async Task DeleteFridgeAsync(Guid id) =>
            await flurlClient
            .Request($"/fridges/{id}")
            .DeleteAsync();
    }
}