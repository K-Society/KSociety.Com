using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Remove.S7
{
    [ProtoContract]
    public class S7Tag : RemoveReq
    {
        public S7Tag() { }

        public S7Tag(Guid id)
            : base(id)
        {
        }
    }
}
