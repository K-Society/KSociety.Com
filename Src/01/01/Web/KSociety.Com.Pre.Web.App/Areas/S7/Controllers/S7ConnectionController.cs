using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.S7.Controllers
{
    [Area("S7")]
    public class S7ConnectionController : Controller
    {
        private readonly Model.Interface.Command.S7.IS7Connection _s7Connection;
        //private readonly Model.Interface.Query.S7.IS7Connection _s7ConnectionQuery;
        private readonly Model.Interface.Query.S7.Model.IS7Connection _s7ConnectionQueryModel;
        private readonly Model.Interface.Query.S7.List.GridView.IS7Connection _s7ConnectionQueryListGridView;

        [BindProperty]
        public Srv.Dto.S7.Model.S7Connection S7ConnectionModel { get; set; }

        [BindProperty]
        public Srv.Dto.S7.List.GridView.S7Connection S7ConnectionListGridView { get; set; }

        public S7ConnectionController(
            Model.Interface.Command.S7.IS7Connection s7Connection, 
            Model.Interface.Query.S7.Model.IS7Connection s7ConnectionQueryModel,
            Model.Interface.Query.S7.List.GridView.IS7Connection s7ConnectionQueryListGridView)
        {
            _s7Connection = s7Connection;
            _s7ConnectionQueryModel = s7ConnectionQueryModel;
            _s7ConnectionQueryListGridView = s7ConnectionQueryListGridView;
        }

        public async ValueTask<IActionResult> Index()
        {
            S7ConnectionListGridView = await _s7ConnectionQueryListGridView.LoadAllRecordsAsync();
            return View(S7ConnectionListGridView);
        }

        public async ValueTask<IActionResult> Upsert(Guid? id)
        {
            
            if (id == null)
            {
                S7ConnectionModel = await _s7ConnectionQueryModel.FindAsync(new KbIdObject(Guid.Empty));
                return View(S7ConnectionModel);
            }
            S7ConnectionModel = await _s7ConnectionQueryModel.FindAsync(new KbIdObject(id.Value));
            if (S7ConnectionModel == null)
            {
                return NotFound();
            }
            return View(S7ConnectionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (S7ConnectionModel.S7ConnectionDto.Id == Guid.Empty)
                {
                    await _s7Connection.AddAsync(S7ConnectionModel.S7ConnectionDto.GetAddReq());
                    //_s7Connection.Add(S7ConnectionModel.S7ConnectionDto.GetAddReq());
                }
                else
                {
                    var s7Connection = await _s7ConnectionQueryModel.FindAsync(new KbIdObject(S7ConnectionModel.S7ConnectionDto.Id));
                    if (s7Connection == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _s7Connection.UpdateAsync(S7ConnectionModel.S7ConnectionDto.GetUpdateReq());
                    }
                }

                return RedirectToAction("Index");
            }

            return View(S7ConnectionModel);
        }

        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var s7Connection = await _s7ConnectionQueryModel.FindAsync(new KbIdObject(id));

            if (s7Connection == null)
            {
                return NotFound();
            }

            await _s7Connection.RemoveAsync(s7Connection.S7ConnectionDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }
    }
}
