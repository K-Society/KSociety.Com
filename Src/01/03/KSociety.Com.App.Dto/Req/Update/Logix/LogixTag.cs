using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.Logix
{
    [ProtoContract]
    public class LogixTag : IRequest
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public int AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public string Name { get; set; }

        [ProtoMember(4), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid ConnectionId { get; set; }

        [ProtoMember(5)]
        public bool Enable { get; set; }

        [ProtoMember(6)]
        public string InputOutput { get; set; }

        [ProtoMember(7)]
        public string AnalogDigitalSignal { get; set; }

        [ProtoMember(8)]
        public string MemoryAddress { get; set; }

        [ProtoMember(9)]
        public bool Invoke { get; private set; }

        [ProtoMember(10), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid TagGroupId { get; set; }

        public LogixTag() { }

        public LogixTag
        (
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId
        )
        {
            Id = id;
            AutomationTypeId = 2; //automationTypeId;
            Name = name;
            ConnectionId = connectionId;
            Enable = enable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;
        }
    }
}
