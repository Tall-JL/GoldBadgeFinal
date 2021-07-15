using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using _2_ClaimsPOCO;
using _2_ClaimsRepository;

namespace _2_ClaimsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsModel _claimsModel;
        private ClaimsRepo _claimsRepo;

        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepo();
            _claimsModel = new ClaimsModel(ClaimType.Theft,"Oh no!!!", "400", new DateTime(2021, 7, 13));

            _claimsRepo.AddToQueue(_claimsModel);
        }
        [TestMethod]
        public void AddToQueue_AddsClaimModelToQueue_ReturnTrue()
        {
            bool result = _claimsRepo.AddToQueue(_claimsModel);

            Assert.IsTrue(result);
        }[TestMethod]
        public void RemoveFromQueue_RemovesClaimModelFromQueue_ReturnTrue()
        {
            bool result = _claimsRepo.RemoveFromQueue();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void HandleNextClaim_PeeksNextInQueue_ReturnClaimModel()
        {
            ClaimsModel result = _claimsRepo.HandleNextClaim();

            Assert.AreEqual(result, _claimsModel);
        }
        [TestMethod]
        public void IsValid_ChecksTwoDatesToSeeIfItsInThirtyDays_ReturnTrue()
        {
            bool result = _claimsRepo.IsValidCheck(new DateTime(2021, 7, 1), new DateTime(2021, 7, 13));

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValid_ChecksTwoDatesToSeeIfItsInThirtyDays_ReturnFalse()
        {
            bool result = _claimsRepo.IsValidCheck(new DateTime(2021, 1, 1), new DateTime(2021, 7, 13));

            Assert.IsFalse(result);
        }
    }
}
