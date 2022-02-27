using Application.Interfaces.Repositories;
using Application.Models.Product;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(flurlClientFactory, httpContextAccessor) { }

        public async Task<List<ProductDto>> GetAllProductsAsync() =>
            await flurlClient
            .Request("/products")
            .GetJsonAsync<List<ProductDto>>();
    }
}