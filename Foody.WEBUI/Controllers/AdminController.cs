using Foody.BLL.Abstract;
using Foody.CORE.Entities;
using Foody.WEBUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foody.WEBUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var about = _aboutService.GetOne(1);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> About(About model, IFormFile file)
        {
            ModelState.Remove("ImageUrl");
            ModelState.Remove("file");
            if (ModelState.IsValid)
            {
                var about = _aboutService.GetOne(model.Id);

                if (file != null)
                {
                    model.ImageUrl = await ImageOperations.UploadImageAsync(file);
                }
                else
                {
                    model.ImageUrl = about.ImageUrl;
                }

                //AutoMapper
                about.Text = model.Text;
                about.Property1 = model.Property1;
                about.Property3 = model.Property3;
                about.Property2 = model.Property2;
                about.Title = model.Title;
                about.ImageUrl = model.ImageUrl;

                _aboutService.Update();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
