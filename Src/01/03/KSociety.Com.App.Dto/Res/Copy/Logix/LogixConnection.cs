using System;
using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Copy.Logix
{
    [ProtoContract]
    public class LogixConnection : IResponse, IIdObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        public LogixConnection() { }
        public LogixConnection(Guid connectionId)
        {
            Id = connectionId;
        }
    }
}
