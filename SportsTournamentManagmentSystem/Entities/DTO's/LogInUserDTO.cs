using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LogInUserDTO
    {
        private string email;
        [Required]
        public string Email { get { return email; } set { email = value; } }

        private string password;
        [Required]
        public string Password { get { return password; } set { password = value; } }
    }
}
