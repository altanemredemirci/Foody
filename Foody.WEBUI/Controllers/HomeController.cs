using Foody.BLL.Abstract;
using Foody.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Foody.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll(i=>i.IsFavorite==true);

            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetOne(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
