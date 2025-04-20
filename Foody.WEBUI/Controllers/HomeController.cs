using Foody.BLL.Abstract;
using Foody.WEBUI.EmailService;
using Foody.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Foody.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IContactService _contactService;

        public HomeController(IProductService productService, IContactService contactService)
        {
            _productService = productService;
            _contactService = contactService;
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
            var model = _contactService.GetById();
            return View(model);
        }

        [HttpPost]
        public IActionResult SendMail(Mail mail)
        {
            if (ModelState.IsValid)
            {
                string body = $"Sayýn Ýlgili,<br>{mail.Name} isimli kullanýcý {mail.Subject} konusunda bilgi almak istiyor.<br> Mesaj:{mail.Message} Cevaplamak için <a href='{mail.Email}'> adresinden cevaplayabilirsiniz";

                var result = MailHelper.SendMail(body, "altanemre1989@gmail.com", mail.Subject);
                if (result)
                {
                    TempData["message"] = "Emailiniz Baþarýyla Gönderilmiþtir. En kýsa sürede geri dönüþ yapýlacaktýr.";
                    return RedirectToAction("Contact");
                }
                else
                {
                    TempData["message"] = "Emailiniz Gönderme Ýþlemi Baþarýsýz Oldu. Lütfen tekrar deneyiniz.";
                    return View(mail);
                }
            }
            return View(mail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
