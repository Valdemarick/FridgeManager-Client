using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductAsync(ProductForCreation productForCreation);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(ProductForUpdate productForUpdate);
    }
}