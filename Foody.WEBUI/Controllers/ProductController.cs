using AutoMapper;
using Foody.BLL.Abstract;
using Foody.CORE.DTOs.Product;
using Foody.CORE.Entities;
using Foody.WEBUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foody.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,ICategoryService categoryService,IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public ActionResult Create() 
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductDTO createProductDTO, IFormFile[] files)
        {
            if (ModelState.IsValid)
            {
                Product p = _mapper.Map<Product>(createProductDTO);
                if (files != null)
                {
                    foreach (IFormFile item in files)
                    {
                      p.Images.Add(new Image() {Url= await ImageOperations.UploadImageAsync(item) });
                    }
                }
                p.CreatedDate = DateTime.Now;
                _productService.Create(p);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(createProductDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Bir Ürün Seçiniz";
                return RedirectToAction("Index");
            }
            var products = _productService.GetOne(id.Value);

            if (products == null)
            {
                TempData["message"] = "Seçilen Ürün Bulunamadı";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(_mapper.Map<UpdateProductDTO>(products));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateProductDTO updateProduct, IFormFile[] files, int[] ImageId)
        {
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    foreach (IFormFile item in files)
                    {
                        updateProduct.Images.Add(new Image() { Url = await ImageOperations.UploadImageAsync(item) });
                    }
                }
                //updateProduct.CreatedDate = DateTime.Now;
                //_productService.Create(updateProduct);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(updateProduct);
        }
    }
}
