using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.S7.Controllers
{
    [Area("S7")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
