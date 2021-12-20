using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common;

[ProtoContract]
public class Tag : IAppDtoObject<
    App.Dto.Req.Remove.Common.Tag, 
    App.Dto.Req.Add.Common.Tag,
    App.Dto.Req.Update.Common.Tag,
    App.Dto.Req.Copy.Common.Tag>
{
    [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
    [Browsable(false)]
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
        
    public Tag()
    {

    }

    public Tag
    (
        Guid id, 
        int automationTypeId,
        string name,
        Guid connectionId,
        bool enable, string inputOutput, 
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

    public App.Dto.Req.Remove.Common.Tag GetRemoveReq()
    {
        return new App.Dto.Req.Remove.Common.Tag(Id);
    }

    public App.Dto.Req.Add.Common.Tag GetAddReq()
    {
        return new App.Dto.Req.Add.Common.Tag(AutomationTypeId, Name, ConnectionId, Enable, InputOutput, AnalogDigitalSignal, MemoryAddress, Invoke, TagGroupId);
    }

    public App.Dto.Req.Update.Common.Tag GetUpdateReq()
    {
        return new App.Dto.Req.Update.Common.Tag(Id, AutomationTypeId, Name, ConnectionId, Enable, InputOutput, AnalogDigitalSignal, MemoryAddress, Invoke, TagGroupId);
    }

    public App.Dto.Req.Copy.Common.Tag GetCopyReq()
    {
        return new App.Dto.Req.Copy.Common.Tag(AutomationTypeId, Name, ConnectionId, Enable, InputOutput, AnalogDigitalSignal, MemoryAddress, Invoke, TagGroupId);
    }
}