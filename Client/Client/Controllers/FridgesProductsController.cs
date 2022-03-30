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

        public async Task<ViewResult> GetByFridgeId(Guid fridgeId)
        {
            var fridgeProductsViewModel = new FridgeProductViewModel()
            {
                FridgeProducts = await _serviceManager.FridgeProductService.GetFridgeProductsByFridgeId(fridgeId)
            };

            return View(fridgeProductsViewModel);
        }

        [HttpPost]
        [ActionName(nameof(DeleteProductFromFridgeByIdAsync))]
        public async Task<IActionResult> DeleteProductFromFridgeByIdAsync(Guid id)
        {
            await _serviceManager.FridgeProductService.DeleteProductFromFridgeById(id);
            return RedirectToAction("Index", "Home");
        }
    }
}