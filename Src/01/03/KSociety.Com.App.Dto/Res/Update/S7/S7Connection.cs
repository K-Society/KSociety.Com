using System;
using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Update.S7;

[ProtoContract]
public class S7Connection : IResponse, IIdObject
{
    [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid Id { get; set; }

    public S7Connection() { }
    public S7Connection(Guid connectionId)
    {
        Id = connectionId;
    }
}