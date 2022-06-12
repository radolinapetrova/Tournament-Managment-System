using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogicLayer
{
    public class GameManager
    {
        IGame manager;

        public GameManager(IGame manager)
        {
            this.manager = manager;
        }


        public void AddGames(Tournament t)
        {
            manager.Add(t);
        }


        public void SaveResults(Tournament t, Game game, int result1, int result2)
        {
            if (t.Status != Status.scheduled)
            {
                throw new Exception("You can't enter any game results!");
            }
            if (game.PlayerTwoScore != 0 || game.PlayerOneScore != 0)
            {
                throw new Exception("You can't edit the results of the players!");
            }
            game.AssignResults(result1, result2, t);
            if (!t.Games.Any(x => x.PlayerTwoScore == 0 && x.PlayerOneScore == 0))
            {
                t.SetStatus(Status.finished);
            }
            manager.Result(t, game);

        }

       
    }
}
