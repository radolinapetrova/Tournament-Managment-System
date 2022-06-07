using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        private User user;
        private int gamePoints;
        private bool gameStatus;

        public int GamePoints { get { return gamePoints; } internal set { this.gamePoints = value; } }
        public User User { get { return user; } }
        public bool GameStatus { get { return gameStatus; } internal set { this.gameStatus = value; } }


        public Player(User user)
        {
            this.user = user;
        }


        public override string ToString()
        {
            return this.user.FisrtName;
        }
    }
}
