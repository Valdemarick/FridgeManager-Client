using Domain.Entities.Products;
using Domain.Interfaces.Repositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<Product>> GetAllProductsAsync() =>
            await FlurlClient
            .Request("/products")
            .GetJsonAsync<List<Product>>();

        public async Task CreateProductAsync(ProductForCreation productForCreation) =>
            await FlurlClient
            .Request("/products")
            .PostJsonAsync(productForCreation);

        public async Task DeleteProductAsync(Guid id) =>
            await FlurlClient
            .Request($"/products/{id}")
            .DeleteAsync();

        public async Task UpdateProductAsync(ProductForUpdate productForUpdate) =>
            await FlurlClient
            .Request($"products/{productForUpdate.Id}")
            .PutJsonAsync(productForUpdate);
    }
}