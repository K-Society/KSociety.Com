using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.S7
{
    [ProtoContract]
    public class S7Connection : IRequest
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public int AutomationTypeId { get; set; }

        [ProtoMember(3)] public string Name { get; set; }

        [ProtoMember(4)] public string Ip { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        [ProtoMember(6)] public bool WriteEnable { get; set; }

        [ProtoMember(7)] public int? CpuTypeId { get; set; }

        [ProtoMember(8)] public short? Rack { get; set; }

        [ProtoMember(9)] public short? Slot { get; set; }

        [ProtoMember(10)] public int? ConnectionTypeId { get; set; }

        public S7Connection() { }

        public S7Connection(
            Guid id,
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable,
            int? cpuTypeId,
            short? rack, short? slot,
            int? connectionTypeId
        )
        {
            Id = id;
            AutomationTypeId = 1; //automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
        }
    }
}