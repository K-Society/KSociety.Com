using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.Logix;

[ProtoContract]
public class LogixTag : RemoveReq
{
    public LogixTag() { }

    public LogixTag(Guid id)
        : base(id)
    {
    }
}