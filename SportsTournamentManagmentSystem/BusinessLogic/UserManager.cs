using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogicLayer
{
    public class UserManager
    {
        private static List<User> users = new List<User>();
        IUser manager;
        IAutoIncrement autoIncr;

        public UserManager(IUser manager, IAutoIncrement getID)
        {
            this.manager = manager;
            this.autoIncr = getID;
        }

        public void CreateAccount(User user)
        {
            manager.Add(user);
            users.Add(user);
        }

        public int GetId()
        {
            return autoIncr.GetId();
        }

        public string[] GetPass(string password)
        {
            string salt = Guid.NewGuid().ToString();

            string[] pass = new string[] { salt, PasswordHasher.Hash(password + salt) };

            return pass;
        }

        public User LogIn(LogInUserDTO user)
        {
            User usr = manager.Read(user.Email, user.Password);

            if (usr == null)
            {
                throw new Exception("Your credentials are wrong hehe");
            }
            return usr;
        }
    }
}
