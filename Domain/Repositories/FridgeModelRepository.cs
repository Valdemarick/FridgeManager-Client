using Domain.Entities.FridgeModel;
using Domain.Interfaces.Repositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class FridgeModelRepository : BaseRepository, IFridgeModelRepository
    {
        public FridgeModelRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<FridgeModel>> GetAllFridgeModelsAsync() =>
            await FlurlClient
            .Request("/fridge-models")
            .GetJsonAsync<List<FridgeModel>>();
    }
}