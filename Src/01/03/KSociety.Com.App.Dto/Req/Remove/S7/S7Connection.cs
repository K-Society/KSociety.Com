using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.S7
{
    [ProtoContract]
    public class S7Connection : RemoveReq
    {
        public S7Connection() { }

        public S7Connection(Guid id)
            : base(id)
        {
        }
    }
}