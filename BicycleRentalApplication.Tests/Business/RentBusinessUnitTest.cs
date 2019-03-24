using System;
using System.Collections.Generic;
using BicycleRentalApplication.Rent.Core.Rents;
using BicycleRentalApplication.Rent.Dal.Rents;
using BicycleRentalApplication.Rent.Models.Models;
using BicycleRentalApplication.Rent.Models.Rents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BicycleRentalApplication.Tests.Business
{
    [TestClass]
    public class RentBusinessUnitTest
    {
        private Mock<IRentData> mocker;

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
            mocker = new Mock<IRentData>(); // { CallBase = true }
        }

        #region Create

        [TestMethod]
        public void Create_WithRentModel_InvokesCreateFromRentData()
        {
            mocker.Setup(o => o.Create(rentModelWithoutDiscount));
            IRentBusiness sut = GetSut();

            sut.Create(rentModelWithoutDiscount);

            mocker.Verify(o => o.Create(rentModelWithoutDiscount), Times.Once);
        }

        [TestMethod]
        public void Create_WithoutDiscount_VerifyNoDiscount()
        {
            RentModel rentModel = new RentModel
            {
                Bicycles = 1,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Create(rentModel));
            IRentBusiness sut = GetSut();

            sut.Create(rentModel);

            Assert.AreEqual(DoNotDiscount(rentModel), rentModel.Price);
        }

        [TestMethod]
        public void Create_WithDiscount_VerifyDiscount()
        {
            RentModel rentModel = new RentModel
            {
                Bicycles = 3,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Create(rentModel));
            IRentBusiness sut = GetSut();

            sut.Create(rentModel);

            Assert.AreEqual(DoDiscount(rentModel), rentModel.Price);
        }

        [TestMethod]
        public void Create_WithHoursCost_CalculateReturnDate()
        {
            RentModel rentModel = new RentModel
            {
                Bicycles = 3,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Create(rentModel));
            IRentBusiness sut = GetSut();

            sut.Create(rentModel);

            Assert.AreEqual(CalculateReturnDate(rentModel), rentModel.ReturnDate);
        }

        [TestMethod]
        public void Create_WithDaysCost_CalculateReturnDate()
        {
            RentModel rentModel = new RentModel
            {
                Bicycles = 3,
                Cost = dayCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Create(rentModel));
            IRentBusiness sut = GetSut();

            sut.Create(rentModel);

            Assert.AreEqual(CalculateReturnDate(rentModel), rentModel.ReturnDate);
        }

        [TestMethod]
        public void Create_WithWeeksCost_CalculateReturnDate()
        {
            RentModel rentModel = new RentModel
            {
                Bicycles = 3,
                Cost = weekCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Create(rentModel));
            IRentBusiness sut = GetSut();

            sut.Create(rentModel);

            Assert.AreEqual(CalculateReturnDate(rentModel), rentModel.ReturnDate);
        }

        #endregion

        #region Get

        [TestMethod]
        public void Get_WithId_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.Get(id)).Returns(rentModelWithId);
            IRentBusiness sut = GetSut();

            sut.Get(id);

            mocker.Verify(o => o.Get(id), Times.Once);
        }

        [TestMethod]
        public void Get_CallsGetFromRentData_ReturnsRentModel()
        {
            mocker.Setup(o => o.Get(id)).Returns(rentModelWithId);
            IRentBusiness sut = GetSut();

            RentModel rent = sut.Get(id);

            Assert.AreSame(rentModelWithId, rent);
        }

        #endregion

        #region Update

        [TestMethod]
        public void Update_WithRentModel_InvokesUpdateFromRentData()
        {
            mocker.Setup(o => o.Update(rentModelWithoutDiscount));
            IRentBusiness sut = GetSut();

            sut.Update(rentModelWithoutDiscount);

            mocker.Verify(o => o.Update(rentModelWithoutDiscount), Times.Once);
        }

        [TestMethod]
        public void Update_WithoutDiscount_VerifyNoDiscount()
        {
            RentModel rentModel = new RentModel
            {
                Id = id,
                Bicycles = 1,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Update(rentModel));
            IRentBusiness sut = GetSut();

            sut.Update(rentModel);

            Assert.AreEqual(DoNotDiscount(rentModel), rentModel.Price);
        }

        [TestMethod]
        public void Update_WithDiscount_VerifyDiscount()
        {
            RentModel rentModel = new RentModel
            {
                Id = id,
                Bicycles = 3,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Update(rentModel));
            IRentBusiness sut = GetSut();

            sut.Update(rentModel);

            Assert.AreEqual(DoDiscount(rentModel), rentModel.Price);
        }

        [TestMethod]
        public void Update_WithDateTimeNow_CalculateReturnDate()
        {
            RentModel rentModel = new RentModel
            {
                Id = id,
                Bicycles = 3,
                Cost = hourCost,
                Count = 1,
                Date = DateTime.Now
            };
            mocker.Setup(o => o.Update(rentModel));
            IRentBusiness sut = GetSut();

            sut.Update(rentModel);

            Assert.AreEqual(CalculateReturnDate(rentModel), rentModel.ReturnDate);
        }

        #endregion

        #region Delete

        [TestMethod]
        public void Delete_WithId_InvokesDeleteFromRentData()
        {
            mocker.Setup(o => o.Delete(id));
            IRentBusiness sut = GetSut();

            sut.Delete(id);

            mocker.Verify(o => o.Delete(id), Times.Once);
        }

        #endregion

        #region ListAll

        [TestMethod]
        public void ListAll_WithoutParameters_InvokesGetFromRentData()
        {
            mocker.Setup(o => o.ListAll()).Returns(rentModels);
            IRentBusiness sut = GetSut();

            sut.ListAll();

            mocker.Verify(o => o.ListAll(), Times.Once);
        }

        [TestMethod]
        public void ListAll_WithoutParameters_ReturnsRentModelList()
        {
            mocker.Setup(o => o.ListAll()).Returns(rentModels);
            IRentBusiness sut = GetSut();

            List<RentModel> rents = sut.ListAll();

            Assert.AreSame(rentModels, rents);
        }

        #endregion

        private IRentBusiness GetSut()
        {
            IRentBusiness sut = new RentBusiness();
            sut.RentData = mocker.Object;

            return sut;
        }

        private decimal DoDiscount(RentModel rent)
        {
            decimal discount = 0.7M;

            return rent.Cost * rent.Count * rent.Bicycles * discount;
        }

        private decimal DoNotDiscount(RentModel rent)
        {
            return rent.Cost * rent.Count * rent.Bicycles;
        }

        private DateTime CalculateReturnDate(RentModel rent)
        {
            switch ((RentType)rent.Cost)
            {
                case RentType.hours:
                    return rent.Date.AddHours(rent.Count);
                case RentType.days:
                    return rent.Date.AddDays(rent.Count);
                case RentType.weeks:
                    return rent.Date.AddDays(rent.Count * 7);
            }

            return DateTime.Now;
        }
    }
}
