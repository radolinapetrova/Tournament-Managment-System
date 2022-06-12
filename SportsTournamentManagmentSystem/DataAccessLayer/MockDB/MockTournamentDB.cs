using Entities;
namespace DataAccessLayer
{
    public class MockTournamentDB : ICUDTournament, IAutoIncrement, ITournamentReader, ITournamentManager
    {
        public void Read(List<Tournament> t, int limit, int offset) { }

        public void Read(List<Tournament> t) { }

        public void Add(Tournament t) { }

        public void AddUser(Tournament t, User u) { }

        public void Update(Tournament t) { }

        public void Cancel(int id) { }

        public void Delete(int id) { }

        public int GetId() 
        {
            return 0;
        }

        public void GetInfo(Tournament t) { }
    }
}
