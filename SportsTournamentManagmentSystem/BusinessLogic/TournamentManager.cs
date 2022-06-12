using Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BusinessLogic
{
    public class TournamentManager
    {

        ICUDTournament manager;
        IAutoIncrement autoIncr;
        ITournamentManager mngr;
        ITournamentReader reader;

        public TournamentManager(ICUDTournament manager, IAutoIncrement autoIncr, ITournamentReader reader)
        {
            this.manager = manager;
            this.autoIncr = autoIncr;
            this.reader = reader;
            reader.Read(tournaments);
        }

        public TournamentManager(ITournamentReader reader, ITournamentManager mngr)
        {
            this.manager = manager;
            this.mngr = mngr;
            this.reader = reader;
            reader.Read(tournaments);
        }

        List<Tournament> tournaments = new List<Tournament>();

        public IList<Tournament> Tournaments { get { return tournaments.AsReadOnly(); } }

        public void Add(Tournament t)
        {
            if (t.Status == Status.open)
            {
                manager.Add(t);
                tournaments.Add(t);
            }
            else
            {
                throw new Exception("You can't create a torunament with status, different from 'open'!");
            }
        }

        public void Update(Tournament oldT, Tournament newT)
        {
            Tournament t = null;

            if (newT.Status == Status.canceled || newT.Status == Status.finished)
            {
                throw new Exception("You can't update the information of finished or canceled tournaments!");
            }
            else if (newT.Status == Status.open)
            {
                if (newT.Info.StartDate.CompareTo(DateTime.Now.AddDays(10)) < 0 || newT.Info.StartDate.CompareTo(newT.Info.EndDate) > 0)
                {
                    throw new Exception("Invalid date!");
                }

                if (oldT.Users.Count > newT.Info.MaxPlayers)
                {
                    throw new Exception("The maximum number of players you have chosen is already surpassed!");
                }
                //if the tournament is open for registration title, description, start date, end date and location can be changed
                t = new Tournament(oldT.Id, newT.Title, newT.Status, new TournamentInfo(oldT.Info.Sport, newT.Info.Description, newT.Info.StartDate.ToString("yyyy-MM-dd"), newT.Info.EndDate.ToString("yyyy-MM-dd"), newT.Info.MinPlayers, newT.Info.MaxPlayers, newT.Info.Location, oldT.Info.System));
            }
            else if (newT.Status == Status.closed)
            {
                if (newT.Info.StartDate.CompareTo(DateTime.Today.AddDays(7)) > 0 || newT.Info.StartDate.CompareTo(newT.Info.EndDate) > 0)
                {
                    throw new Exception("Invalid date!");
                }
                //if the tournament is closed for registration only the start/end date and location can be changed
                t = new Tournament(oldT.Id, oldT.Title, newT.Status, new TournamentInfo(oldT.Info.Sport, oldT.Info.Description, newT.Info.StartDate.ToString("yyyy-MM-dd"), newT.Info.EndDate.ToString("yyyy-MM-dd"), oldT.Info.MinPlayers, oldT.Info.MaxPlayers, newT.Info.Location, oldT.Info.System));
            }
            else if (newT.Status == Status.scheduled)
            {
                //if the tournament is scheduled only the location can be changed
                t = new Tournament(oldT.Id, oldT.Title, newT.Status, new TournamentInfo(oldT.Info.Sport, oldT.Info.Description, oldT.Info.StartDate.ToString("yyyy-MM-dd"), oldT.Info.EndDate.ToString("yyyy-MM-dd"), oldT.Info.MinPlayers, oldT.Info.MaxPlayers, newT.Info.Location, oldT.Info.System));
            }
            manager.Update(t);
            int i = tournaments.FindIndex(x => x.Id == t.Id);
            tournaments[i] = t;
        }

        public void Cancel(Tournament t)
        {
            if (t.Status == Status.canceled || t.Status == Status.finished)
            {
                throw new Exception("The tournament can't be canceled!");
            }
            t.SetStatus(Status.canceled);
            manager.Cancel(t.Id);
        }

        public void Delete(Tournament t)
        {
            if (t.Status == Status.open && t.Users.Count < 1)
            {
                tournaments.Remove(t);
                manager.Delete(t.Id);
            }
            else
            {
                throw new Exception("The tournament can't be deleted!");
            }

        }

        public int GetId()
        {
            return autoIncr.GetId();
        }


        public void GetTournamentInfo(Tournament t)
        {
            //Checking if the tournament has already been loaded from the db
            if (t.Info == null)
            {
                reader.GetInfo(t);
            }
        }


        //FILTERING
        public Tournament GetTournamentByID(int id)
        {
            return tournaments.Find(x => x.Id == id);
        }

        public List<Tournament> GetTournamentsByTitle(string title)
        {
            return tournaments.FindAll(x => x.Title.ToLower().Contains(title.ToLower()));
        }




        public void AddUser(Tournament t, User u)
        {
            if (t.Status != Status.open)
            {
                throw new Exception("You can't registered for this tournament");
            }
            if (t.Users.Count == t.Info.MaxPlayers)
            {
                throw new Exception("The maximum number of players has been reached!");
            }
            if (t.Users.Any(usr => usr.Id == u.Id))
            {
                throw new Exception("You have already registered for this tournament");
            }

            mngr.AddUser(t, u);
            t.Users.Add(u);
        }

        public void CloseTournament(Tournament t)
        {
            //The checks for the status are made in the set status method
            if (t.Users.Count < t.Info.MinPlayers)
            {
                t.SetStatus(Status.canceled);
            }
            else
            {
                t.SetStatus(Status.closed);
            }
            manager.Update(t);
        }



        //Retrieving the points from all the games the user has won
        private int GetWins(int id, Tournament t)
        {
            List<Game> winningGames = t.Games.FindAll(g => g.Winner.User.Id == id);

            int score = 0;

            for (int i = 0; i < winningGames.Count; i++)
            {
                score += Math.Max(winningGames[i].PlayerOneScore, winningGames[i].PlayerTwoScore);
            }

            return score;
        }

        //Retrieving all the points of a player from the all the games in the tournament
        private int GetAllPoints(int id, Tournament t)
        {
            Game g = t.Games.Find(x => x.PlayerOne.User.Id == id || x.PlayerTwo.User.Id == id);

            if (g.PlayerOne.User.Id == id)
            {
                return g.PlayerOneScore;
            }
            return g.PlayerTwoScore;
        }


        public Dictionary<int, int> GetRanking(Tournament t)
        {
            List<User> winners = new List<User>();

            //Making a list with the id of the winner of each game in a
            foreach (var g in t.Games)
            {
                winners.Add(g.Winner.User);
            }

            //Making a list with the id of the participants that didn't win any game
            List<User> loosers = new List<User>();


            foreach (var g in t.Games)
            {
                PlayerContainer pc;

                if (g.PlayerOne.User.Id == g.Winner.User.Id)
                {
                    pc = g.PlayerTwo;
                }
                else
                {
                    pc = g.PlayerOne;
                }

                if (!loosers.Any(x => x.Id == pc.User.Id))
                {
                    if (g.PlayerOne.User.Id == g.Winner.User.Id && !winners.Any(x => x.Id == g.PlayerTwo.User.Id))
                    {
                        loosers.Add(g.PlayerTwo.User);
                    }
                    else if (!winners.Any(x => x.Id == pc.User.Id))
                    {
                        loosers.Add(g.PlayerOne.User);
                    }
                }
            }



            var ranking = winners.GroupBy(i => i.Id).ToDictionary(x => x.Key, x => x.Count());


            DataTable dt = new DataTable();

            dt.Columns.Add("user_name");
            dt.Columns.Add("games_won");
            dt.Columns.Add("won_points");

            DataRow dr;

            for (int i = 0; i < ranking.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = ranking.ElementAt(i).Key;
                dr[1] = ranking.ElementAt(i).Value;
                dr[2] = GetWins(ranking.ElementAt(i).Key, t);

                dt.Rows.Add(dr);
            }

            for (int i = 0; i < loosers.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = loosers[i].Id;
                dr[1] = 0;
                dr[2] = GetAllPoints(loosers[i].Id, t);

                dt.Rows.Add(dr);
            }

            var rows = dt.Rows.Cast<DataRow>();
            var result = rows
                .OrderBy(i => i["games_won"])
                .ThenBy(i => i["won_points"]);

            Dictionary<int, int> finalRank = new Dictionary<int, int>();


            foreach (var item in result)
            {
                finalRank.Add(Convert.ToInt32(item[0]), Convert.ToInt32(item[1]));
            }

            return finalRank;
        }
    }
}