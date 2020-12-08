using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
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
                ConnectionModel = await _connectionQueryModel.FindAsync(new KbIdObject(Guid.Empty));
                return View(ConnectionModel);
            }
            ConnectionModel = await _connectionQueryModel.FindAsync(new KbIdObject(id.Value));
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
                    var connection = await _connectionQueryModel.FindAsync(new KbIdObject(ConnectionModel.ConnectionDto.Id));
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
            var connection = await _connectionQueryModel.FindAsync(new KbIdObject(id));

            if (connection == null)
            {
                return NotFound();
            }

            await _connection.RemoveAsync(connection.ConnectionDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }

        public async ValueTask Export(string csvPath)
        {
            await _connection.ExportAsync(new KSociety.Com.App.Dto.Req.Export.Common.Connection(csvPath));


        }
    }
}
