using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.GuidHelper
{
    public class GuidHelper_
    {
        public static string Create()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
