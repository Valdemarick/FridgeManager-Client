using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductAsync(string name, int quantity);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(Guid id, string name, int quantity);
    }
}