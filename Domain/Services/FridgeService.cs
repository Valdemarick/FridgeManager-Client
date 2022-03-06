using Domain.Entities.Fridges;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _fridgeRepository;

        public FridgeService(IFridgeRepository fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public async Task<List<Fridge>> GetAllFridgesAsync() =>
            await _fridgeRepository.GetAllFridgesAsync();

        public async Task CreateFridgeAsync(FridgeForCreation fridgeForCreation) =>
            await _fridgeRepository.CreateFridgeAsync(fridgeForCreation);

        public async Task DeleteFridgeAsync(Guid id) =>
            await _fridgeRepository.DeleteFridgeAsync(id);
    }
}