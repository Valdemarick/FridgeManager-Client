using Application.Interfaces.Repositories;
using Application.Models.Fridge;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Repositories
{
    public class FridgeRepository : BaseRepository, IFridgeRepository
    {
        public FridgeRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<FridgeDto>> GetAllFridgesAsync() =>
            await flurlClient
            .Request("/fridges")
            .GetJsonAsync<List<FridgeDto>>();
    }
}