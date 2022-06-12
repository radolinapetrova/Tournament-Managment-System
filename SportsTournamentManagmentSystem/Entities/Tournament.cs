
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
            this.users = new List<User>();
        }

        public Tournament(int id, string title, Status status, TournamentInfo info)
        {
            this.id = id;
            this.title = title;
            if (status == Status.closed && info.StartDate.CompareTo(DateTime.Today.AddDays(7)) > 0)
            {
                throw new Exception("You can't close the tournament now!");
            }
            else if (status == Status.open && info.StartDate.CompareTo(DateTime.Today.AddDays(14)) < 0)
            {
                throw new Exception("The start date must be at least two weeks from now!");
            }
            else if (status == Status.scheduled && info.StartDate.CompareTo(DateTime.Today.AddDays(7)) > 0)
            {
                throw new Exception("Invalid data!");
            }
            else if (status == Status.finished && info.StartDate.CompareTo(DateTime.Today) > 0)
            {
                throw new Exception("Invalid data!");
            }
            this.status = status;
            this.info = info;
            this.games = new List<Game>();
            this.users = new List<User>();
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
            this.users.AddRange(users);
        }


        public override string ToString()
        {
            return $"(ID: {this.id})\t {this.Title}";
        }


        public void SetStatus(Status status)
        {
            if (this.status == Status.canceled)
            {
                throw new Exception("The tournament has been canceled!");
            }
            //Already finished tournament's status can't be changed
            else if (this.status == Status.finished)
            {
                throw new Exception("You can't change the status of this tournament!");
            }
            else if (this.status == Status.open)
            {
                if (status != Status.closed && status != Status.canceled)
                {
                    throw new Exception("You can only cancel or close the tournament for registration!");
                }
                //if the new status of the tournament is closed for registering but the start date of it is more than a week from now it is not possible to close it
                if (status == Status.closed && DateTime.Today.AddDays(7).CompareTo(this.info.StartDate) < 0)
                {
                    throw new Exception("You can't close the tournament for registration!");
                }
            }
            else if (this.status == Status.closed)
            {
                if (status != Status.scheduled && status != Status.canceled)
                {
                    throw new Exception("You can only cancel or generate the schedule for this tournament!");
                }
                if (status == Status.scheduled && this.Games.Count == 0)
                {
                    throw new Exception("A schedule for the games shoul be generated before changing the status of the tournament!");
                }
            }
            else 
            {
                if (status != Status.finished && status != Status.canceled)
                {
                    throw new Exception("You can only set the status of this tournament to canceled or finished!");
                }
                //The tournament can only be finished if all the games have results
                if (status == Status.finished && this.Games.Any(x => x.PlayerTwoScore == 0 && x.PlayerOneScore == 0))
                {
                    throw new Exception("The tournament can be finished after every game has been finished!");
                }
            }
            this.status = status;
        }
    }
}