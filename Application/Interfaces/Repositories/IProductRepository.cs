using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.Product;

namespace Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllProductsAsync();
    }
}