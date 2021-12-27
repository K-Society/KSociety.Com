using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.ModifyField.S7;

[ProtoContract]
public class S7Connection : ModifyFieldReq
{
    public S7Connection() { }

    public S7Connection(Guid id, string fieldName, string value)
        : base(id, fieldName, value)
    { }
}