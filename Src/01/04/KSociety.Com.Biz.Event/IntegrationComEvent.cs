using ProtoBuf;

namespace KSociety.Com.Biz.Event
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
