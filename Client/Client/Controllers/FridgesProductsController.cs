using Client.Models.FridgeProducts;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class FridgesProductsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public FridgesProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public ViewResult GetByFridgeId(FridgeProductViewModel fridgeProductsViewModel)
        {
            return View(fridgeProductsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByFridgeIdAsync(Guid fridgeId)
        {
            var fridgeProductsViewModel = new FridgeProductViewModel()
            {
                FridgeProducts = await _serviceManager.FridgeProductService.GetFridgeProductsByFridgeId(fridgeId)
            };

            return RedirectToAction(nameof(GetByFridgeId), new { fridgeProductsViewModel = fridgeProductsViewModel });
        }
    }
}