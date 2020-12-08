using ProtoBuf;

namespace KSociety.Com.Biz.IntegrationEvent.Event
{
    [ProtoContract]
    public class ConnectionStatusIntegrationEvent : IntegrationComEvent
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string ConnectionName { get; set; }

        public ConnectionStatusIntegrationEvent() { }

        public ConnectionStatusIntegrationEvent(
            string routingKey,
            string groupName,
            string connectionName
        )
            : base(routingKey)
        {
            GroupName = groupName;
            ConnectionName = connectionName;
        }
    }
}
