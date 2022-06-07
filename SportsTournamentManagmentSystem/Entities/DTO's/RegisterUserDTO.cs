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
        private string fname;
        [Required(ErrorMessage = "Type something bitch")]
        public string FName { get { return fname; } set { fname = value; } }

        private string lname;
        [Required(ErrorMessage = "Type something bitch")]
        public string LName { get { return lname; } set { lname = value; } }

        private string email;
        [Required(ErrorMessage = "Type something bitch")]
        public string Email { get { return email; } set { email = value; } }

        private string phoneNumber;
        [Required(ErrorMessage = "Type something bitch")]
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        private string password;
        [Required(ErrorMessage = "Type something bitch")]
        public String Password { get { return password; } set { password = value; } }

    }
}
