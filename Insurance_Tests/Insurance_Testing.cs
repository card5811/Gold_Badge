using System;
using System.Collections.Generic;
using Insurance_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance_Tests
{
    [TestClass]
    public class Insurance_Testing
    {// Create a Test Class for your repository methods.
        [TestMethod]
        public void TestTimeLapse_ShouldReturnFalse()
        {
            Claim newClaim = new Claim();

            DateTime personalClaim = new DateTime();
            DateTime incidentDate = new DateTime();

            personalClaim = new DateTime(2020, 02, 18);
            incidentDate = new DateTime(2019, 12, 18);


            TimeSpan dayslapsed = personalClaim - incidentDate;
            double totalDays = dayslapsed.TotalDays;

            Assert.IsTrue(totalDays > 30);
        }
        [TestMethod]
        public void EnquiingClaim_ShouldGetCorrectBoolean()
        {
            Claim content = new Claim();
            Insurance_Repo repo = new Insurance_Repo();

            bool addResult = repo.EnquingClaimToQueue(_claim);

            Assert.IsTrue(addResult);

        }


        [TestMethod]
        public void GetQueue_ShouldReturnAllQueuedItems()
        {
            Claim content = new Claim();
            Insurance_Repo repo = new Insurance_Repo();

            repo.EnquingClaimToQueue(content);

            Queue<Claim> contents = repo.GetAllClaims();

            bool queueHasContent = contents.Contains(content);
            Assert.IsTrue(queueHasContent);
        }

        private Insurance_Repo _repo;
        private Claim _claim;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new Insurance_Repo();
            _claim = new Claim(1343, ClaimType.Renters, "Apartment above flooded which created water damage for lower resident.", 25000.00, new DateTime(2020, 01, 23), new DateTime(2020, 01, 31));
            _repo.EnquingClaimToQueue(_claim);
        }

        /*        [TestMethod]  for version 2.0
                public void GetByID_ShouldReturnContent()
                {
                    Claim search = _repo.GetClaimsByID(1343);
                    Assert.AreEqual(_claim, search);
                }*/

        [TestMethod]
        public void DequeueingClaim_ShouldReturnTrue()
        {
            bool removeClaim = _repo.DequeueClaimFromQueue();
            Assert.IsTrue(removeClaim);
        }
    }
}
