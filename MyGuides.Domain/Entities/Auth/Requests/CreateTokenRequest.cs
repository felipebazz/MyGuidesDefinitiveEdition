using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Domain.Entities.Auth.Requests
{
    public class CreateTokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
