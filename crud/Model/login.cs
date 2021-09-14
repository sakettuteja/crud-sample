using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Model
{
    public class login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string expiry { get; set; }
    }
}
