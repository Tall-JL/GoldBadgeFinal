using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _3_BadgesPOCO;
using _3_BadgesRepository;
using System.Collections.Generic;

namespace _3_BadgesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private BadgesModel _badgesModel;
        private BadgesRepo _badgesRepo;

        [TestInitialize]
        public void Arrange()
        {
            _badgesModel = new BadgesModel(new List<string> {"A2", "A1", "A5" }, "Main Hall");
            _badgesRepo = new BadgesRepo();

            _badgesRepo.AddBadge(_badgesModel);
        }

        [TestMethod]
        public void AddBadge_AddsObjToField_ReturnTrue()
        {
            bool result = _badgesRepo.AddBadge(_badgesModel);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddBadge_AddsObjToField_ReturnFalse ()
        {
            _badgesModel = null;

            bool result = _badgesRepo.AddBadge(_badgesModel);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetBadgeByID_FindsObjByInt_ReturnsObjsValue()
        {
            int number = 1;

            BadgesModel result = _badgesRepo.GetBadgeByKey(number);

            Assert.AreEqual(result.BadgeID, number);
        }
    }
}
