using KSociety.Base.EventBus.Events;
using ProtoBuf;

namespace KSociety.Com.Biz.IntegrationEvent.Event
{
    [ProtoContract]
    public class IntegrationComEventReply : IntegrationEventReply
    {
        public IntegrationComEventReply()
        {

        }

        public IntegrationComEventReply(string routingKey)
            :base(routingKey)
        {

        }
    }
}
