using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers;

[Area("Common")]
public class HomeController : Controller
{
    private readonly KSociety.Base.Srv.Agent.IAgentDatabaseControl _databaseControl;

    public HomeController(KSociety.Base.Srv.Agent.IAgentDatabaseControl databaseControl)
    {
        _databaseControl = databaseControl;
    }

    public IActionResult Index()
    {
        return View();
    }
}