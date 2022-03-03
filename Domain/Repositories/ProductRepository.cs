using Domain.Entities.Products;
using Domain.Interfaces;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<Product>> GetAllProductsAsync() =>
            await flurlClient
            .Request("/products")
            .GetJsonAsync<List<Product>>();

        public async Task CreateProductAsync(string name, int quantity)
        {
            var productForCreation = new ProductForCreation()
            {
                Name = name,
                Quantity = quantity
            };

            await flurlClient
                .Request("/products")
                .PostJsonAsync(productForCreation);
        }

        public async Task DeleteProductAsync(Guid id) =>
            await flurlClient
            .Request($"/products/{id}")
            .DeleteAsync();

        public async Task UpdateProductAsync(Guid id, string name, int quantity)
        {
            var productForUpdate = new ProductForUpdate()
            {
                Name = name,
                Quantity = quantity
            };

            await flurlClient
                .Request($"products/{id}")
                .PutJsonAsync(productForUpdate);
        }
    }
}