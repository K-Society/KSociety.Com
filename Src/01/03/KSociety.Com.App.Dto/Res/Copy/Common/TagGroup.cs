using System;
using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Copy.Common
{
    [ProtoContract]
    public class TagGroup : IResponse, IIdObject
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
