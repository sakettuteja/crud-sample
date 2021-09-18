using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Model
{
    public class EmployeeDTO
    {
        [Required]
        [DataType(DataType.Text,ErrorMessage ="Required integer value"),MaxLength(8,ErrorMessage ="Id cannot be more that 8")]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Required integer value"), MaxLength(100, ErrorMessage = "Email cannot be more that 100")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Required integer value"), MaxLength(15, ErrorMessage = "Password cannot be more that 15")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Required integer value"), MaxLength(30, ErrorMessage = "First Name cannot be more that 15")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Required integer value"), MaxLength(30, ErrorMessage = "Last Name cannot be more that 30")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Required integer value"), MaxLength(3, ErrorMessage = "Age cannot be more that 3 digit"),Range(1,120,ErrorMessage ="age should be in between 1 to 120")]
        public int Age { get; set; }
    }
}
