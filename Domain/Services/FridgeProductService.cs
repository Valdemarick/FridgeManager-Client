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

        public async Task AddProductsIntoFridge(List<FridgeProductForCreation> fridgeProductsForCreation) =>
            await _fridgeProductRepository.AddProductsIntoFridge(fridgeProductsForCreation);

        public async Task<List<FridgeProduct>> GetFridgeProductsByFridgeId(Guid fridgeId) =>
            await _fridgeProductRepository.GetFridgeProductsByFridgeId(fridgeId);

        public async Task AddProductsWhereEmpty() =>
            await _fridgeProductRepository.AddProductsWhereEmpty();

        public async Task DeleteProductFromFridgeById(Guid id) =>
            await _fridgeProductRepository.DeleteProductFromFridgeById(id);
    }
}