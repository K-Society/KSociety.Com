using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers
{
    [Area("Common")]
    public class TagController : Controller
    {
        private readonly Model.Interface.Command.Common.ITag _tag;
        private readonly Model.Interface.Query.Common.Model.ITag _tagQueryModel;
        private readonly Model.Interface.Query.Common.List.GridView.ITag _tagQueryListGridView;

        //[BindProperty]
        //public Srv.Dto.Common.Tag Tag { get; set; }

        [BindProperty]
        public Srv.Dto.Common.Model.Tag TagModel { get; set; }

        [BindProperty]
        public Srv.Dto.Common.List.GridView.Tag TagListGridView { get; set; }

        public TagController(
            Model.Interface.Command.Common.ITag tag, 
            Model.Interface.Query.Common.Model.ITag tagQueryModel,
            Model.Interface.Query.Common.List.GridView.ITag tagQueryListGridView)
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
            if (TagModel.TagDto == null)
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
                if (TagModel.TagDto.Id == Guid.Empty)
                {
                    await _tag.AddAsync(TagModel.TagDto.GetAddReq());
                }
                else
                {
                    var tagGroup = await _tagQueryModel.FindAsync(new KbIdObject(TagModel.TagDto.Id));
                    if (tagGroup == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _tag.UpdateAsync(TagModel.TagDto.GetUpdateReq());
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

            await _tag.RemoveAsync(tag.TagDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }
    }
}
