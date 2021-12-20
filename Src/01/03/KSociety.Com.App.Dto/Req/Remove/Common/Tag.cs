using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.Common;

[ProtoContract]
public class Tag : RemoveReq
{
    public Tag() { }

    public Tag(Guid id)
        : base(id)
    {
    }
}