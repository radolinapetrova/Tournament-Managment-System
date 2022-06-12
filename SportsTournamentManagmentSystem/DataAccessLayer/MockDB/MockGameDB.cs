using Entities;


namespace DataAccessLayer
{
    public class MockGameDB : IGame
    {
        public void Add(Tournament t) { }

        public void Result(Tournament t, Game game) { }
    }
}
