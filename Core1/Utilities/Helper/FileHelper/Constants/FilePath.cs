using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Utilities.Helper.FileHelper.Constants
{
    public static class FilePath
    {
        public static string Full(string path, string root = FileType.root, string fileType = FileType.images)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), root + fileType, path);
        }
    }
}
