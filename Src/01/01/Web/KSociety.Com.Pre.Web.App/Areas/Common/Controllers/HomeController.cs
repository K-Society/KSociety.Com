using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers
{
    [Area("Common")]
    public class HomeController : Controller
    {
        private readonly KSociety.Base.Pre.Model.Control.IDatabaseControl _databaseControl;

        public HomeController(KSociety.Base.Pre.Model.Control.IDatabaseControl databaseControl)
        {
            _databaseControl = databaseControl;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
