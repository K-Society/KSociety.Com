using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.ModifyField.S7;

[ProtoContract]
public class S7Tag : ModifyFieldReq
{
    public S7Tag() { }

    public S7Tag(Guid id, string fieldName, string value)
        : base(id, fieldName, value)
    { }
}