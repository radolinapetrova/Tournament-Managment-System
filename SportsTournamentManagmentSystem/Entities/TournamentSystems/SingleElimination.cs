using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SingleElimination : TournamentSystem
    {
        public override string ToString()
        {
            return "Single elimination";
        }

        public override void GetGames(Tournament t)
        {
            if (t.Status != Status.closed && t.Users.Count < t.Info.MinPlayers)
            {
                throw new Exception("A schedule for this tournament can't be genrerated!");
            }

            List<User> users = new List<User>();

            foreach (User user in t.Users)
            {
                users.Add(user);
            }

            if (users.Count % 2 != 0)
            {
                users.Insert(0, new User(-1, "Dummy"));
            }


            int round = (int)Math.Ceiling(Math.Log2(users.Count));


            int waiters = (int)Math.Pow(2, round) - users.Count;
            int preliminaryPlayersCount = users.Count - waiters;

            List<Game> games = new List<Game>();

            

            for (int j = 1; j <= round; j++)
            {

                if (j > 1)
                {
                    int count = users.Count;
                    int game = 0;
                   
                    for (int i = 0; i < count/2; i++)
                    {
                        PlayerContainer pc1 = new PlayerContainer();
                        PlayerContainer pc2 = new PlayerContainer();
                        pc1.User = users[0];
                        pc2.User = users[1];

                        games.Add(new Game(++game, j, pc1, pc2));
                       
                        users.RemoveAt(0);
                        users.RemoveAt(0);
                    }

                    List<Game> gamess = games.FindAll(g => g.RoundNr == j - 1);

                    
                    for (int i = 0; i < gamess.Count; i++)
                    {
                        games.Add(new Game(++game, j, gamess[i].Winner, gamess[++i].Winner));
                    }

                    int? index = games.FindAll(g => g.PlayerTwo.User != null && g.PlayerOne.User != null).FindIndex(x => x.PlayerTwo.User.Id == -1 || x.PlayerOne.User.Id == -1);

                    if (index != -1)
                    {
                        games.RemoveAt((int)index);
                    }

                }
                else
                {
                    int game;
                    if (users[0].Id == -1)
                    {
                        game = 0;
                    }
                    else
                    {
                        game = 1;
                    }
                    
                    for (int i = 0; i < preliminaryPlayersCount/2; i++)
                    {
                        PlayerContainer pc1 = new PlayerContainer();
                        PlayerContainer pc2 = new PlayerContainer();
                        pc1.User = users[0];
                        pc2.User = users[1];
                        games.Add(new Game(game++, j, pc1, pc2));
                        
                        users.RemoveAt(0);
                        users.RemoveAt(0);
                    }
                }
                
            }
            t.AssignGames(games);
            t.SetStatus(Status.scheduled);
        }

    }
}
