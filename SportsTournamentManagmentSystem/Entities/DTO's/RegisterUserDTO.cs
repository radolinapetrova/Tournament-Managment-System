using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "This field is required!")]
        public string FName { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        public string LName { get ; set;  }

        
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The input is not valid")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "This field is required!")]
        public string PhoneNumber { get; set; }

        
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

    }
}
