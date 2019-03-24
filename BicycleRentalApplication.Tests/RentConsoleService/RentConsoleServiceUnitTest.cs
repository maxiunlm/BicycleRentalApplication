using BicycleRentalApplication.Rent.ConsoleService;
using BicycleRentalApplication.Rent.ConsoleService.Service;
using BicycleRentalApplication.Tests.Fakes.Rabbit.MQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;

namespace BicycleRentalApplication.Tests.RentConsoleService
{
    [TestClass]
    public class RentConsoleServiceUnitTest
    {
        private Mock<RentService> mocker;

        private readonly IConnectionFactory connectionFactory = new FakeConnectionFactory();

        [TestInitialize]
        public void DoBeforeEach()
        {
            mocker = new Mock<RentService>() { CallBase = true };
        }

        #region LoadService

        [TestMethod]
        public void LoadService_WithoutParameters_InvokesGetConnectionFactoryWichReturnsIConnectionFactoryInstance()
        {
            mocker.Setup(o => o.GetConnectionFactory()).Returns(connectionFactory);
            mocker.Setup(o => o.LoadConnection(connectionFactory));
            IProgram sut = GetSut();

            sut.LoadService();

            mocker.Verify(o => o.GetConnectionFactory(), Times.Once);
        }

        [TestMethod]
        public void LoadService_WithoutParameters_InvokesLoadConnectionWithIConnectionFactoryParameter()
        {
            mocker.Setup(o => o.GetConnectionFactory()).Returns(connectionFactory);
            mocker.Setup(o => o.LoadConnection(connectionFactory));
            IProgram sut = GetSut();

            sut.LoadService();

            mocker.Verify(o => o.LoadConnection(connectionFactory), Times.Once);
        }

        #endregion

        private IProgram GetSut()
        {
            IProgram sut = new Program();
            sut.Service = mocker.Object;

            return sut;
        }
    }
}
