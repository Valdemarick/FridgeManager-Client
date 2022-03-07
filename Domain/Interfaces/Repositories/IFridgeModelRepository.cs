using Domain.Entities.FridgeModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFridgeModelRepository
    {
        Task<List<FridgeModel>> GetAllFridgeModelsAsync();
    }
}