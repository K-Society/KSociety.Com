using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Controllers
{
    public class SettingsController : Controller
    {
        private readonly KSociety.Base.Srv.Agent.IAgentDatabaseControl _databaseControl;

        public SettingsController(KSociety.Base.Srv.Agent.IAgentDatabaseControl databaseControl)
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
