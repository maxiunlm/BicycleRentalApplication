using System;
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BicycleRentalApplication.Tests.Fakes.Rabbit.MQ
{
    class FakeModel : IModel
    {
        public int ChannelNumber { get; }

        public ShutdownEventArgs CloseReason { get; }

        public IBasicConsumer DefaultConsumer { get; set; }

        public bool IsClosed { get; }

        public bool IsOpen { get; }

        public ulong NextPublishSeqNo { get; }

        public TimeSpan ContinuationTimeout { get; set; }

        public event EventHandler<BasicAckEventArgs> BasicAcks;
        public event EventHandler<BasicNackEventArgs> BasicNacks;
        public event EventHandler<EventArgs> BasicRecoverOk;
        public event EventHandler<BasicReturnEventArgs> BasicReturn;
        public event EventHandler<CallbackExceptionEventArgs> CallbackException;
        public event EventHandler<FlowControlEventArgs> FlowControl;
        public event EventHandler<ShutdownEventArgs> ModelShutdown;

        public void Abort()
        {
            
        }

        public void Abort(ushort replyCode, string replyText)
        {
            
        }

        public void BasicAck(ulong deliveryTag, bool multiple)
        {
            
        }

        public void BasicCancel(string consumerTag)
        {
            
        }

        public virtual string BasicConsume(string queue, bool autoAck, string consumerTag, bool noLocal, bool exclusive, IDictionary<string, object> arguments, IBasicConsumer consumer) => string.Empty;

        public BasicGetResult BasicGet(string queue, bool autoAck)
        {
            return null;
        }

        public void BasicNack(ulong deliveryTag, bool multiple, bool requeue)
        {
            
        }

        public void BasicPublish(string exchange, string routingKey, bool mandatory, IBasicProperties basicProperties, byte[] body)
        {
            
        }

        public void BasicQos(uint prefetchSize, ushort prefetchCount, bool global)
        {
            
        }

        public void BasicRecover(bool requeue)
        {
            
        }

        public void BasicRecoverAsync(bool requeue)
        {
            
        }

        public void BasicReject(ulong deliveryTag, bool requeue)
        {
            
        }

        public void Close()
        {
            
        }

        public void Close(ushort replyCode, string replyText)
        {
            
        }

        public void ConfirmSelect()
        {
            
        }

        public uint ConsumerCount(string queue)
        {
            return 0;
        }

        public IBasicProperties CreateBasicProperties()
        {
            return null;
        }

        public IBasicPublishBatch CreateBasicPublishBatch()
        {
            return null;
        }

        public void Dispose()
        {
            
        }

        public void ExchangeBind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public void ExchangeBindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public void ExchangeDeclare(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            
        }

        public void ExchangeDeclareNoWait(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            
        }

        public void ExchangeDeclarePassive(string exchange)
        {
            
        }

        public void ExchangeDelete(string exchange, bool ifUnused)
        {
            
        }

        public void ExchangeDeleteNoWait(string exchange, bool ifUnused)
        {
            
        }

        public void ExchangeUnbind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public void ExchangeUnbindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public uint MessageCount(string queue)
        {
            return 0;
        }

        public void QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public void QueueBindNoWait(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public virtual QueueDeclareOk QueueDeclare(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            return new QueueDeclareOk(queue, 0, 0);
        }

        public void QueueDeclareNoWait(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            
        }

        public QueueDeclareOk QueueDeclarePassive(string queue)
        {
            return null;
        }

        public uint QueueDelete(string queue, bool ifUnused, bool ifEmpty)
        {
            return 0;
        }

        public void QueueDeleteNoWait(string queue, bool ifUnused, bool ifEmpty)
        {
            
        }

        public uint QueuePurge(string queue)
        {
            return 0;
        }

        public void QueueUnbind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            
        }

        public void TxCommit()
        {
            
        }

        public void TxRollback()
        {
            
        }

        public void TxSelect()
        {
            
        }

        public bool WaitForConfirms()
        {
            return false;
        }

        public bool WaitForConfirms(TimeSpan timeout)
        {
            return false;
        }

        public bool WaitForConfirms(TimeSpan timeout, out bool timedOut)
        {
            timedOut = false;
            return false;   
        }

        public void WaitForConfirmsOrDie()
        {
            
        }

        public void WaitForConfirmsOrDie(TimeSpan timeout)
        {
            
        }
    }
}
