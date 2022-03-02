using Application.Interfaces.Services;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class FridgesController : Controller
    {
        private readonly IFridgeService _fridgeService;

        public FridgesController(IFridgeService fridgeService)
        {
            _fridgeService = fridgeService;
        }

        public async Task<IActionResult> Index()
        {
            var fridges = new FridgesViewModel
            {
                Fridges = await _fridgeService.GetAllFridgesAsync()
            };

            return View(fridges);
        }
    }
}