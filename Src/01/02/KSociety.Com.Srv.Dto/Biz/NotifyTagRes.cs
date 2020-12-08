using System;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Biz
{
    [ProtoContract]
    public class NotifyTagRes
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public string Value { get; set; }

        [ProtoMember(4), CompatibilityLevel(CompatibilityLevel.Level200)]
        public DateTime Timestamp { get; set; }

        public NotifyTagRes() { }

        public NotifyTagRes(
            string groupName,
            string name,
            string value,
            DateTime timestamp
        )
        {
            GroupName = groupName;
            Name = name;
            Value = value;
            Timestamp = timestamp;
        }
    }
}
