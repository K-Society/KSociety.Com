using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.Common;

[ProtoContract]
public class TagGroup : RemoveReq
{
    public TagGroup() { }

    public TagGroup(Guid id)
        : base(id)
    {
    }
}