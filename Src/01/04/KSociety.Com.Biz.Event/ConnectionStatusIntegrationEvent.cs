using ProtoBuf;

namespace KSociety.Com.Biz.Event
{
    [ProtoContract]
    public class ConnectionStatusIntegrationEvent : IntegrationComEventRpc
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string ConnectionName { get; set; }

        public ConnectionStatusIntegrationEvent() { }

        public ConnectionStatusIntegrationEvent(
            string routingKey,
            string replyRoutingKey,
            string groupName,
            string connectionName
        )
            : base(routingKey, replyRoutingKey)
        {
            GroupName = groupName;
            ConnectionName = connectionName;
        }
    }
}
