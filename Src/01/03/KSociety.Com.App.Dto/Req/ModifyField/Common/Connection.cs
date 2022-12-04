using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.ModifyField.Common
{
    [ProtoContract]
    public class Connection : ModifyFieldReq
    {
        public Connection() { }

        public Connection(Guid id, string fieldName, string value)
            : base(id, fieldName, value)
        {
        }
    }
}