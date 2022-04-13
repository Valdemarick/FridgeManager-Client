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

        public async Task AddProductsIntoFridgeAsync(List<FridgeProductForCreation> fridgeProductsForCreation) =>
            await FlurlClient
            .Request("/fridges-products")
            .PostJsonAsync(fridgeProductsForCreation);

        public async Task<List<FridgeProduct>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId) =>
            await FlurlClient
            .Request($"/fridges-products/fridge/{fridgeId}/products")
            .GetJsonAsync<List<FridgeProduct>>();

        public async Task AddProductsWhereEmptyAsync() =>
            await FlurlClient
            .Request($"/fridges-products/where-products-are-empty")
            .PostAsync();

        public async Task DeleteProductFromFridgeByIdAsync(Guid id) =>
            await FlurlClient
            .Request($"/fridges-products/{id}")
            .DeleteAsync();

        public async Task UpdateFridgeProductAsync(FridgeProductForUpdate fridgeProductForUpdate) =>
            await FlurlClient
            .Request($"/fridges-products")
            .PutJsonAsync(fridgeProductForUpdate);
    }
}