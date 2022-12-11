using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;
using System;

namespace KSociety.Com.App.Dto.Req.ModifyField.Logix
{
    [ProtoContract]
    public class LogixConnection : ModifyFieldReq
    {
        public LogixConnection() { }

        public LogixConnection(Guid id, string fieldName, string value)
            : base(id, fieldName, value)
        {
        }
    }
}