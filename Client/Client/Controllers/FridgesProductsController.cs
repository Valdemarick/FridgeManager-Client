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

        public async Task<IActionResult> GetByFridgeId(Guid fridgeId)
        {
            var fridgeProductsViewModel = new FridgeProductViewModel()
            {
                FridgeProducts = await _serviceManager.FridgeProductService.GetFridgeProductsByFridgeIdAsync(fridgeId)
            };

            return View(fridgeProductsViewModel);
        }

        public IActionResult Update(FridgeProductForUpdateViewModel fridgeProductForUpdateViewModel)
        {
            return View("Update", fridgeProductForUpdateViewModel);
        }

        public IActionResult Delete(FridgeProductForDeleteViewModel fridgeProductForDeleteViewModel) => 
            PartialView("_DeletePartial", fridgeProductForDeleteViewModel);

        [HttpPost]
        [ActionName(nameof(DeleteProductFromFridgeByIdAsync))]
        public async Task<IActionResult> DeleteProductFromFridgeByIdAsync(Guid id)
        {
            await _serviceManager.FridgeProductService.DeleteProductFromFridgeByIdAsync(id);
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