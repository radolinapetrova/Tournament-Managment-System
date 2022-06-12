using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Game
    {
        private int id;
        private int roundNr;

        private PlayerContainer playerOne;
        private PlayerContainer playerTwo;
        private PlayerContainer winner;


        private int playerOneScore;
        private int playerTwoScore;


        public int Id { get { return id; } }
        public int RoundNr { get { return roundNr; } }


        public PlayerContainer PlayerOne { get { return playerOne; } }  
        public PlayerContainer PlayerTwo { get { return playerTwo; } } 
        public PlayerContainer Winner { get { return winner; } }


        public int PlayerOneScore { get { return playerOneScore; } }
        public int PlayerTwoScore { get { return playerTwoScore; } }



        public Game(int id, int round, PlayerContainer p1, PlayerContainer p2)
        {
            this.id = id;
            this.roundNr = round;

            this.playerOne = p1;
            this.playerTwo = p2;
            this.winner = new PlayerContainer();

            if (playerOne.User != null && playerTwo.User != null)
            {
                if (playerOne.User.Id == -1)
                {
                    this.winner.User = playerTwo.User;
                }
            }
        }



        public override string ToString()
        {
            if (playerOne.User != null && playerTwo.User != null)
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: {this.playerOne.User.Id}\tPlayer two: {this.playerTwo.User.Id}";
            }
            else if (playerOne.User != null)
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: {this.playerOne.User.Id}\tPlayer two: Unknow player";
            }
            else if (playerTwo.User != null)
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: Unknown player\tPlayer two: {this.playerTwo.User.Id}";
            }
            else 
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: Unknown player\tPlayer two: Unknown player";
            }
        }

        public void AssignResults(int result1, int result2, Tournament t)
        {
            //Checking if the players have already been assigned a result
            if (t.Status != Status.scheduled || this.PlayerOneScore != 0 || this.playerTwoScore != 0 && this.PlayerOne.User != null || this.PlayerTwo.User != null)
            {
                t.Info.Sport.CheckResult(result1, result2);


                this.playerOneScore = result1;
                this.playerTwoScore = result2;

                if (this.playerOneScore > playerTwoScore)
                {
                    this.winner.User = playerOne.User;
                }
                else
                {
                    this.winner.User = playerTwo.User;
                }

            }
            else
            {
                throw new Exception("You can't save the result!");
            }
        }


    }
}
