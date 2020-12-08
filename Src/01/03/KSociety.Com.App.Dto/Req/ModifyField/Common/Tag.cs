using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.ModifyField.Common
{
    [ProtoContract]
    public class Tag : ModifyFieldReq
    {
        public Tag() { }

        public Tag(Guid id, string fieldName, string value)
            : base(id, fieldName, value)
        { }
    }
}
