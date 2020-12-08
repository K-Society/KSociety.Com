using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Controllers
{
    public class SettingsController : Controller
    {
        private readonly Base.Pre.Model.Control.IDatabaseControl _databaseControl;

        public SettingsController(Base.Pre.Model.Control.IDatabaseControl databaseControl)
        {
            _databaseControl = databaseControl;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _databaseControl.GetConnectionString();
            return View();
        }

        public async Task<IActionResult> EnsureDeleted()
        {

            await _databaseControl.EnsureDeletedAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EnsureCreate()
        {

            await _databaseControl.EnsureCreatedAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Migration()
        {

            await _databaseControl.MigrationAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
