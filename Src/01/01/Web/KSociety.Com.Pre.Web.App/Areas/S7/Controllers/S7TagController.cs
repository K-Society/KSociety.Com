using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.S7.Controllers
{
    [Area("S7")]
    public class S7TagController : Controller
    {
        private readonly Model.Interface.Command.S7.IS7Tag _tag;
        private readonly Model.Interface.Query.S7.Model.IS7Tag _tagQueryModel;
        private readonly Model.Interface.Query.S7.List.GridView.IS7Tag _tagQueryListGridView;

        [BindProperty] 
        public Srv.Dto.S7.Model.S7Tag TagModel { get; set; }

        [BindProperty]
        public Srv.Dto.S7.List.GridView.S7Tag TagListGridView { get; set; }

        public S7TagController(Model.Interface.Command.S7.IS7Tag tag, Model.Interface.Query.S7.Model.IS7Tag tagQueryModel, Model.Interface.Query.S7.List.GridView.IS7Tag tagQueryListGridView)
        {
            _tag = tag;
            _tagQueryModel = tagQueryModel;
            _tagQueryListGridView = tagQueryListGridView;
        }

        public async ValueTask<IActionResult> Index()
        {
            TagListGridView = await _tagQueryListGridView.LoadAllRecordsAsync();
            return View(TagListGridView);
        }

        public async ValueTask<IActionResult> Upsert(Guid? id)
        {
            
            if (id == null)
            {
                TagModel = await _tagQueryModel.FindAsync(new KbIdObject(Guid.Empty));
                return View(TagModel);
            }
            TagModel = await _tagQueryModel.FindAsync(new KbIdObject(id.Value));
            if (TagModel == null)
            {
                return NotFound();
            }
            return View(TagModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (TagModel.S7TagDto.Id == Guid.Empty)
                {
                    await _tag.AddAsync(TagModel.S7TagDto.GetAddReq());
                }
                else
                {
                    var tagGroup = await _tagQueryModel.FindAsync(new KbIdObject(TagModel.S7TagDto.Id));
                    if (tagGroup == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _tag.UpdateAsync(TagModel.S7TagDto.GetUpdateReq());
                    }
                }

                return RedirectToAction("Index");
            }

            return View(TagModel);
        }

        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var tag = await _tagQueryModel.FindAsync(new KbIdObject(id));

            if (tag == null)
            {
                return NotFound();
            }

            await _tag.RemoveAsync(tag.S7TagDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }
    }
}
