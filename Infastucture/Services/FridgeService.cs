using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models.Fridge;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastucture.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _fridgeRepository;

        public FridgeService(IFridgeRepository fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public async Task<List<FridgeDto>> GetAllFridgesAsync() =>
            await _fridgeRepository.GetAllFridgesAsync();
    }
}