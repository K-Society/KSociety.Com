﻿using System;
using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.ModifyField.Logix;

[ProtoContract]
public class LogixConnection : ModifyFieldReq
{
    public LogixConnection() { }

    public LogixConnection(Guid id, string fieldName, string value)
        : base(id, fieldName, value)
    { }
}