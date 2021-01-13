using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Web.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers
{
    [Area("Common")]
    public class ConnectionController : Controller
    {
        private readonly Model.Interface.Command.Common.IConnection _connection;
        private readonly Model.Interface.Query.Common.Model.IConnection _connectionQueryModel;
        private readonly Model.Interface.Query.Common.List.GridView.IConnection _connectionQueryListGridView;

        [BindProperty]
        public Srv.Dto.Common.Model.Connection ConnectionModel { get; set; }

        [BindProperty]
        public Srv.Dto.Common.List.GridView.Connection ConnectionListGridView { get; set; }

        public ConnectionController(
            Model.Interface.Command.Common.IConnection connection,
            Model.Interface.Query.Common.Model.IConnection connectionQueryModel,
            Model.Interface.Query.Common.List.GridView.IConnection connectionQueryListGridView)
        {
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
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
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

            //var path = Path.Combine(
            //    Directory.GetCurrentDirectory(),
            //    "wwwroot", "import", file.GetFilename());

            //await using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //    await stream.FlushAsync();
                
            //}

            await _connection.ImportAsync(new KSociety.Com.App.Dto.Req.Import.Common.Connection(file.GetFilename(), file.GetFileArray().Result));

            return RedirectToAction(nameof(Index));
        }
    }
}
