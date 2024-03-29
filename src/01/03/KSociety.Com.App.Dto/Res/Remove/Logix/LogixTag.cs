﻿using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Remove.Logix
{
    [ProtoContract]
    public class LogixTag : IResponse, IBoolResponse
    {
        [ProtoMember(1)] public bool Result { get; set; }

        public LogixTag() { }

        public LogixTag(bool result)
        {
            Result = result;
        }
    }
}