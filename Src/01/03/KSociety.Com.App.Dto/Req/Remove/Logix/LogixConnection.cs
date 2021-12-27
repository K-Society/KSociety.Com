using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.Logix;

[ProtoContract]
public class LogixConnection : RemoveReq
{
    public LogixConnection() { }

    public LogixConnection(Guid id)
        : base(id)
    {
    }
}