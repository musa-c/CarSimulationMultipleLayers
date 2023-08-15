using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
