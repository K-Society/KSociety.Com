using System;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Common
{
    [ProtoContract]
    public class TagGroupReady : IObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public string Name { get; set; }

        [ProtoMember(3)] public int Clock { get; set; }

        [ProtoMember(4)] public int Update { get; set; }

        public TagGroupReady()
        {

        }

        public TagGroupReady
        (
            Guid id,
            string name,
            int clock,
            int update
        )
        {
            Id = id;
            Name = name;
            Clock = clock;
            Update = update;
        }
    }
}