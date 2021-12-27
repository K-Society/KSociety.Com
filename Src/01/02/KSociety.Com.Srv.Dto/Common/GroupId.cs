using System;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common;

[ProtoContract]
public class GroupId
{
    [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
    public Guid Id { get; set; }

    public GroupId()
    {

    }

    public GroupId(Guid id)
    {
        Id = id;
    }
}