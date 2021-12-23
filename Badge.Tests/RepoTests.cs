using Badge.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badge.Tests
{
    [TestClass]
    public class RepoTests
    {
        private static readonly BadgeRepo _badgeRepo = new BadgeRepo();

        [TestMethod]
        public void CreateBadge_Test()
        {
            List<string> listOfDoors = new List<string>()
            {
                "a5", "a7", "a9"
            };
            BadgePOCO testBadge = new BadgePOCO(1, listOfDoors);

            bool isAdded = _badgeRepo.CreateBadge(testBadge);

            Assert.IsTrue(isAdded);
        }
        [TestMethod]
        public void GetBadges_Test()
        {
            List<string> listOfDoors = new List<string>()
            {
                "a5", "a7", "a9"
            };
            BadgePOCO testBadge = new BadgePOCO(1, listOfDoors);
            BadgePOCO testBadge2 = new BadgePOCO(2, listOfDoors);
            Dictionary<int, List<string>> dictBadges = _badgeRepo.GetBadges();

            _badgeRepo.CreateBadge(testBadge);
            _badgeRepo.CreateBadge(testBadge2);

            Assert.IsTrue(dictBadges.ContainsKey(1));
            Assert.IsTrue(dictBadges.ContainsKey(2));

        }
    }
}
