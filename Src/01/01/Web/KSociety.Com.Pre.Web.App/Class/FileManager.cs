using System.Collections.Generic;
using System.IO;

namespace KSociety.Com.Pre.Web.App.Class
{
    public static class FileManager
    {
        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new()
            {
                { ".csv", "text/csv" }
            };
        }
    }
}
