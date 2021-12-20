using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7;

[ProtoContract]
public class S7Tag : IAppDtoObject<
    App.Dto.Req.Remove.S7.S7Tag,
    App.Dto.Req.Add.S7.S7Tag,
    App.Dto.Req.Update.S7.S7Tag,
    App.Dto.Req.Copy.S7.S7Tag>
{
    [ProtoMember(1)]
    [Browsable(false), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    [Browsable(false)]
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

    [ProtoMember(11)]
    public int? DataBlock { get; set; }

    [ProtoMember(12)]
    public int? Offset { get; set; }

    [ProtoMember(13)]
    public byte? BitOfByte { get; set; }

    [ProtoMember(14)]
    public int? WordLenId { get; set; }

    [ProtoMember(15)]
    public int? AreaId { get; set; }

    [ProtoMember(16)]
    public int? StringLength { get; set; }

    public S7Tag()
    {

    }

    public S7Tag
    (
        Guid id, 
        int automationTypeId,
        string name,
        Guid connectionId,
        bool enable, string inputOutput, 
        string analogDigitalSignal, 
        string memoryAddress,
        bool invoke,
        Guid tagGroupId,
        int? dataBlock, int? offset,
        byte? bitOfByte,
        int? wordLenId, int? areaId,
        int? stringLength
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
        DataBlock = dataBlock;
        Offset = offset;
        BitOfByte = bitOfByte;

        WordLenId = wordLenId;
        AreaId = areaId;
        StringLength = stringLength;
    }

    public App.Dto.Req.Remove.S7.S7Tag GetRemoveReq()
    {
        return new App.Dto.Req.Remove.S7.S7Tag(Id);
    }

    public App.Dto.Req.Add.S7.S7Tag GetAddReq()
    {
        return new App.Dto.Req.Add.S7.S7Tag(
            AutomationTypeId,
            Name,
            ConnectionId,
            Enable,
            InputOutput,
            AnalogDigitalSignal,
            MemoryAddress,
            Invoke,
            TagGroupId,
            DataBlock, 
            Offset,
            BitOfByte, 
            WordLenId, 
            AreaId,
            StringLength);
    }

    public App.Dto.Req.Update.S7.S7Tag GetUpdateReq()
    {
        return new App.Dto.Req.Update.S7.S7Tag(
            Id,
            AutomationTypeId,
            Name,
            ConnectionId,
            Enable,
            InputOutput,
            AnalogDigitalSignal,
            MemoryAddress,
            Invoke,
            TagGroupId,
            DataBlock,
            Offset,
            BitOfByte,
            WordLenId,
            AreaId,
            StringLength);
    }

    public App.Dto.Req.Copy.S7.S7Tag GetCopyReq()
    {
        return new App.Dto.Req.Copy.S7.S7Tag(
            AutomationTypeId,
            Name,
            ConnectionId,
            Enable,
            InputOutput,
            AnalogDigitalSignal,
            MemoryAddress,
            Invoke,
            TagGroupId,
            DataBlock, 
            Offset,
            BitOfByte, 
            WordLenId, 
            AreaId,
            StringLength);
    }

}