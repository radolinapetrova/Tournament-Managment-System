using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogicLayer;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class GameTesting
    {
        TournamentManager tm = new TournamentManager(new MockTournamentDB(), new MockTournamentDB(), new MockTournamentDB());
        GameManager gm = new GameManager(new MockGameDB());

        [TestMethod]
        public void TestGetRoundRobinEvenParticipantsGames()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 4, 30, "Haskovo", new RoundRobin()));

            List<User> users = new List<User>();
            users.Add(new User(1, "Mima"));
            users.Add(new User(2, "Peca"));
            users.Add(new User(3, "Misha"));
            users.Add(new User(4, "Niki"));

            foreach (var item in users)
            {
                t.Users.Add(item);
            }


            t.Info.System.GetGames(t);

            List<Game> games = new List<Game>();

            PlayerContainer pc1 = new PlayerContainer();
            PlayerContainer pc2 = new PlayerContainer();


            pc1.User = users[0];
            pc2.User = users[3];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[0].PlayerOne.User.Id, games[0].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[0].PlayerTwo.User.Id, games[0].PlayerTwo.User.Id);

            pc1.User = users[1];
            pc2.User = users[2];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[1].PlayerOne.User.Id, games[1].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[1].PlayerTwo.User.Id, games[1].PlayerTwo.User.Id);

            pc1.User = users[0];
            pc2.User = users[2];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[2].PlayerOne.User.Id, games[2].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[2].PlayerTwo.User.Id, games[2].PlayerTwo.User.Id);

            pc1.User = users[3];
            pc2.User = users[1];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[3].PlayerOne.User.Id, games[3].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[3].PlayerTwo.User.Id, games[3].PlayerTwo.User.Id);

            pc1.User = users[0];
            pc2.User = users[1];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[4].PlayerOne.User.Id, games[4].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[4].PlayerTwo.User.Id, games[4].PlayerTwo.User.Id);

            pc1.User = users[2];
            pc2.User = users[3];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[5].PlayerOne.User.Id, games[5].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[5].PlayerTwo.User.Id, games[5].PlayerTwo.User.Id);


        }

        [TestMethod]
        public void TestGetRoundRobinOddParticipantsGames()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin()));

            List<User> users = new List<User>();

            users.Add(new User(1, "Mima"));
            users.Add(new User(2, "Peca"));
            users.Add(new User(3, "Misha"));

            foreach (var item in users)
            {
                t.Users.Add(item);
            }


            t.Info.System.GetGames(t);

            List<Game> games = new List<Game>();

            PlayerContainer pc1 = new PlayerContainer();
            PlayerContainer pc2 = new PlayerContainer();


            pc1.User = users[0];
            pc2.User = users[2];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[0].PlayerOne.User.Id, games[0].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[0].PlayerTwo.User.Id, games[0].PlayerTwo.User.Id);

            pc1.User = users[0];
            pc2.User = users[1];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[1].PlayerOne.User.Id, games[1].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[1].PlayerTwo.User.Id, games[1].PlayerTwo.User.Id);

            pc1.User = users[1];
            pc2.User = users[2];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[2].PlayerOne.User.Id, games[2].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[2].PlayerTwo.User.Id, games[2].PlayerTwo.User.Id);
        }

        [TestMethod]
        public void TestGetSingleEliminationOddParticipantsGames()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(8).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new SingleElimination()));

            List<User> users = new List<User>();
            users.Add(new User(1, "Mima"));
            users.Add(new User(2, "Peca"));
            users.Add(new User(3, "Misha"));

            foreach (var item in users)
            {
                t.Users.Add(item);
            }

            t.Info.System.GetGames(t);

            List<Game> games = new List<Game>();

            PlayerContainer pc1 = new PlayerContainer();
            PlayerContainer pc2 = new PlayerContainer();


            pc1.User = users[1];
            pc2.User = users[2];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[0].PlayerOne.User.Id, games[0].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[0].PlayerTwo.User.Id, games[0].PlayerTwo.User.Id);

            
            Assert.AreEqual(t.Games[1].PlayerOne.User.Id, 1);
            Assert.AreEqual(t.Games[1].PlayerTwo.User, null);
        }

        [TestMethod]
        public void TestGetSingleEliminationEvenParticipantsGames()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Haskovo", new SingleElimination()));

            List<User> users = new List<User>();
            users.Add(new User(1, "Mima"));
            users.Add(new User(2, "Peca"));
            users.Add(new User(3, "Misha"));
            users.Add(new User(4, "Niki"));
            users.Add(new User(5, "Niki"));
            users.Add(new User(6, "Niki"));


            foreach (var item in users)
            {
                t.Users.Add(item);
            }

            t.Info.System.GetGames(t);

            List<Game> games = new List<Game>();

            PlayerContainer pc1 = new PlayerContainer();
            PlayerContainer pc2 = new PlayerContainer();


            pc1.User = users[0];
            pc2.User = users[1];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[0].PlayerOne.User.Id, games[0].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[0].PlayerTwo.User.Id, games[0].PlayerTwo.User.Id);
            Assert.AreEqual(t.Games[0].RoundNr, 1);
            Assert.AreEqual(t.Games[0].Id, 1);

            pc1.User = users[2];
            pc2.User = users[3];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[1].PlayerOne.User.Id, games[1].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[1].PlayerTwo.User.Id, games[1].PlayerTwo.User.Id);
            Assert.AreEqual(t.Games[1].RoundNr, 1);
            Assert.AreEqual(t.Games[1].Id, 2);

            pc1.User = users[4];
            pc2.User = users[5];
            games.Add(new Game(1, 1, pc1, pc2));
            Assert.AreEqual(t.Games[2].PlayerOne.User.Id, games[2].PlayerOne.User.Id);
            Assert.AreEqual(t.Games[2].PlayerTwo.User.Id, games[2].PlayerTwo.User.Id);
            Assert.AreEqual(t.Games[2].RoundNr, 2);
            Assert.AreEqual(t.Games[2].Id, 1);

            Assert.AreEqual(t.Games[3].PlayerOne.User, null);
            Assert.AreEqual(t.Games[3].PlayerTwo.User, null);
            Assert.AreEqual(t.Games[3].RoundNr, 2);
            Assert.AreEqual(t.Games[3].Id, 2);

            Assert.AreEqual(t.Games[4].PlayerOne.User, null);
            Assert.AreEqual(t.Games[4].PlayerTwo.User, null);
            Assert.AreEqual(t.Games[4].RoundNr, 3);
            Assert.AreEqual(t.Games[4].Id, 1);
        }

        private List<User> GetDummyUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Sisa"));
            users.Add(new User(2, "Pepa"));
            users.Add(new User(3, "Goshka"));
            users.Add(new User(4, "Gera"));

            return users;   
        }

        [TestMethod]
        public void TestGetGamesForInvalidTournament()
        {
            //Creating a tournament with invalid data for generating a schedule
            Tournament tr = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));

            tr.AssignUsers(GetDummyUsers());

            Exception ex = Assert.ThrowsException<Exception>(() => tr.Info.System.GetGames(tr));
            Assert.AreEqual("A schedule for this tournament can't be genrerated!", ex.Message);

            //Creating a tournament with registered number of participants lower than the minimum
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(5).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 10, 30, "Haskovo", new RoundRobin()));

            foreach (var item in GetDummyUsers())
            {
                t.Users.Add(item);
            }


            Exception e = Assert.ThrowsException<Exception>(() => t.Info.System.GetGames(t));
            Assert.AreEqual("A schedule for this tournament can't be genrerated!", e.Message);

        }


        [TestMethod]
        public void TestAddGamesForValidTournament()
        {
            //Creating the schedule for a tournament closed for registering and with number ofplayers over the minimum
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(11).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin()));

            foreach (var item in GetDummyUsers())
            {
                t.Users.Add(item);
            }

            t.Info.System.GetGames(t);
            gm.AddGames(t);

            Assert.AreEqual(Status.scheduled, t.Status);
        }

        [TestMethod]
        public void TestSaveResults()
        {
            //Tournament with valid information for saving game results
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin()));

            List<User> users = new List<User>();
            users.Add(new User(1, "Stefka"));
            users.Add(new User(2, "Gaba"));
            users.Add(new User(3, "Krisa"));
            users.Add(new User(4, "Gera"));

            foreach (var item in users)
            {
                t.Users.Add(item);
            }

            t.Info.System.GetGames(t);

            //Saving valid results
            gm.SaveResults(t, t.Games[0], 21, 12);
            Assert.AreEqual(21, t.Games[0].PlayerOneScore);
            Assert.AreEqual(12, t.Games[0].PlayerTwoScore);

            //Saving valid results
            gm.SaveResults(t, t.Games[1], 21, 23);
            Assert.AreEqual(21, t.Games[1].PlayerOneScore);
            Assert.AreEqual(23, t.Games[1].PlayerTwoScore);

            //Saving valid results
            gm.SaveResults(t, t.Games[2], 29, 30);
            Assert.AreEqual(29, t.Games[2].PlayerOneScore);
            Assert.AreEqual(30, t.Games[2].PlayerTwoScore);

            //Saving valid results
            gm.SaveResults(t, t.Games[3], 28, 30);
            Assert.AreEqual(28, t.Games[3].PlayerOneScore);
            Assert.AreEqual(30, t.Games[3].PlayerTwoScore);

            //Saving valid results
            gm.SaveResults(t, t.Games[4], 21, 0);
            Assert.AreEqual(21, t.Games[4].PlayerOneScore);
            Assert.AreEqual(0, t.Games[4].PlayerTwoScore);

            //Saving valid results for players that already have results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[4], 30, 28));
            Assert.AreNotEqual(30, t.Games[4].PlayerOneScore);
            Assert.AreNotEqual(28, t.Games[4].PlayerTwoScore);


            //Saving invalid results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[5], 31, -3));
            Assert.AreNotEqual(31, t.Games[5].PlayerOneScore);
            Assert.AreNotEqual(-3, t.Games[5].PlayerTwoScore);

            //Saving invalid results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[5], 27, 24));
            Assert.AreNotEqual(27, t.Games[5].PlayerOneScore);
            Assert.AreNotEqual(24, t.Games[5].PlayerTwoScore);

            //Saving invalid results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[5], 13, 24));
            Assert.AreNotEqual(13, t.Games[5].PlayerOneScore);
            Assert.AreNotEqual(24, t.Games[5].PlayerTwoScore);

            //Saving invalid results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[5], 21, 21));
            Assert.AreNotEqual(21, t.Games[5].PlayerOneScore);
            Assert.AreNotEqual(21, t.Games[5].PlayerTwoScore);

            //Saving invalid results
            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[5], 0, 0));

        }


        [TestMethod]
        public void TestSaveResultForInvalidGame()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(11).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new SingleElimination()));

            List<User> users = new List<User>();
            users.Add(new User(1, "Stefka"));
            users.Add(new User(2, "Gaba"));
            users.Add(new User(3, "Krisa"));
            users.Add(new User(4, "Gera"));
            users.Add(new User(5, "Gera"));

            foreach (var item in users)
            {
                t.Users.Add(item);
            }

            t.Info.System.GetGames(t);

            Assert.ThrowsException<Exception>(() => gm.SaveResults(t, t.Games[3], 30, 28));
            Assert.AreNotEqual(30, t.Games[3].PlayerOneScore);
            Assert.AreNotEqual(28, t.Games[3].PlayerTwoScore);
        }

    }
}