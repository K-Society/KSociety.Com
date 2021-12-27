using ProtoBuf;
using System;

namespace KSociety.Com.Biz.Event;

[ProtoContract]
public class TagIntegrationEvent : IntegrationComEvent
{
    [ProtoMember(1)]
    public string GroupName { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public string Value { get; set; }

    [ProtoMember(4), CompatibilityLevel(CompatibilityLevel.Level200)]
    public DateTime Timestamp { get; set; }

    public TagIntegrationEvent() { }

    public TagIntegrationEvent(
        string routingKey,
        string groupName,
        string name,
        string value,
        DateTime timestamp
    )
        : base(routingKey)
    {
        GroupName = groupName;
        Name = name;
        Value = value;
        Timestamp = timestamp;
    }
}