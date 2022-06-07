using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        private string email;
        private string password;
        private string salt;

        public string Email { get { return email; } }
        public string Password { get { return password; } }
        public string Salt { get { return salt; } }

        public Account(string email, string password, string salt)
        {
            this.salt = salt;
            this.email = email;
            this.password = password;
        }
    }
}
