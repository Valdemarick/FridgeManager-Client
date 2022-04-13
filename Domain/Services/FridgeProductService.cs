using Domain.Entities.FridgeProduct;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FridgeProductService : IFridgeProductService
    {
        private readonly IFridgeProductRepository _fridgeProductRepository;

        public FridgeProductService(IFridgeProductRepository fridgeProductRepository)
        {
            _fridgeProductRepository = fridgeProductRepository;
        }

        public async Task AddProductsIntoFridgeAsync(List<FridgeProductForCreation> fridgeProductsForCreation) =>
            await _fridgeProductRepository.AddProductsIntoFridgeAsync(fridgeProductsForCreation);

        public async Task<List<FridgeProduct>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId) =>
            await _fridgeProductRepository.GetFridgeProductsByFridgeIdAsync(fridgeId);

        public async Task AddProductsWhereEmptyAsync() =>
            await _fridgeProductRepository.AddProductsWhereEmptyAsync();

        public async Task DeleteProductFromFridgeByIdAsync(Guid id) =>
            await _fridgeProductRepository.DeleteProductFromFridgeByIdAsync(id);

        public async Task UpdateFridgeProductAsync(FridgeProductForUpdate fridgeProductForUpdate) =>
            await _fridgeProductRepository.UpdateFridgeProductAsync(fridgeProductForUpdate);
    }
}