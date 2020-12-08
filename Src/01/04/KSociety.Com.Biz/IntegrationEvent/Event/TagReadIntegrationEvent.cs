using ProtoBuf;

namespace KSociety.Com.Biz.IntegrationEvent.Event
{
    [ProtoContract]
    public class TagReadIntegrationEvent : IntegrationComEventRpc
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        public TagReadIntegrationEvent() { }

        public TagReadIntegrationEvent(
            string routingKey,
            string replyRoutingKey,
            string groupName,
            string name
        )
            : base(routingKey, replyRoutingKey)
        {
            GroupName = groupName;
            Name = name;
        }
    }
}
