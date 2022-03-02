using Application.Interfaces.Services;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}