using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoundRobin : TournamentSystem
    {

        public override void GetGames(Tournament t)
        {

            if (t.Status != Status.closed || t.Users.Count < t.Info.MinPlayers)
            {
                throw new Exception("A schedule for this tournament can't be genrerated!");
            }

            int n = t.Users.Count;
            List<Game> games = new List<Game>();


            

            for (int i = 0; i < GetRounds(n); i++)
            {
                for (int j = 0; j < GetGames(n)/GetRounds(n); j++)
                {
                    if (t.Users.Count % 2 != 0 && i + 1 == GetRounds(n))
                    {
                        PlayerContainer pc1 = new PlayerContainer();
                        PlayerContainer pc2 = new PlayerContainer();
                        pc1.User = t.Users[j + 1];
                        pc2.User = t.Users[t.Users.Count - (j + 1)];

                        games.Add(new Game(j + 1, i + 1, pc1, pc2));
                    }
                    else
                    {
                        PlayerContainer pc1 = new PlayerContainer();
                        PlayerContainer pc2 = new PlayerContainer();
                        pc1.User = t.Users[j];
                        pc2.User = t.Users[t.Users.Count - (j + 1)];
                        games.Add(new Game(j + 1, i + 1, pc1, pc2));
                    }
                   
                }
                t.Users.Insert(1, t.Users.Last());
                t.Users.RemoveAt(t.Users.Count - 1);    
            }
            t.AssignGames(games);
            t.SetStatus(Status.scheduled);

        }

        private int GetRounds(int n)
        {
            if (n % 2 == 0)
            {
                return n - 1;
            }
            else
            {
                return n;
            }
        }

        private int GetGames(int n)
        {
            return n * (n - 1) / 2;
        }

        public override string ToString()
        {
            return "Round-robin";
        }
    }
}
