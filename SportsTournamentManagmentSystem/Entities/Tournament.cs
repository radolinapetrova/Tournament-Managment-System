
namespace Entities
{
    public class Tournament
    {
        private int id;
        private string title;
        private Status status;
        private List<Game> games;
        private List<User> users;

        private TournamentInfo info;


        public int Id { get { return id; } }
        public string Title { get { return title; } }
        public Status Status { get { return status; } }
        public TournamentInfo Info { get { return info; } }
        public List<Game> Games { get { return games; } }
        public List<User> Users { get { return users; } }


        public Tournament(int id, string title, Status status)
        {
            this.id = id;
            this.title = title;
            this.status = status;
            this.games = new List<Game>();
        }

        public Tournament(int id, string title, Status status, TournamentInfo info)
        {
            this.id = id;
            this.title = title;
            this.status = status;
            this.info = info;
            this.games = new List<Game>();
        }

        public Tournament(int id, string title, TournamentInfo info)
        {
            this.id = id;
            this.title = title;
            this.info = info;
        }

        public void AssignTournamentInfo(TournamentInfo ti)
        {
            this.info = ti;
        }


        public void AssignGames(List<Game> games)
        {
            this.games.AddRange(games);
        }

        

        public void AssignUsers(List<User> users)
        {
            this.users = users;
        }

        public void RemoveGame(int index)
        {
            this.games.RemoveAt(index);
        }

       
        public override string ToString()
        {
            return $"(ID: {this.id})\t {this.Title}";
        }


        public void SetStatus(Status status)
        {
            this.status = status;
        }
    }
}