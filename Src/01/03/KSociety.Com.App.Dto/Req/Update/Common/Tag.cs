using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.Common;

[ProtoContract]
public class Tag : IRequest
{
    [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    public int AutomationTypeId { get; set; }

    [ProtoMember(3)]
    public string Name { get; set; }

    [ProtoMember(4), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid ConnectionId { get; set; }

    [ProtoMember(5)]
    public bool Enable { get; set; }

    [ProtoMember(6)]
    public string InputOutput { get; set; }

    [ProtoMember(7)]
    public string AnalogDigitalSignal { get; set; }

    [ProtoMember(8)]
    public string MemoryAddress { get; set; }

    [ProtoMember(9)]
    public bool Invoke { get; set; }

    [ProtoMember(10), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid TagGroupId { get; set; }

    public Tag() { }

    public Tag
    (
        Guid id,
        int automationTypeId,
        string name,
        Guid connectionId,
        bool enable,
        string inputOutput,
        string analogDigitalSignal,
        string memoryAddress,
        bool invoke,
        Guid tagGroupId
    )
    {
        Id = id;
        AutomationTypeId = automationTypeId;
        Name = name;
        ConnectionId = connectionId;
        Enable = enable;
        InputOutput = inputOutput;
        AnalogDigitalSignal = analogDigitalSignal;
        MemoryAddress = memoryAddress;
        Invoke = invoke;
        TagGroupId = tagGroupId;
    }

    //public Tag
    //(
    //    KBase.KBase..Db.Query.Dto.Common.Tag tag
    //)
    //{
    //    Name = tag.Name;
    //    StdConnectionId = tag.StdConnectionId;
    //    Enable = tag.Enable;
    //    InputOutput = tag.InputOutput;
    //    AnalogDigitalSignal = tag.AnalogDigitalSignal;
    //    Invoke = tag.Invoke;
    //    TagGroupId = tag.TagGroupId;
    //}
}