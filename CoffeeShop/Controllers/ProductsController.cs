using Coffeeshop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Coffeeshop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View("~/Views/Products/Shop.cshtml", productRepository.GetAllProducts());
        }

        public IActionResult Detail(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if (product != null)
            {
                return View("~/Views/Products/Detail.cshtml", product);
            }
            return NotFound();
        }

        public IActionResult Trending()
        {
            return View("~/Views/Products/Trending.cshtml", productRepository.GetTrendingProducts());
        }
    }
}