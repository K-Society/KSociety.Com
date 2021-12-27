using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.Common;

[ProtoContract]
public class Connection : RemoveReq
{
    public Connection() { }

    public Connection(Guid id)
        : base(id)
    {
    }
}