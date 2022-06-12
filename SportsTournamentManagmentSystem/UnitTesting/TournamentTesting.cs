using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class TournamentTesting
    {
        TournamentManager tm = new TournamentManager(new MockTournamentDB(), new MockTournamentDB(), new MockTournamentDB());

        [TestMethod]
        public void TestCreateTournamentWithValidInformation()
        {
            //Tournament with valid data
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));

            tm.Add(t);

            Assert.AreEqual(1, tm.Tournaments.Count);
            Assert.AreEqual(tm.Tournaments[0], t);
        }

        [TestMethod]
        public void TestCreateTournamentWithInvalidDate() 
        {
            //Invalid start and end date
            Exception ex = Assert.ThrowsException<Exception>(() => tm.Add(new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(4), DateTime.Today.AddDays(3), 1, 0, "Haskovo", new RoundRobin()))));
            Assert.AreEqual("The start date of the tournament must be at least two weeks from now!", ex.Message);
            Assert.AreEqual(0, tm.Tournaments.Count);

            //Invalid end date
            Exception exc = Assert.ThrowsException<Exception>(() => tm.Add(new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(3), 1, 0, "Haskovo", new RoundRobin()))));
            Assert.AreEqual("The end date of the tournament must be later than the start date!", exc.Message);
            Assert.AreEqual(0, tm.Tournaments.Count);
        }

        [TestMethod]
        public void TestCreateTournamentWithInvalidNumberOfPlayers()
        {
            //Invalid number of minimum players
            Exception ex = Assert.ThrowsException<Exception>(() => tm.Add(new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 1, 0, "Haskovo", new RoundRobin()))));
            Assert.AreEqual("The minimum number of players must be at least 2!", ex.Message);
            Assert.AreEqual(0, tm.Tournaments.Count);

            //Invalid number of minimum players
            Exception e = Assert.ThrowsException<Exception>(() => tm.Add(new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 0, "Haskovo", new RoundRobin()))));
            Assert.AreEqual("The maximum number of players must be at least 2 and bigger than or equal to the minimum number!", e.Message);
            Assert.AreEqual(0, tm.Tournaments.Count);
        }

        [TestMethod]
        public void TestCreateTournamentWithInvalidStatus()
        {
            //Creating a tournament with invalid status
            Assert.ThrowsException<Exception>(() => tm.Add(new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()))));
            Assert.AreEqual(0, tm.Tournaments.Count);
        }

        public List<User> GetDummyUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User(1, "Sisa"));
            users.Add(new User(2, "Sisa"));
            users.Add(new User(3, "Sisa"));
            users.Add(new User(4, "Sisa"));
            users.Add(new User(6, "Sisa"));
            users.Add(new User(7, "Sisa"));
            users.Add(new User(8, "Sisa"));
            users.Add(new User(9, "Sisa"));
            users.Add(new User(10, "Sisa"));

            return users;
        }

        [TestMethod]
        public void TestUpdateOpenTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            Tournament tr;

            //Creating a new tournament with valid information
            tr = new Tournament(1, "Badminton finals", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Eindhoven", new RoundRobin()));

            //Successful update
            tm.Update(t, tr);
            Assert.AreNotEqual(tm.Tournaments[0].Title, t.Title);
            Assert.AreEqual(tm.Tournaments[0].Title, tr.Title);


            Assert.ThrowsException<Exception>(() => tm.Update(t, new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()))));


            //Updating the tournament with maximum of users less than the current number of users
            tr = new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finalss", DateTime.Today.AddDays(16).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 8, "Eindhoven", new RoundRobin()));
            tm.Tournaments[0].AssignUsers(GetDummyUsers());

            //tm.Update(t, tr);

            Assert.ThrowsException<Exception>(() => tm.Update(tm.Tournaments[0], tr));
            Assert.AreNotEqual(tm.Tournaments[0].Info.StartDate, tr.Info.StartDate);
            Assert.AreNotEqual(tm.Tournaments[0].Title, tr.Title);
        }



        [TestMethod]
        public void TestUpdateCanceledTournament()
        {
            Tournament tr = new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));
            tm.Add(tr);

            Tournament t = new Tournament(1, "Badminton finals", Status.canceled, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));

            Assert.ThrowsException<Exception>(() => tm.Update(tr, t));
            Assert.AreNotEqual(tm.Tournaments[0].Title, t.Title);

        }

        [TestMethod]
        public void TestUpdateFinishedTournament()
        {
            Tournament tr = new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));
            tm.Add(tr);

            Tournament t = new Tournament(1, "Badminton finals", Status.finished, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));

            Assert.ThrowsException<Exception>(() => tm.Update(tr, t));
            Assert.AreNotEqual(tm.Tournaments[0].Title, t.Title);
        }

        [TestMethod]
        public void TestUpdateClosedTournament()
        {
            Tournament tr = new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));
            tm.Add(tr);

            Tournament t = new Tournament(1, "Badminton finals", Status.closed, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));

            tm.Update(tr, t);

            Assert.AreNotEqual(tm.Tournaments[0].Title, t.Title);
            Assert.AreEqual(tm.Tournaments[0].Status, t.Status);

        }


        [TestMethod]
        public void TestUpdateScheduledTournament()
        {
            Tournament tr = new Tournament(1, "Badminton competition", Status.open, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(16).ToString("yyyy-MM-dd"), 6, 30, "Eindhoven", new RoundRobin()));
            tm.Add(tr);

            Tournament t = new Tournament(1, "Badminton finals", Status.closed, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(8).ToString("yyyy-MM-dd"), 6, 30, "Haskovo", new RoundRobin()));

            tm.Update(tr, t);

            Tournament trn = new Tournament(1, "Badminton", Status.scheduled, new TournamentInfo(new Badminton(), "Finals", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(8).ToString("yyyy-MM-dd"), 6, 30, "Haskovo", new RoundRobin()));

            tm.Update(t, trn);

            Assert.AreNotEqual(tm.Tournaments[0].Title, trn.Title);
            Assert.AreEqual(tm.Tournaments[0].Info.Location, trn.Info.Location);
            Assert.AreEqual(tm.Tournaments[0].Status, trn.Status);
        }





        [TestMethod]
        public void TestDeleteValidTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            //Deleting an open tournament with no participants
            tm.Delete(t);
            Assert.AreEqual(0, tm.Tournaments.Count);
        }


        [TestMethod]
        public void TestDeleteInvalidTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            tm.Tournaments[0].AssignUsers(GetDummyUsers());

            //Deleting a tournament with a user in it
            Exception ex = Assert.ThrowsException<Exception>(() => tm.Delete(t));
            Assert.AreEqual("The tournament can't be deleted!", ex.Message);
            Assert.AreEqual(1, tm.Tournaments.Count);
        }

        [TestMethod]
        public void TestDeleteTournamentWithInvalidStatus()
        {
            //Deleting a tournament with invalid status
            Tournament tr = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(tr);
            tm.Tournaments[0].SetStatus(Status.canceled);


            Exception e = Assert.ThrowsException<Exception>(() => tm.Delete(tr));
            Assert.AreEqual("The tournament can't be deleted!", e.Message);
            Assert.AreEqual(1, tm.Tournaments.Count);
        }

        [TestMethod]
        public void TestCancelTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            //Canceling a valid tournament
            tm.Cancel(t);
            Assert.AreEqual(Status.canceled, tm.Tournaments[0].Status);
        }

        [TestMethod]
        public void TestCancelInvalidTournament()
        {
            //Canceling an invalid tournament
            Tournament tr = new Tournament(1, "Tournament", Status.finished, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.AddDays(17).ToString("yyyy-MM-dd"), 6, 30, "Haskovo", new RoundRobin()));
            Exception e = Assert.ThrowsException<Exception>(() => tm.Cancel(tr));
            Assert.AreEqual("The tournament can't be canceled!", e.Message);
            Assert.AreNotEqual(Status.canceled, tr.Status);
        }

        [TestMethod]
        public void TestGetTournamentById()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            Assert.AreEqual(t, tm.GetTournamentByID(1));
        }

        [TestMethod]
        public void TestGetTournamentByInvalidId()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);

            Assert.IsNull(tm.GetTournamentByID(8));
        }

        [TestMethod]
        public void TestGetTournamentsByName()
        {
            Tournament t1 = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            Tournament t2 = new Tournament(2, "Olympics", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            Tournament t3 = new Tournament(3, "National tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t1);
            tm.Add(t2);
            tm.Add(t3);

            //Adding the expected results to a list
            List<Tournament> t = new List<Tournament>();
            t.Add(t1);
            t.Add(t3);

            Assert.AreEqual(2, tm.GetTournamentsByTitle("tour").Count);
            CollectionAssert.AreEquivalent(t, tm.GetTournamentsByTitle("tour"));
        }

        [TestMethod]
        public void TestGetTournamentsByInvalidName()
        {
            Tournament t1 = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            Tournament t2 = new Tournament(2, "Olympics", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            Tournament t3 = new Tournament(3, "National tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));
            tm.Add(t1);
            tm.Add(t2);
            tm.Add(t3);

            //Adding the expected results to a list
            List<Tournament> t = new List<Tournament>();
            t.Add(t1);
            t.Add(t3);

            Assert.AreEqual(0, tm.GetTournamentsByTitle("radi").Count);
        }


        [TestMethod]
        public void TestSetStatusForOpenTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 6, 30, "Haskovo", new RoundRobin()));

            //Setting invalid status
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.scheduled));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.finished));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.closed));

        }


        [TestMethod]
        public void TestSetStatusForClosedTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin()));

            //Setting invalid status
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.open));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.finished));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.scheduled));


            //Setting valid status
            t.SetStatus(Status.canceled);
            Assert.AreEqual(t.Status, Status.canceled);
        }


        [TestMethod]
        public void TestSetStatusForScheduledTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 2, 30, "Haskovo", new RoundRobin()));
            tm.Add(t);
            tm.Update(t, new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(8).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin())));
            tm.Tournaments[0].AssignUsers(GetDummyUsers());
            tm.Tournaments[0].Info.System.GetGames(tm.Tournaments[0]);
            //Assert.AreEqual(t.Status, Status.scheduled);

            Assert.ThrowsException<Exception>(() => tm.Tournaments[0].SetStatus(Status.open));
            Assert.ThrowsException<Exception>(() => tm.Tournaments[0].SetStatus(Status.finished));
            Assert.ThrowsException<Exception>(() => tm.Tournaments[0].SetStatus(Status.closed));

            foreach (var g in tm.Tournaments[0].Games)
            {
                g.AssignResults(21, 12, tm.Tournaments[0]);
            }

            tm.Tournaments[0].SetStatus(Status.finished);
            Assert.AreEqual(tm.Tournaments[0].Status, Status.finished);
        }


        [TestMethod]
        public void SetStatusForFinishedTournament()
        {
            Tournament t = new Tournament(1, "Tournament", Status.finished, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), 2, 30, "Haskovo", new RoundRobin()));

            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.open));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.closed));
            Assert.ThrowsException<Exception>(() => t.SetStatus(Status.scheduled));
        }


        TournamentManager m = new TournamentManager(new MockTournamentDB(), new MockTournamentDB());

        [TestMethod]
        public void TestSignUser()
        {
            Tournament t = new Tournament(1, "Tournament", Status.open, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(15), DateTime.Today.AddDays(17), 2, 10, "Haskovo", new RoundRobin()));

            User user = new User(1, "Radka");
            m.AddUser(t, user);

            Assert.AreEqual(t.Users[0].Id, user.Id);
            //Adding the same user twice
            Exception e = Assert.ThrowsException<Exception>(() => m.AddUser(t, user));
            Assert.AreEqual(e.Message, "You have already registered for this tournament");
            //Filling the maximim number of players and assigning a new one
            t.AssignUsers(GetDummyUsers());
            Exception ex = Assert.ThrowsException<Exception>(() => m.AddUser(t, user));
            Assert.AreEqual(ex.Message, "The maximum number of players has been reached!");

            //Creating a tournament closed for registering
            Tournament tr = new Tournament(1, "Tournament", Status.closed, new TournamentInfo(new Badminton(), "Tr", DateTime.Today.AddDays(2).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(3).ToString("yyyy-MM-dd"), 2, 10, "Haskovo", new RoundRobin()));

            Exception exc = Assert.ThrowsException<Exception>(() => m.AddUser(tr, user));
            Assert.AreEqual(exc.Message, "You can't registered for this tournament");
        }


    }
}