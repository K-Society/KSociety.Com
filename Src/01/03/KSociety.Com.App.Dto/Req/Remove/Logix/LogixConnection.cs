using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.Logix
{
    [ProtoContract]
    public class LogixConnection : RemoveReq
    {
        public LogixConnection() { }

        public LogixConnection(Guid id)
            : base(id)
        {
        }
    }
}