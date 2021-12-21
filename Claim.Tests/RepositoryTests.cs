using Claim.POCO;
using Claim.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claim.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private ClaimPOCO _claim;
        private ClaimRepo _claimRepo;
        
        [TestInitialize]
        public void AddToQueue()
        {
            _claimRepo = new ClaimRepo();
            _claim = new ClaimPOCO(1, ClaimPOCO.ClaimType.Car, "Car vs Truck", 400, new DateTime(2018, 04, 18), new DateTime(2018, 04, 19), true);

            _claimRepo.AddClaim(_claim);
        }

       /* [TestMethod]
        public void PeekAtNextClaim()
        {
            //Arrange
            ClaimPOCO claimPeek = new ClaimPOCO(3, ClaimPOCO.ClaimType.Theft, "Stolen Tools", 100m, new DateTime(2020, 06, 05), new DateTime(2020, 06, 07), true);
            _claimRepo.AddClaim(claimPeek);

            //Act
            bool peekResult = _claimRepo.NextClaim();

            //Assert
            Assert.IsNotNull(peekResult);
        }*/
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange
            ClaimPOCO deleteTest = new ClaimPOCO(2, ClaimPOCO.ClaimType.Home, "House fire", 9000m, new DateTime(2021, 09, 08), new DateTime(2021, 09, 09), true);
            _claimRepo.AddClaim(deleteTest);
            //Act
            bool deleteResult = _claimRepo.RemoveClaim();//cannot run bool against void??
            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
