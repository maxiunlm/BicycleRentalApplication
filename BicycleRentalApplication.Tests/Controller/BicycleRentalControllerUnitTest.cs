using BicycleRentalApplication.Controllers;
using BicycleRentalApplication.Rent.Core.Rents;
using BicycleRentalApplication.Rent.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BicycleRentalApplication.Tests.Controller
{
    [TestClass]
    public class BicycleRentalControllerUnitTest
    {
        private Mock<IRentBusiness> mocker;

        private const int id = 1;
        private const int hourCost = 5;
        private const int dayCost = 20;
        private const int weekCost = 60;
        private static readonly RentModel rentModelWithoutDiscount = new RentModel
        {
            Bicycles = 1,
            Cost = hourCost,
            Count = 1,
            Date = DateTime.Now
        };
        private static readonly RentModel rentModelWithDiscount = new RentModel
        {
            Bicycles = 3,
            Cost = hourCost,
            Count = 1,
            Date = DateTime.Now
        };
        private static readonly RentModel rentModelWithId = new RentModel
        {
            Id = id,
            Bicycles = 1,
            Cost = hourCost,
            Count = 1,
            Date = DateTime.Now
        };
        private static readonly List<RentModel> rentModels = new List<RentModel>
        {
            rentModelWithId
        };

        [TestInitialize]
        public void DoBeforeEach()
        {
            mocker = new Mock<IRentBusiness>(); // { CallBase = true }
        }

        #region Create

        [TestMethod]
        public void Create_WithRentModel_InvokesCreateFromRentBuisness()
        {
            mocker.Setup(o => o.Create(rentModelWithoutDiscount));
            IBicycleRentalController sut = GetSut();

            sut.Create(rentModelWithoutDiscount);

            mocker.Verify(o => o.Create(rentModelWithoutDiscount), Times.Once);
        }

        #endregion

        #region Details

        [TestMethod]
        public void Details_WithId_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.Get(id)).Returns(rentModelWithId);
            IBicycleRentalController sut = GetSut();

            sut.Details(id);

            mocker.Verify(o => o.Get(id), Times.Once);
        }

        #endregion

        #region Edit

        [TestMethod]
        public void Edit_WithId_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.Get(id));
            IBicycleRentalController sut = GetSut();

            sut.Edit(id);

            mocker.Verify(o => o.Get(id), Times.Once);
        }

        [TestMethod]
        public void Edit_WithRentModel_InvokesUpdateFromRentData()
        {
            mocker.Setup(o => o.Update(rentModelWithId));
            IBicycleRentalController sut = GetSut();

            sut.Edit(rentModelWithId);

            mocker.Verify(o => o.Update(rentModelWithId), Times.Once);
        }

        #endregion

        #region Delete

        [TestMethod]
        public void Delete_WithId_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.Get(id));
            IBicycleRentalController sut = GetSut();

            sut.Delete(id);

            mocker.Verify(o => o.Get(id), Times.Once);
        }

        [TestMethod]
        public void Delete_WithRentModel_InvokesDeleteFromRentData()
        {
            mocker.Setup(o => o.Delete(id));
            IBicycleRentalController sut = GetSut();

            sut.Delete(rentModelWithId);

            mocker.Verify(o => o.Delete(id), Times.Once);
        }

        #endregion

        #region Index

        [TestMethod]
        public void Index_WithoutParameters_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.ListAll()).Returns(rentModels);
            IBicycleRentalController sut = GetSut();

            sut.Index();

            mocker.Verify(o => o.ListAll(), Times.Once);
        }

        #endregion

        private IBicycleRentalController GetSut()
        {
            BicycleRentalController sut = new BicycleRentalController();
            sut.RentBusiness = mocker.Object;

            return sut;
        }
    }
}
