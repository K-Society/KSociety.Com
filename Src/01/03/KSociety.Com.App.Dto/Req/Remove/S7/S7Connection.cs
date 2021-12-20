using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.S7;

[ProtoContract]
public class S7Connection : RemoveReq
{
    public S7Connection() { }

    public S7Connection(Guid id)
        : base(id)
    {
    }
}