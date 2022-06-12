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
        private User user = null;

        public User User { get { return user; }  }
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
            this.user = user;
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

        public string[] GetPass(string pass, string salt)
        {
            return new string[] { salt, PasswordHasher.Hash(pass + salt) };
        }

        public void LogIn(LogInUserDTO user)
        {
            User usr = manager.Read(user.Email);

            if (usr == null)
            {
                throw new Exception("Your credentials are wrong hehe");
            }

            if (GetPass(user.Password, usr.Account.Salt)[1] != usr.Account.Password)
            {
                throw new Exception("Your credentials are wrong hehe");
            }
            this.user = usr;
        }

        public void GetUser(string email)
        {
            this.user = manager.Read(email);
        }

        public void Update(UpdateUser user)
        {
            string[] pass = GetPass(user.Password, this.user.Account.Salt);

            User updatedUser = new User(this.user.Id, this.user.FisrtName, this.user.FamilyName, user.Phone, new Account(user.Email, pass[1], this.user.Account.Salt));

           manager.Update(updatedUser);
        }
    }
}
