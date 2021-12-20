using Microsoft.AspNetCore.Http;

namespace KSociety.Com.Pre.Web.App.Models;

public class FileInputModel
{
    public IFormFile FileToUpload { get; set; }
}