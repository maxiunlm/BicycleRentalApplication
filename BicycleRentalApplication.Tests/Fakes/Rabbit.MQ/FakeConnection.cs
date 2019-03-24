using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRentalApplication.Tests.Fakes.Rabbit.MQ
{
    public class FakeConnection : IConnection
    {
        public bool AutoClose { get; set; }

        public ushort ChannelMax { get; }

        public IDictionary<string, object> ClientProperties { get; }

        public ShutdownEventArgs CloseReason { get; }

        public AmqpTcpEndpoint Endpoint { get; }

        public uint FrameMax { get; }

        public ushort Heartbeat { get; }

        public bool IsOpen { get; }

        public AmqpTcpEndpoint[] KnownHosts { get; }

        public IProtocol Protocol { get; }

        public IDictionary<string, object> ServerProperties { get; }

        public IList<ShutdownReportEntry> ShutdownReport { get; }

        public string ClientProvidedName { get; }

        public ConsumerWorkService ConsumerWorkService { get; }

        public int LocalPort { get; }

        public int RemotePort { get; }

        public event EventHandler<CallbackExceptionEventArgs> CallbackException;
        public event EventHandler<EventArgs> RecoverySucceeded;
        public event EventHandler<ConnectionRecoveryErrorEventArgs> ConnectionRecoveryError;
        public event EventHandler<ConnectionBlockedEventArgs> ConnectionBlocked;
        public event EventHandler<ShutdownEventArgs> ConnectionShutdown;
        public event EventHandler<EventArgs> ConnectionUnblocked;

        public void Abort()
        {
            
        }

        public void Abort(ushort reasonCode, string reasonText)
        {
            
        }

        public void Abort(int timeout)
        {
            
        }

        public void Abort(ushort reasonCode, string reasonText, int timeout)
        {
            
        }

        public void Close()
        {
            
        }

        public void Close(ushort reasonCode, string reasonText)
        {
            
        }

        public void Close(int timeout)
        {
            
        }

        public void Close(ushort reasonCode, string reasonText, int timeout)
        {
            
        }

        public IModel CreateModel()
        {
            return new FakeModel();
        }

        public void Dispose()
        {
            
        }

        public void HandleConnectionBlocked(string reason)
        {
            
        }

        public void HandleConnectionUnblocked()
        {
            
        }
    }
}
