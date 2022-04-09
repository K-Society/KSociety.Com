using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Web.App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers;

[Area("Common")]
public class TagGroupController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly KSociety.Com.Srv.Agent.Interface.Command.Common.ITagGroup _tagGroup;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.ITagGroup _tagGroupQuery;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITagGroup _tagGroupQueryListGridView;

    [BindProperty]
    public Srv.Dto.Common.TagGroup TagGroup { get; set; }

    [BindProperty]
    public Srv.Dto.Common.List.GridView.TagGroup TagGroupListGridView { get; set; }

    public TagGroupController(
        IWebHostEnvironment webHostEnvironment,
        KSociety.Com.Srv.Agent.Interface.Command.Common.ITagGroup tagGroup, 
        KSociety.Com.Srv.Agent.Interface.Query.Common.ITagGroup tagGroupQuery,
        KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITagGroup tagGroupQueryListGridView)
    {
        _webHostEnvironment = webHostEnvironment;
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
        TagGroup = await _tagGroupQuery.FindAsync(new IdObject(id.Value));
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
                var tagGroup = await _tagGroupQuery.FindAsync(new IdObject(TagGroup.Id));
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
        var tagGroup = await _tagGroupQuery.FindAsync(new IdObject(id));

        if (tagGroup == null)
        {
            return NotFound();
        }

        await _tagGroup.RemoveAsync(tagGroup.GetRemoveReq());

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

        var result = await _tagGroup.ExportDataAsync(new KSociety.Com.App.Dto.Req.Export.Common.TagGroup(path));
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

        await _tagGroup.ImportDataAsync(new KSociety.Com.App.Dto.Req.Import.Common.TagGroup(file.FileName, file.GetFileArray().Result));

        return RedirectToAction(nameof(Index));
    }
}