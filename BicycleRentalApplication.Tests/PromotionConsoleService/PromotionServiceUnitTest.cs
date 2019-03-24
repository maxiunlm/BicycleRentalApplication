using BicycleRentalApplication.Promotion.ConsoleService.Service;
using BicycleRentalApplication.Tests.Fakes.Rabbit.MQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace BicycleRentalApplication.Tests.PromotionConsoleService
{
    [TestClass]
    public class PromotionServiceUnitTest
    {
        private Mock<PromotionService> consoleServiceMocker;
        private Mock<IConnectionFactory> connectionFactoryMocker;
        private Mock<IConnection> connectionMocker;
        private Mock<FakeModel> modelMocker;

        private static readonly IConnectionFactory connectionFactory = new FakeConnectionFactory();
        private static readonly IConnection connection = new FakeConnection();
        private static readonly IModel model = new FakeModel();
        private static readonly QueueDeclareOk queueDeclareOk = new QueueDeclareOk(string.Empty, 0, 0);
        private static readonly EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(model);

        [TestInitialize]
        public void DoBeforeEach()
        {
            consoleServiceMocker = new Mock<PromotionService>() { CallBase = true };
            connectionFactoryMocker = new Mock<IConnectionFactory>() { CallBase = true };
            connectionMocker = new Mock<IConnection>() { CallBase = true };
            modelMocker = new Mock<FakeModel>() { CallBase = true };
        }

        #region LoadConnection

        [TestMethod]
        public void LoadConnection_WithIConnectionFactory_InvokesCreateConnectionWichReturnsIConnection()
        {
            connectionFactoryMocker.Setup(o => o.CreateConnection()).Returns(connection);
            consoleServiceMocker.Setup(o => o.LoadChannel(connection));
            PromotionService sut = GetSut();

            sut.LoadConnection(connectionFactoryMocker.Object);

            connectionFactoryMocker.Verify(o => o.CreateConnection(), Times.Once);
        }

        [TestMethod]
        public void LoadConnection_WithIConnection_InvokesLoadChannel()
        {
            connectionFactoryMocker.Setup(o => o.CreateConnection()).Returns(connection);
            consoleServiceMocker.Setup(o => o.LoadChannel(connection));
            PromotionService sut = GetSut();

            sut.LoadConnection(connectionFactoryMocker.Object);

            consoleServiceMocker.Verify(o => o.LoadChannel(connection), Times.Once);
        }

        #endregion

        #region LoadChannel

        [TestMethod]
        public void LoadChannel_WithIModel_InvokesCreateModelWichReturnsIModel()
        {
            connectionMocker.Setup(o => o.CreateModel()).Returns(model);
            consoleServiceMocker.Setup(o => o.QueueDeclare(model));
            consoleServiceMocker.Setup(o => o.BasicConsume(model, It.IsAny<EventingBasicConsumer>()));
            PromotionService sut = GetSut();

            sut.LoadChannel(connectionMocker.Object);

            connectionMocker.Verify(o => o.CreateModel(), Times.Once);
        }

        [TestMethod]
        public void LoadConnection_WithIModle_InvokesQueueDeclare()
        {
            connectionMocker.Setup(o => o.CreateModel()).Returns(model);
            consoleServiceMocker.Setup(o => o.QueueDeclare(model));
            consoleServiceMocker.Setup(o => o.BasicConsume(model, It.IsAny<EventingBasicConsumer>()));
            PromotionService sut = GetSut();

            sut.LoadChannel(connectionMocker.Object);

            consoleServiceMocker.Verify(o => o.QueueDeclare(model), Times.Once);
        }

        [TestMethod]
        public void LoadConnection_WithIModelAndEventHandler_InvokesBasicConsume()
        {
            connectionMocker.Setup(o => o.CreateModel()).Returns(model);
            consoleServiceMocker.Setup(o => o.QueueDeclare(model));
            consoleServiceMocker.Setup(o => o.BasicConsume(model, It.IsAny<EventingBasicConsumer>()));
            PromotionService sut = GetSut();

            sut.LoadChannel(connectionMocker.Object);

            consoleServiceMocker.Verify(o => o.BasicConsume(model, It.IsAny<EventingBasicConsumer>()), Times.Once);
        }

        #endregion

        #region QueueDeclare

        [TestMethod]
        public void QueueDeclare_WithIModel_InvokesQueueDeclareFromModel()
        {
            modelMocker.Setup(o => o.QueueDeclare(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IDictionary<string, object>>()))
                .Returns(queueDeclareOk);
            PromotionService sut = GetSut();

            sut.QueueDeclare(modelMocker.Object);

            modelMocker.Verify(o => o.QueueDeclare(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IDictionary<string, object>>()),
                Times.Once);
        }

        #endregion

        #region BasicConsume

        [TestMethod]
        public void BasicConsume_WithIModelAndEventHandler_InvokesBasicConsumeFromModel()
        {//public virtual string BasicConsume(string queue, bool autoAck, string consumerTag, bool noLocal, bool exclusive, IDictionary<string, object> arguments, IBasicConsumer consumer)
            modelMocker.Setup(o => o.BasicConsume(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<IBasicConsumer>()))
                .Returns(string.Empty);
            PromotionService sut = GetSut();

            sut.BasicConsume(modelMocker.Object, eventingBasicConsumer);

            modelMocker.Verify(o => o.BasicConsume(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<IBasicConsumer>()),
                Times.Once);
        }

        #endregion

        #region ReciveMessage

        [TestMethod]
        public void ReciveMessage_WithCreateMessageAndPromotionBusiness_InvokesCreateMethod()
        {

        }

        #endregion

        private PromotionService GetSut()
        {
            PromotionService sut = consoleServiceMocker.Object;

            return sut;
        }
    }
}
