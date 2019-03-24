using System;
using BicycleRentalApplication.Rent.Dal.Rents;
using BicycleRentalApplication.Rent.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace BicycleRentalApplication.Tests.Data
{
    [TestClass]
    public class RentDataUnitTest
    {
        private Mock<Context> mocker;
        private Mock<DbSet<RentModel>> rentMocker;

        private const int id = 1;
        private readonly RentModel rentModel = new RentModel
        {
            Bicycles = 1,
            Cost = 5,
            Count = 1,
            Date = DateTime.Now
        };

        [TestInitialize]
        public void DoBeforeEach()
        {
            mocker = new Mock<Context>();
            rentMocker = new Mock<DbSet<RentModel>>();
        }

        #region Create

        [TestMethod]
        public void Create_WithRentModel_InvokesSaveChanges()
        {
            mocker.Setup(o => o.SaveChanges());
            IRentData sut = GetSut();

            sut.Create(rentModel);

            mocker.Verify(o => o.SaveChanges(), Times.Once);
        }

        #endregion

        private IRentData GetSut()
        {
            IRentData sut = new RentData();
            mocker.SetupGet(o => o.Rent).Returns(rentMocker.Object);
            sut.Context = mocker.Object;

            return sut;
        }
    }
}
