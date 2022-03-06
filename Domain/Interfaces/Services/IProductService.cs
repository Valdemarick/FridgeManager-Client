using Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductAsync(ProductForCreation productForCreation);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(ProductForUpdate productForUpdate);
    }
}