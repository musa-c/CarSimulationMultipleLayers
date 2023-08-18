using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        string Add(IFormFile file);
        void Delete(string path);
        void Update(IFormFile file, string imagePath);
    }
}
