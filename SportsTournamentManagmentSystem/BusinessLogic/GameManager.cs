using System;
using System.Collections.Generic;
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
            if (t.Status != Status.closed)
            {
                throw new Exception("A schedule can't be generated for the selected tournament!");
            }
            manager.Add(t);
            t.SetStatus(Status.scheduled);
        }


        public void SaveResults(Tournament t, Game game, int result1, int result2)
        {
            if (game.PlayerTwo.GamePoints != 0 || game.PlayerOne.GamePoints != 0)
            {
                throw new Exception("You can't edit the results of the players!");
            }
            game.AssignResults(result1, result2, t);
            manager.Result(t, game);

        }
    }
}
