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
        private Player playerOne;
        private Player playerTwo;
        private Player winner;

        public int Id { get { return id; } }
        public int RoundNr { get { return roundNr; } }
        public Player? PlayerOne { get { return playerOne; } }
        public Player? PlayerTwo { get { return playerTwo; } }
        public Player? Winner { get { return winner; } }



        public Game(int id, int round, Player p1, Player p2)
        {
            this.id = id;
            this.roundNr = round;
            this.playerOne = p1;
            this.playerTwo = p2;
            //playerOne.GamePoints = 0;
            //playerTwo.GamePoints = 0;

            if (playerOne != null && PlayerTwo != null)
            {
                if (playerOne.User.Id == 0)
                {
                    this.winner = playerTwo;
                }
                else if (playerTwo.User.id == 0)
                {
                    this.winner = playerOne;
                }
            }
        }



        public override string ToString()
        {
            if (playerOne != null && playerTwo != null)
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: {this.playerOne.User.Id}\tPlayer two: {this.playerTwo.User.Id}";
            }
            else if (playerOne != null)
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: {this.playerOne.User.Id}\tPlayer two: Unknow player";
            }
            else 
            {
                return $"Round nr: {this.roundNr}\tGame nr: {this.id}\tPlayer one: Unknown player\tPlayer two: Unknown player";
            }
        }

        public void AssignResults(int result1, int result2, Tournament t)
        {
            //Checking if the players have already been assigned a result
            if (t.Status != Status.open && this.PlayerOne.GamePoints == 0 && this.PlayerTwo.GamePoints == 0)
            {
                t.Info.Sport.CheckResult(result1, result2);


                this.PlayerOne.GamePoints = result1;
                this.PlayerTwo.GamePoints = result2;


                if (result1 > result2)
                {
                    this.PlayerOne.GameStatus = true;
                    this.PlayerTwo.GameStatus = false;
                }
                else
                {
                    this.PlayerOne.GameStatus = false;
                    this.PlayerTwo.GameStatus = true;
                }
            }
            else
            {
                throw new Exception("You can't save the result!");
            }
        }


    }
}
