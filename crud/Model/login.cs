using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Model
{
    public class login
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Required integer value"), MaxLength(100, ErrorMessage = "User Name cannot be more that 100")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Required integer value"), MaxLength(15, ErrorMessage = "Password cannot be more that 15")]
        public string Password { get; set; }
        public string Token { get; set; }
        public string expiry { get; set; }
    }
}
