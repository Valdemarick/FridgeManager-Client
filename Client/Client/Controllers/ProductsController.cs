using Client.Models.Products;
using Domain.Entities.Products;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<ViewResult> Index()
        {
            var products = new ProductsViewModel
            {
                Products = await _serviceManager.ProductService.GetAllProductsAsync()
            };

            return View(products);
        }

        public ViewResult Create() => View("Create", new ProductForCreationViewModel());

        public ViewResult Update(ProductForUpdateViewModel productForUpdateViewModel) => View("Update", productForUpdateViewModel);

        [HttpPost]
        [ActionName(nameof(CreateProductAsync))]
        public async Task<IActionResult> CreateProductAsync(ProductForCreationViewModel productForCreationViewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", productForCreationViewModel);

            await _serviceManager.ProductService.CreateProductAsync(new ProductForCreation()
            {
                Name = productForCreationViewModel.Name,
                Quantity = productForCreationViewModel.Quantity,
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(DeleteProductAsync))]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            await _serviceManager.ProductService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(UpdateProductAsync))]
        public async Task<IActionResult> UpdateProductAsync(ProductForUpdateViewModel productForUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View("Update", productForUpdateViewModel);

            await _serviceManager.ProductService.UpdateProductAsync(new ProductForUpdate()
            {
                Id = productForUpdateViewModel.Id,
                Name = productForUpdateViewModel.Name,
                Quantity = productForUpdateViewModel.Quantity
            });

            return RedirectToAction("Index");
        }
    }
}