using Client.Models.FridgeProducts;
using Domain.Entities.FridgeProduct;
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

        public ViewResult Update(FridgeProductForUpdateViewModel fridgeProductForUpdateViewModel)
        {
            return View("Update", fridgeProductForUpdateViewModel);
        }

        [HttpPost]
        [ActionName(nameof(DeleteProductFromFridgeByIdAsync))]
        public async Task<IActionResult> DeleteProductFromFridgeByIdAsync(Guid id)
        {
            await _serviceManager.FridgeProductService.DeleteProductFromFridgeById(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ActionName(nameof(UpdateFridgeProductAsync))]
        public async Task<IActionResult> UpdateFridgeProductAsync(FridgeProductForUpdateViewModel fridgeProductForUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", fridgeProductForUpdateViewModel);
            }

            await _serviceManager.FridgeProductService.UpdateFridgeProductAsync(new FridgeProductForUpdate()
            {
                Id = fridgeProductForUpdateViewModel.Id,
                FridgeId = fridgeProductForUpdateViewModel.FridgeId,
                ProductId = fridgeProductForUpdateViewModel.ProductId,
                ProductQuantity = fridgeProductForUpdateViewModel.ProductQuantity
            });

            return RedirectToAction(nameof(GetByFridgeId), new { fridgeId = fridgeProductForUpdateViewModel.FridgeId });
        }
    }
}