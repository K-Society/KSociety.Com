using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.Remove.Common
{
    [ProtoContract]
    public class TagGroup : RemoveReq
    {
        public TagGroup() { }

        public TagGroup(Guid id)
            : base(id)
        {
        }
    }
}