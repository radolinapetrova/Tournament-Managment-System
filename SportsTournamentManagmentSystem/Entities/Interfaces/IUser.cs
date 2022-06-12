using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUser
    {
        public void Add(User user);
        public User Read(string identifier);

        public void Update(User user);
    }
}
