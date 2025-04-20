using Foody.WEBUI.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace Foody.WEBUI.ViewComponents.Contact
{
    public class _SendMailViewComponentPartial:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View(new Mail());
        }
    }
}
