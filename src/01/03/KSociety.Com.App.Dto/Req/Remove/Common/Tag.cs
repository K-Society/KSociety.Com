using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.Common
{
    [ProtoContract]
    public class Tag : RemoveReq
    {
        public Tag() { }

        public Tag(Guid id)
            : base(id)
        {
        }
    }
}