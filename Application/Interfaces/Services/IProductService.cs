using Application.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
    }
}