using ProtoBuf;
using System;

namespace KSociety.Com.Biz.Event
{
    [ProtoContract]
    public class TagReadIntegrationEventReply : IntegrationComEventReply
    {
        [ProtoMember(1)] public string GroupName { get; set; }

        [ProtoMember(2)] public string TagName { get; set; }

        [ProtoMember(3), CompatibilityLevel(CompatibilityLevel.Level200)]
        public DateTime Timestamp { get; set; }

        [ProtoMember(4)] public string TagValue { get; set; }

        public TagReadIntegrationEventReply() { }

        public TagReadIntegrationEventReply(
            string routingKey,
            string groupName,
            string tagName,
            DateTime timestamp,
            string tagValue
        )
            : base(routingKey)
        {
            GroupName = groupName;
            TagName = tagName;
            Timestamp = timestamp;
            TagValue = tagValue;
        }
    }
}