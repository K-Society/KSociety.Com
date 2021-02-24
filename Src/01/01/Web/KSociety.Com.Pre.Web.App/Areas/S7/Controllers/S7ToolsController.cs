using KSociety.Com.App.Dto.Req.Biz;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KSociety.Com.Pre.Web.App.Areas.S7.Controllers
{
    [Area("S7")]
    public class S7ToolsController : Controller
    {
        private readonly KSociety.Com.Srv.Agent.Interface.Biz.IBiz _biz;

        [BindProperty]
        public Com.App.Dto.Res.Biz.GetTagValue GetTagValue { get; set; }

        public S7ToolsController(KSociety.Com.Srv.Agent.Interface.Biz.IBiz biz)
        {
            _biz = biz;
            GetTagValue = new Com.App.Dto.Res.Biz.GetTagValue();
        }

        public IActionResult Index()
        {
            ;
            return View(GetTagValue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Index(string groupName, string tagName)
        {
            if (ModelState.IsValid)
            {
                var result = await _biz.GetTagValueAsync(new GetTagValue(GetTagValue.GroupName, GetTagValue.TagName));
                GetTagValue = result;
                ViewBag.Value = result.Value;
                return View();
            }

            return View();
        }
    }
}
