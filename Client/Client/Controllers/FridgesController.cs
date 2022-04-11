using Client.Models.Fridges;
using Domain.Entities.Fridges;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class FridgesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public FridgesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var fridges = new FridgesViewModel
            {
                Fridges = await _serviceManager.FridgeService.GetAllFridgesAsync()
            };

            return View(fridges);
        }

        public IActionResult Delete(FridgeForDeleteViewModel fridgeForDeleteViewModel) => PartialView("_DeletePartial", fridgeForDeleteViewModel);

        public async Task<IActionResult> Create()
        {
            var models = await _serviceManager.FridgeModelService.GetAllFridgeModelsAsync();
            SelectList modelsList = new SelectList(models, "Id", "Name");

            var products = await _serviceManager.ProductService.GetAllProductsAsync();
            var fridgeForCreationViewModel = new FridgeForCreationViewModel()
            {
                Products = new MultiSelectList(products, "Id", "Name"),
            };

            ViewBag.Models = modelsList;
            return View("Create", fridgeForCreationViewModel);
        }

        public async Task<IActionResult> Update(FridgeForUpdateViewModel fridgeForUpdateViewModel)
        {
            var models = await _serviceManager.FridgeModelService.GetAllFridgeModelsAsync();
            SelectList modelsList = new SelectList(models, "Id", "Name");

            ViewBag.Models = modelsList;
            return View("Update", fridgeForUpdateViewModel);
        }

        [HttpPost]
        [ActionName(nameof(CreateFridgeAsync))]
        public async Task<IActionResult> CreateFridgeAsync(FridgeForCreationViewModel fridgeForCreationViewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", fridgeForCreationViewModel);

            var createdFridge = await _serviceManager.FridgeService.CreateFridgeAsync(new FridgeForCreation()
            {
                FridgeModelId = fridgeForCreationViewModel.FridgeModelId,
                OwnerName = fridgeForCreationViewModel?.OwnerName,
                Description = fridgeForCreationViewModel?.Description,
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(UpdateFridgeAsync))]
        public async Task<IActionResult> UpdateFridgeAsync(FridgeForUpdateViewModel fridgeForUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View("Update", fridgeForUpdateViewModel);

            await _serviceManager.FridgeService.UpdateFridgeAsync(new FridgeForUpdate()
            {
                Id = fridgeForUpdateViewModel.Id,
                FridgeModelId = fridgeForUpdateViewModel.FridgeModelId,
                OwnerName = fridgeForUpdateViewModel?.OwnerName,
                Description = fridgeForUpdateViewModel?.Description
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(DeleteFridgeAsync))]
        public async Task<IActionResult> DeleteFridgeAsync(Guid id)
        {
            await _serviceManager.FridgeService.DeleteFridgeAsync(id);
            return RedirectToAction("Index");
        }
    }
}