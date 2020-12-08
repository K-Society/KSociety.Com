using ProtoBuf;

namespace KSociety.Com.Biz.IntegrationEvent.Event
{
    [ProtoContract]
    public class IntegrationComEvent : KSociety.Base.EventBus.Events.IntegrationEvent
    {
        public IntegrationComEvent()
        {

        }

        public IntegrationComEvent(string routingKey)
            : base(routingKey)
        {

        }
    }
}
