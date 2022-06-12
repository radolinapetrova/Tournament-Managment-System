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
    public class PasswordHasherTesting
    {
        UserManager um = new UserManager(new MockUserDB(), new MockUserDB());

        [TestMethod]
        public void TestPassowrdHashing()
        {
            string pass = "1234";

            string[] hashPass = um.GetPass(pass);
            //The virst value in the array is the salt and the second is the password
           
            Assert.AreNotEqual(pass, hashPass[1]);
            Assert.AreEqual(hashPass[1], um.GetPass(pass, hashPass[0])[1]);
        }

    }
}