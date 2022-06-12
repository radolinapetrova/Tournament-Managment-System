using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        private string email;
        private string password;
        private string salt;

        public string Email
        {
            get { return email; }
            private set
            {
                Regex validEmail = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match checkEmail = validEmail.Match(value);

                if (!checkEmail.Success)
                {
                    throw new Exception("The email you entered is invalid!");
                }
                email = value;
            }
        }
        public string Password { get { return password; } }
        public string Salt { get { return salt; } }

        public Account(string email, string password, string salt)
        {
            this.salt = salt;
            this.Email = email;
            this.password = password;
        }
    }
}
