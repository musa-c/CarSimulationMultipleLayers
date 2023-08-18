using Castle.Components.DictionaryAdapter;
using Core.Utilities.Helper.FileHelper.Constants;
using Core.Utilities.Helper.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Add(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string uniqueFileName = GuidHelper_.Create() + fileExtension;
            var imagePath = FilePath.Full(uniqueFileName);
            using FileStream fileStream = new(imagePath, FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Flush();
            return uniqueFileName;
        }

        public void Delete(string path)
        {
            if (Path.Exists(FilePath.Full(path))) //varsa true
            {
                File.Delete(FilePath.Full(path));
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
        }

        public void Update(IFormFile file, string imagePath)
        {
            var fullpath = FilePath.Full(imagePath);
            if (Path.Exists(fullpath))
            {
                using FileStream fileStream = new(fullpath, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
            
        }
    }
}
