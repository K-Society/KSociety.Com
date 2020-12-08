using System;
using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Add.Common
{
    [ProtoContract]
    public class TagGroup : IResponse, IKbIdObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        public TagGroup() { }
        public TagGroup(Guid tagGroupId)
        {
            Id = tagGroupId;
        }
    }
}
