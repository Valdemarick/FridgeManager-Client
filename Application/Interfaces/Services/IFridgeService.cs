using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFridgeService
    {
        Task<List<FridgeDto>> GetAllFridgesAsync();
    }
}