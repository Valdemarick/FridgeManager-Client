using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync() =>
            await _productRepository.GetAllProductsAsync();
    }
}