using Entities;

namespace DataAccessLayer
{
    public class MockUserDB : IAutoIncrement, IUser
    {
        public int GetId()
        {
            return -1;
        }

        public void Add(User user) { }

        public void Update(User user) { }

        public User Read(string email) 
        {
            return null;    
        }
    }
}
