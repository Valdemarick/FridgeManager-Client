using Client.Models.Fridges;
using Domain.Entities.FridgeModel;
using Domain.Entities.Fridges;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class FridgesController : Controller
    {
        private readonly IFridgeService _fridgeService;
        private readonly IFridgeModelService _fridgeModelService;

        public FridgesController(IFridgeService fridgeService, IFridgeModelService fridgeModelService)
        {
            _fridgeService = fridgeService;
            _fridgeModelService = fridgeModelService;
        }

        public async Task<IActionResult> Index()
        {
            var fridges = new FridgesViewModel
            {
                Fridges = await _fridgeService.GetAllFridgesAsync()
            };

            return View(fridges);
        }

        public async Task<IActionResult> Create()
        {
            var models = await GetModels();
            SelectList modelsList = new SelectList(models, "Id", "Name");

            ViewBag.Models = modelsList;

            return View("Create", new FridgeForCreationViewModel());
        }

        public async Task<IActionResult> Update(FridgeForUpdateViewModel fridgeForUpdateViewModel)
        {
            var models = await GetModels();
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

            var fridgeForCreation = new FridgeForCreation()
            {
                FridgeModelId = fridgeForCreationViewModel.FridgeModelId,
                OwnerName = fridgeForCreationViewModel?.OwnerName,
                Description = fridgeForCreationViewModel?.Description,
            };

            await _fridgeService.CreateFridgeAsync(fridgeForCreation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(UpdateFridgeAsync))]
        public async Task<IActionResult> UpdateFridgeAsync(FridgeForUpdateViewModel fridgeForUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View("Update", fridgeForUpdateViewModel);

            var fridgeForUpdate = new FridgeForUpdate()
            {
                Id = fridgeForUpdateViewModel.Id,
                FridgeModelId = fridgeForUpdateViewModel.FridgeModelId,
                OwnerName = fridgeForUpdateViewModel?.OwnerName,
                Description = fridgeForUpdateViewModel?.Description
            };

            await _fridgeService.UpdateFridgeAsync(fridgeForUpdate);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(DeleteFridgeAsync))]
        public async Task<IActionResult> DeleteFridgeAsync(Guid id)
        {
            await _fridgeService.DeleteFridgeAsync(id);

            return RedirectToAction("Index");
        }

        private async Task<List<FridgeModel>> GetModels() =>
            await _fridgeModelService.GetAllFridgeModelsAsync();
    }
}