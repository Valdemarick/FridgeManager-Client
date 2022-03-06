using Application.Interfaces.Services;
using Domain.Entities.Products;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync() =>
            await _productRepository.GetAllProductsAsync();

        public async Task CreateProductAsync(ProductForCreation productForCreation) =>
            await _productRepository.CreateProductAsync(productForCreation);

        public async Task DeleteProductAsync(Guid id) =>
            await _productRepository.DeleteProductAsync(id);

        public async Task UpdateProductAsync(ProductForUpdate productForUpdate) =>
            await _productRepository.UpdateProductAsync(productForUpdate);
    }
}