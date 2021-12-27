using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.Common;

[ProtoContract]
public class TagGroup : IRequest
{
    [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public int Clock { get; set; }

    [ProtoMember(4)]
    public int Update { get; set; }

    [ProtoMember(5)]
    public bool Enable { get; set; }

    public TagGroup() { }

    public TagGroup(
        Guid id,
        string name, int clock, int update, bool enable
    )
    {
        Id = id;
        Name = name;
        Clock = clock;
        Update = update;
        Enable = enable;
    }
}