using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductAsync(ProductForCreation productForCreation);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(ProductForUpdate productForUpdate);
    }
}