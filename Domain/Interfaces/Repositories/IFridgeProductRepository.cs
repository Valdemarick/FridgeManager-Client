using Domain.Entities.FridgeProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFridgeProductRepository
    {
        Task AddProductsIntoFridge(List<FridgeProductForCreation> fridgeProductsForCreation);
        Task<List<FridgeProduct>> GetFridgeProductsByFridgeId(Guid fridgeId);
        Task AddProductsWhereEmpty();
    }
}