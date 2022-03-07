using Domain.Entities.FridgeModel;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FridgeModelService : IFridgeModelService
    {
        private readonly IFridgeModelRepository _fridgeModelRepository;

        public FridgeModelService(IFridgeModelRepository fridgeModelRepository)
        {
            _fridgeModelRepository = fridgeModelRepository;
        }

        public async Task<List<FridgeModel>> GetAllFridgeModelsAsync() =>
            await _fridgeModelRepository.GetAllFridgeModelsAsync();
    }
}