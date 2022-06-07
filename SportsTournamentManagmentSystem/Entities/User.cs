using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int id;
        private string firstName;
        private string familyName;
        private string phone;
        private Account account;

        public string FisrtName { get { return firstName; } }
        public string FamilyName { get { return familyName; } }
        public string Phone { get { return phone; } }
        public Account Account { get { return account; } }
        public int Id { get { return id; } }

        public User(int id, string fname, string lname, string phone, Account account)
        {
            this.id = id;
            this.firstName = fname;
            this.familyName = lname;
            this.phone = phone;
            this.account = account;
        }

        public User(string name, string lname, string phone, Account account)
        {
            this.firstName=name;
            this.familyName=lname;
            this.phone = phone;
            account = account;
        }

        public User(int id)
        {
            this.id = id;
        }


        public override string ToString()
        {
            return this.id.ToString();
        }
    }
}
