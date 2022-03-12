using Domain.Entities.Fridges;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        Task<List<Fridge>> GetAllFridgesAsync();
        Task<Fridge> CreateFridgeAsync(FridgeForCreation fridgeForCreation);
        Task DeleteFridgeAsync(Guid id);
        Task UpdateFridgeAsync(FridgeForUpdate fridgeForUpdate);
    }
}