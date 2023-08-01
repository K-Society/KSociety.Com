using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7
{
    [ProtoContract]
    public class BlockArea : IObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public int DataBlock { get; set; }

        [ProtoMember(3)] public int Start { get; set; }

        [ProtoMember(4)] public int Amount { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        [ProtoMember(6)] public string Name { get; set; }

        [ProtoMember(7), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid ConnectionId { get; set; }

        [ProtoMember(8)] public string Area { get; set; }

        [ProtoMember(9)] public string WordLen { get; set; }

        private BlockArea() { }

        public BlockArea(
            Guid id,
            int dataBlock,
            int start, int amount, bool enable,
            string name, Guid connectionId,
            string area, string wordLen
        )
        {
            Id = id;
            DataBlock = dataBlock;
            Start = start;
            Amount = amount;
            Enable = enable;
            Name = name;
            ConnectionId = connectionId;
            Area = area;
            WordLen = wordLen;
        }
    }
}