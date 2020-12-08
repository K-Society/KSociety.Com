using System;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers
{
    [Area("Common")]
    public class TagGroupController : Controller
    {
        private readonly Model.Interface.Command.Common.ITagGroup _tagGroup;
        private readonly Model.Interface.Query.Common.ITagGroup _tagGroupQuery;
        private readonly Model.Interface.Query.Common.List.GridView.ITagGroup _tagGroupQueryListGridView;

        [BindProperty]
        public Srv.Dto.Common.TagGroup TagGroup { get; set; }

        [BindProperty]
        public Srv.Dto.Common.List.GridView.TagGroup TagGroupListGridView { get; set; }

        public TagGroupController(Model.Interface.Command.Common.ITagGroup tagGroup, Model.Interface.Query.Common.ITagGroup tagGroupQuery, Model.Interface.Query.Common.List.GridView.ITagGroup tagGroupQueryListGridView)
        {
            _tagGroup = tagGroup;
            _tagGroupQuery = tagGroupQuery;
            _tagGroupQueryListGridView = tagGroupQueryListGridView;
        }

        public async ValueTask<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            TagGroupListGridView = await _tagGroupQueryListGridView.LoadAllRecordsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                TagGroupListGridView.List =
                    TagGroupListGridView.List.Where(s => s.Name.Contains(searchString)).ToList();

            }

            switch (sortOrder)
            {
                case "name_desc":
                    TagGroupListGridView.List = TagGroupListGridView.List.OrderByDescending(n => n.Name).ToList();
                    break;
                case "Date":
                    //students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    //students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    //students = students.OrderBy(s => s.LastName);
                    break;
            }

            return View(TagGroupListGridView);
        }

        public async ValueTask<IActionResult> Upsert(Guid? id)
        {
            TagGroup = new KSociety.Com.Srv.Dto.Common.TagGroup();
            if (id == null)
            {
                return View(TagGroup);
            }
            TagGroup = await _tagGroupQuery.FindAsync(new KbIdObject(id.Value));
            if (TagGroup == null)
            {
                return NotFound();
            }
            return View(TagGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (TagGroup.Id == Guid.Empty)
                {
                    await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    //_tagGroup.Add(TagGroup.GetAddReq());
                }
                else
                {
                    var tagGroup = await _tagGroupQuery.FindAsync(new KbIdObject(TagGroup.Id));
                    if (tagGroup == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _tagGroup.UpdateAsync(TagGroup.GetUpdateReq());
                        //_tagGroup.Update(TagGroup.GetUpdateReq());
                    }
                }

                return RedirectToAction("Index");
            }

            return View(TagGroup);
        }

        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var tagGroup = await _tagGroupQuery.FindAsync(new KbIdObject(id));

            if (tagGroup == null)
            {
                return NotFound();
            }

            await _tagGroup.RemoveAsync(tagGroup.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }
    }
}
