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
            await FlurlClient
            .Request("/fridges")
            .GetJsonAsync<List<Fridge>>();

        public async Task<Fridge> CreateFridgeAsync(FridgeForCreation fridgeForCreation) =>
            await FlurlClient
            .Request("/fridges")
            .PostJsonAsync(fridgeForCreation)
            .ReceiveJson<Fridge>();

        public async Task DeleteFridgeAsync(Guid id) =>
            await FlurlClient
            .Request($"/fridges/{id}")
            .DeleteAsync();

        public async Task UpdateFridgeAsync(FridgeForUpdate fridgeForUpdate) =>
            await FlurlClient
            .Request($"/fridges/{fridgeForUpdate.Id}")
            .PutJsonAsync(fridgeForUpdate);
    }
}