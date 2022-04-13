using Domain.Entities.FridgeProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFridgeProductRepository
    {
        Task AddProductsIntoFridgeAsync(List<FridgeProductForCreation> fridgeProductsForCreation);
        Task<List<FridgeProduct>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId);
        Task AddProductsWhereEmptyAsync();
        Task DeleteProductFromFridgeByIdAsync(Guid id);
        Task UpdateFridgeProductAsync(FridgeProductForUpdate fridgeProductForUpdate);
    }
}