using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.Common
{
    [ProtoContract]
    public class Connection : RemoveReq
    {
        public Connection() { }

        public Connection(Guid id)
            : base(id)
        {
        }
    }
}