using Domain.Entities.FridgeProduct;
using Domain.Interfaces.Repositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class FridgeProductRepository : BaseRepository, IFridgeProductRepository
    {
        public FridgeProductRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task AddProductsIntoFridge(List<FridgeProductForCreation> fridgeProductsForCreation) =>
            await FlurlClient
            .Request("/fridges-products")
            .PostJsonAsync(fridgeProductsForCreation);

        public async Task<List<FridgeProduct>> GetFridgeProductsByFridgeId(Guid fridgeId) =>
            await FlurlClient
            .Request($"/fridges-products/fridge/{fridgeId}/products")
            .GetJsonAsync<List<FridgeProduct>>();

        public async Task AddProductsWhereEmpty() =>
            await FlurlClient
            .Request($"/fridges-products/where-products-are-empty")
            .PostAsync();
    }
}