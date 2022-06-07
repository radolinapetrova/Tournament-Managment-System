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
            List<User> users = new List<User>();

            foreach (User user in t.Users)
            {
                users.Add(user);
            }

            if (users.Count % 2 != 0)
            {
                //users.Add(new User(0));
                users.Insert(0, new User(0));
            }


            int round = (int)Math.Ceiling(Math.Log2(users.Count));


            int waiters = (int)Math.Pow(2, round) - users.Count;
            int preliminaryPlayersCount = users.Count - waiters;
            

            for (int j = 1; j <= round; j++)
            {
                List<Game> games = new List<Game>();

                if (j > 1)
                {
                    int count = users.Count;
                    //for (int i = 0; i < count / 2; i++)
                    for (int i = 0; i < count/2; i++)
                    {
                        //games.Add(new Game(1 + i, j, new Player(users.First()), new Player(users.Last())));
                        games.Add(new Game(games.Count + 1, j, new Player(users[0]), new Player(users[1])));
                        //users.Remove(users.First());
                        //users.Remove(users.Last());
                        users.RemoveAt(0);
                        users.RemoveAt(0);
                    }

                    List<Game> gamess = t.Games.FindAll(g => g.RoundNr == j - 1);

                    //for (int i = 0; i < gamess.Count / 2; i++)
                    for (int i = 0; i < gamess.Count; i++)
                    {
                        games.Add(new Game(games.Count + 1, j, gamess[i].Winner, gamess[++i].Winner));
                    }

                    t.AssignGames(games);

                    int? index = t.Games.FindAll(g => g.PlayerTwo != null && g.PlayerOne != null).FindIndex(x => x.PlayerTwo.User.Id == 0 || x.PlayerOne.User.Id == 0);

                    if (index != -1)
                    {
                        t.RemoveGame((int)index);
                    }

                  


                }
                else
                {
                    //for (int i = 0; i < preliminaryPlayersCount / 2; i++)
                    for (int i = 0; i < preliminaryPlayersCount/2; i++)
                    {
                        //games.Add(new Game(1 + i, j, new Player(users.First()), new Player(users.Last())));
                        games.Add(new Game(games.Count + 1, j, new Player(users[0]), new Player(users[1])));
                        //users.Remove(users.First());
                        //users.Remove(users.Last());
                        users.RemoveAt(0);
                        users.RemoveAt(0);
                    }

                    t.AssignGames(games);
                }

            }



        }

    }
}
