using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Model
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
