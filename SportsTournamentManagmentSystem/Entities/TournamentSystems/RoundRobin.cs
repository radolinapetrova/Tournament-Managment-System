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

            int n = t.Users.Count;
            List<Game> games = new List<Game>();

            for (int i = 0; i < GetRounds(n); i++)
            {
                for (int j = 0; j < GetGames(n)/GetRounds(n); j++)
                {
                    if (t.Users.Count % 2 != 0 && i + 1 == GetRounds(n))
                    {
                        games.Add(new Game(j + 1, i + 1, new Player(t.Users[j + 1]), new Player(t.Users[t.Users.Count - (j + 1)])));
                    }
                    else
                    {
                        games.Add(new Game(j + 1, i + 1, new Player(t.Users[j]), new Player(t.Users[t.Users.Count - (j + 1)])));
                    }
                   
                }
                t.Users.Insert(1, t.Users.Last());
                t.Users.RemoveAt(t.Users.Count - 1);    
            }
            t.AssignGames(games);

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
