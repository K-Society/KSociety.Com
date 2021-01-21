using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Web.App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers
{
    [Area("Common")]
    public class ConnectionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly KSociety.Com.Srv.Agent.Interface.Command.Common.IConnection _connection;
        private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.Model.IConnection _connectionQueryModel;
        private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.IConnection _connectionQueryListGridView;

        [BindProperty]
        public Srv.Dto.Common.Model.Connection ConnectionModel { get; set; }

        [BindProperty]
        public Srv.Dto.Common.List.GridView.Connection ConnectionListGridView { get; set; }

        public ConnectionController(
            IWebHostEnvironment webHostEnvironment,
            KSociety.Com.Srv.Agent.Interface.Command.Common.IConnection connection,
            KSociety.Com.Srv.Agent.Interface.Query.Common.Model.IConnection connectionQueryModel,
            KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.IConnection connectionQueryListGridView)
        {
            _webHostEnvironment = webHostEnvironment;
            _connection = connection;
            _connectionQueryModel = connectionQueryModel;
            _connectionQueryListGridView = connectionQueryListGridView;
        }

        public async ValueTask<IActionResult> Index()
        {
            ConnectionListGridView = await _connectionQueryListGridView.LoadAllRecordsAsync();
            return View(ConnectionListGridView);
        }

        public async ValueTask<IActionResult> Upsert(Guid? id)
        {
            if (id == null)
            {
                ConnectionModel = await _connectionQueryModel.FindAsync(new IdObject(Guid.Empty));
                return View(ConnectionModel);
            }
            ConnectionModel = await _connectionQueryModel.FindAsync(new IdObject(id.Value));
            if (ConnectionModel.ConnectionDto == null)
            {
                return NotFound();
            }

            return View(ConnectionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (ConnectionModel.ConnectionDto.Id == Guid.Empty)
                {
                    await _connection.AddAsync(ConnectionModel.ConnectionDto.GetAddReq());
                }
                else
                {
                    var connection = await _connectionQueryModel.FindAsync(new IdObject(ConnectionModel.ConnectionDto.Id));
                    if (connection == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _connection.UpdateAsync(ConnectionModel.ConnectionDto.GetUpdateReq());
                    }
                }

                return RedirectToAction("Index");
            }

            return View(ConnectionModel);
        }

        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var connection = await _connectionQueryModel.FindAsync(new IdObject(id));

            if (connection == null)
            {
                return NotFound();
            }

            await _connection.RemoveAsync(connection.ConnectionDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }

        public async ValueTask<IActionResult> Export(string fileName)
        {
            if (!Directory.Exists(Path.Combine(
                _webHostEnvironment.ContentRootPath,
                "wwwroot", "export")))
            {
                Directory.CreateDirectory(Path.Combine(
                    _webHostEnvironment.ContentRootPath,
                    "wwwroot", "export"));
            }

            var path = Path.Combine(
                _webHostEnvironment.ContentRootPath,
                "wwwroot", "export", fileName);

            var result = await _connection.ExportAsync(new KSociety.Com.App.Dto.Req.Export.Common.Connection(path));
            if (result.Result)
            {
                var memory = new MemoryStream();
                await using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, Class.FileManager.GetContentType(path), Path.GetFileName(path));
            }

            return Content("filename not present");
        }

        [HttpPost]
        public async ValueTask<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            await _connection.ImportAsync(new KSociety.Com.App.Dto.Req.Import.Common.Connection(file.GetFilename(), file.GetFileArray().Result));

            return RedirectToAction(nameof(Index));
        }
    }
}
