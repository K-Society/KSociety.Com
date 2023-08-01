using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.Logix
{
    [ProtoContract]
    public class LogixTag : RemoveReq
    {
        public LogixTag() { }

        public LogixTag(Guid id)
            : base(id)
        {
        }
    }
}