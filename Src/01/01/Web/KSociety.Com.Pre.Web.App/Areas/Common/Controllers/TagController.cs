using System;
using System.IO;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Web.App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.Common.Controllers;

[Area("Common")]
public class TagController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly KSociety.Com.Srv.Agent.Interface.Command.Common.ITag _tag;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.Model.ITag _tagQueryModel;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITag _tagQueryListGridView;

    //[BindProperty]
    //public Srv.Dto.Common.Tag Tag { get; set; }

    [BindProperty]
    public Srv.Dto.Common.Model.Tag TagModel { get; set; }

    [BindProperty]
    public Srv.Dto.Common.List.GridView.Tag TagListGridView { get; set; }

    public TagController(
        IWebHostEnvironment webHostEnvironment,
        KSociety.Com.Srv.Agent.Interface.Command.Common.ITag tag,
        KSociety.Com.Srv.Agent.Interface.Query.Common.Model.ITag tagQueryModel,
        KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITag tagQueryListGridView)
    {
        _webHostEnvironment = webHostEnvironment;
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
            TagModel = await _tagQueryModel.FindAsync(new IdObject(Guid.Empty));
            return View(TagModel);
        }
        TagModel = await _tagQueryModel.FindAsync(new IdObject(id.Value));
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
                var tagGroup = await _tagQueryModel.FindAsync(new IdObject(TagModel.TagDto.Id));
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
        var tag = await _tagQueryModel.FindAsync(new IdObject(id));

        if (tag == null)
        {
            return NotFound();
        }

        await _tag.RemoveAsync(tag.TagDto.GetRemoveReq());

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

        var result = await _tag.ExportDataAsync(new KSociety.Com.App.Dto.Req.Export.Common.Tag(path));
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

        await _tag.ImportDataAsync(new KSociety.Com.App.Dto.Req.Import.Common.Tag(file.FileName, file.GetFileArray().Result));

        return RedirectToAction(nameof(Index));
    }
}