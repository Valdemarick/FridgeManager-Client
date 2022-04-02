using Domain.Entities.FridgeProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IFridgeProductService
    {
        Task AddProductsIntoFridge(List<FridgeProductForCreation> fridgeProductsForCreation);
        Task<List<FridgeProduct>> GetFridgeProductsByFridgeId(Guid fridgeId);
        Task AddProductsWhereEmpty();
        Task DeleteProductFromFridgeById(Guid id);
        Task UpdateFridgeProductAsync(FridgeProductForUpdate fridgeProductForUpdate);
    }
}