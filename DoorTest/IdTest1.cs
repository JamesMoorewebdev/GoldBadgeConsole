using System;
using System.Collections.Generic;
using _03_Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoorTest
{
    [TestClass]
    public class BadgeRepoTest
    {
        private Repo _badgeRepo;
        private BadgeRepo _badge;
        private Dictionary<int, Repo> _badgeIdAndDrs;

        [TestInitialize]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            doors.Add("A1");
            doors.Add("C7");
            _badgeRepo = new Repo();
            _badge = new BadgeRepo(35, doors);
            _badgeIdAndDrs = new Dictionary<int, Repo>();
            _badgeRepo.AddContentsToDictionary(_badge);

        }
        [TestMethod]
        public void AddContentsToDictionary_ShouldBeTrue()
        {
            bool wasAdded = _badgeRepo.AddContentsToDictionary(_badge);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetDictionary()
        {
            BadgeRepo newbadgeRepo = new BadgeRepo();
            _badgeRepo.AddContentsToDictionary(newbadgeRepo);
            Dictionary<int, BadgeRepo> badges = _badgeRepo.ReturnContentsDictionary();
            var dictionaryHasContents = badges.Count;
            Assert.AreEqual(2, dictionaryHasContents);

        }

        [TestMethod]
        public void GetBadgeNum()
        {
            BadgeRepo searchResults = _badgeRepo.GetBadgeByNum(11);
            Assert.AreEqual(_badgeRepo, searchResults);


        }
        [TestMethod]
        public void AddDrToBadge()
        {
            bool wasAdded = _badgeRepo.AddADrToBadge(_badge, "B4");
            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void DeleteDoorFrmBadge()
        {
            bool wasDeleted = _badgeRepo.RemoveADrFromBadge(_badge, "B9");
            Assert.IsTrue(wasDeleted);
        }
    }
}
