using Foody.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foody.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
