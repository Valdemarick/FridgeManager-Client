using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        Task<List<FridgeDto>> GetAllFridgesAsync();
    }
}