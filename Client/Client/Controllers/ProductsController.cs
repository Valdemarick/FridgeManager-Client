using Application.Interfaces.Services;
using Client.Models.Products;
using Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = new ProductsViewModel
            {
                Products = await _productService.GetAllProductsAsync()
            };

            return View(products);
        }

        public IActionResult Create()
        {
            return View("Create", new ProductForCreationViewModel());
        }

        public IActionResult Update(ProductForUpdateViewModel productForUpdateViewModel)
        {
            return View("Update", productForUpdateViewModel);
        }

        [HttpPost]
        [ActionName(nameof(CreateProductAsync))]
        public async Task<IActionResult> CreateProductAsync(ProductForCreationViewModel productForCreationViewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", productForCreationViewModel);

            var productForCreation = new ProductForCreation()
            {
                Name = productForCreationViewModel.Name,
                Quantity = productForCreationViewModel.Quantity,
            };

            await _productService.CreateProductAsync(productForCreation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(DeleteProductAsync))]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(UpdateProductAsync))]
        public async Task<IActionResult> UpdateProductAsync(ProductForUpdateViewModel productForUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View("Update", productForUpdateViewModel);

            var productForUpdate = new ProductForUpdate()
            {
                Id = productForUpdateViewModel.Id,
                Name = productForUpdateViewModel.Name,
                Quantity = productForUpdateViewModel.Quantity
            };

            await _productService.UpdateProductAsync(productForUpdate);

            return RedirectToAction("Index");
        }
    }
}