using System;
using System.IO;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Web.App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Com.Pre.Web.App.Areas.S7.Controllers;

[Area("S7")]
public class S7TagController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly KSociety.Com.Srv.Agent.Interface.Command.S7.IS7Tag _tag;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.S7.Model.IS7Tag _tagQueryModel;
    private readonly KSociety.Com.Srv.Agent.Interface.Query.S7.List.GridView.IS7Tag _tagQueryListGridView;

    [BindProperty] 
    public Srv.Dto.S7.Model.S7Tag TagModel { get; set; }

    [BindProperty]
    public Srv.Dto.S7.List.GridView.S7Tag TagListGridView { get; set; }

    public S7TagController(
        IWebHostEnvironment webHostEnvironment,
        KSociety.Com.Srv.Agent.Interface.Command.S7.IS7Tag tag, KSociety.Com.Srv.Agent.Interface.Query.S7.Model.IS7Tag tagQueryModel, KSociety.Com.Srv.Agent.Interface.Query.S7.List.GridView.IS7Tag tagQueryListGridView)
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
                var tagGroup = await _tagQueryModel.FindAsync(new IdObject(TagModel.S7TagDto.Id));
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
        var tag = await _tagQueryModel.FindAsync(new IdObject(id));

        if (tag == null)
        {
            return NotFound();
        }

        await _tag.RemoveAsync(tag.S7TagDto.GetRemoveReq());

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

        var result = await _tag.ExportAsync(new KSociety.Com.App.Dto.Req.Export.S7.S7Tag(path));
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

        await _tag.ImportAsync(new KSociety.Com.App.Dto.Req.Import.S7.S7Tag(file.FileName, file.GetFileArray().Result));

        return RedirectToAction(nameof(Index));
    }
}