using Domain.Entities.Fridges;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IFridgeService
    {
        Task<List<Fridge>> GetAllFridgesAsync();
        Task CreateFridgeAsync(FridgeForCreation fridgeForCreation);
        Task DeleteFridgeAsync(Guid id);
    }
}