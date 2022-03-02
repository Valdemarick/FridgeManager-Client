using Domain.Entities.Fridges;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        Task<List<Fridge>> GetAllFridgesAsync();
    }
}