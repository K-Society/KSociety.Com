using KSociety.Base.EventBus.Events;
using ProtoBuf;

namespace KSociety.Com.Biz.Event
{
    [ProtoContract]
    public class IntegrationComEventRpc : IntegrationEventRpc
    {
        public IntegrationComEventRpc()
        {

        }

        public IntegrationComEventRpc(string routingKey, string replyRoutingKey)
            : base(routingKey, replyRoutingKey)
        {

        }
    }
}
