using Foody.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.WEBUI.ViewComponents.Product
{
    public class _ProductListViewComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int? catId)
        {
            var products = new List<Foody.CORE.Entities.Product>();
            if (catId == null)
            {
                products = _productService.GetAll();                
            }
            else
            {
                products = _productService.GetAll(i => i.CategoryId == catId);
            }            
            return View(products);

        }
    }
}
