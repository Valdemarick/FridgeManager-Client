using Domain.Entities.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductAsync(string name, int quantity);
    }
}