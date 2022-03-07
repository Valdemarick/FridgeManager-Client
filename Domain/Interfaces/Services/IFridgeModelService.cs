using Domain.Entities.FridgeModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IFridgeModelService
    {
        Task<List<FridgeModel>> GetAllFridgeModelsAsync();
    }
}