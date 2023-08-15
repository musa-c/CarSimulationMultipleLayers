using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public required string Audience { get; set; }
        public required string Issuer{ get; set; }
        public int AccessTokenExpiration { get; set; }
        public required string SecurityKey { get; set; }
    }
}
