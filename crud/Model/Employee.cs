using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
