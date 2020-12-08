using System;
using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Update.S7
{
    [ProtoContract]
    public class S7Tag : IResponse, IKbIdObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        public S7Tag() { }
        public S7Tag(Guid tagId)
        {
            Id = tagId;
        }
    }
}
