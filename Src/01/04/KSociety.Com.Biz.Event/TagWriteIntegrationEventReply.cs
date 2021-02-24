using ProtoBuf;
using System;

namespace KSociety.Com.Biz.Event
{
    [ProtoContract]
    public class TagWriteIntegrationEventReply : IntegrationComEventReply
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string TagName { get; set; }

        [ProtoMember(3), CompatibilityLevel(CompatibilityLevel.Level200)]
        public DateTime Timestamp { get; set; }

        [ProtoMember(4)]
        public bool Result { get; set; }


        public TagWriteIntegrationEventReply() { }

        public TagWriteIntegrationEventReply(
            string routingKey,
            string groupName,
            string tagName,
            DateTime timestamp,
            bool result
        )
            : base(routingKey)
        {
            GroupName = groupName;
            TagName = tagName;
            Timestamp = timestamp;
            Result = result;
        }
    }
}
