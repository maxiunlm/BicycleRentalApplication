using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRentalApplication.Tests.Fakes.Rabbit.MQ
{
    public class FakeConnectionFactory : IConnectionFactory
    {
        public IDictionary<string, object> ClientProperties { get; set; }
        public string Password { get; set; }
        public ushort RequestedChannelMax { get; set; }
        public uint RequestedFrameMax { get; set; }
        public ushort RequestedHeartbeat { get; set; }
        public bool UseBackgroundThreadsForIO { get; set; }
        public string UserName { get; set; }
        public string VirtualHost { get; set; }
        public Uri Uri { get; set; }
        public TaskScheduler TaskScheduler { get; set; }
        public TimeSpan HandshakeContinuationTimeout { get; set; }
        public TimeSpan ContinuationTimeout { get; set; }

        public AuthMechanismFactory AuthMechanismFactory(IList<string> mechanismNames)
        {
            return null;
        }

        public IConnection CreateConnection()
        {
            return new FakeConnection();
        }

        public IConnection CreateConnection(string clientProvidedName)
        {
            return null;
        }

        public IConnection CreateConnection(IList<string> hostnames)
        {
            return null;
        }

        public IConnection CreateConnection(IList<string> hostnames, string clientProvidedName)
        {
            return null;
        }

        public IConnection CreateConnection(IList<AmqpTcpEndpoint> endpoints)
        {
            return null;
        }
    }
}
