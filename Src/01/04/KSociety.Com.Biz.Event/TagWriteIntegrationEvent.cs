using ProtoBuf;

namespace KSociety.Com.Biz.Event
{
    [ProtoContract]
    public class TagWriteIntegrationEvent : IntegrationComEventRpc
    {
        [ProtoMember(1)] public string GroupName { get; set; }

        [ProtoMember(2)] public string Name { get; set; }

        [ProtoMember(3)] public string Value { get; set; }

        public TagWriteIntegrationEvent() { }

        public TagWriteIntegrationEvent(
            string routingKey,
            string replyRoutingKey,
            string groupName,
            string name,
            string value
        )
            : base(routingKey, replyRoutingKey)
        {
            GroupName = groupName;
            Name = name;
            Value = value;
        }
    }
}