using System;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined
{
    [ProtoContract]
    public class AllTagGroupConnection : IObject
    {
        #region [Propery]

        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public string TagName { get; set; }

        [ProtoMember(3), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid ConnectionId { get; set; }

        [ProtoMember(4)] public string ConnectionName { get; set; }

        [ProtoMember(5)] public int AutomationTypeId { get; set; }

        [ProtoMember(6)] public string AutomationName { get; set; }

        [ProtoMember(7)] public string Ip { get; set; }

        [ProtoMember(8)] public bool WriteEnable { get; set; }

        [ProtoMember(9)] public string InputOutput { get; set; }

        [ProtoMember(10)] public string AnalogDigitalSignal { get; set; }

        [ProtoMember(11)] public bool Invoke { get; set; }

        [ProtoMember(12), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid TagGroupId { get; set; }

        [ProtoMember(13)] public string TagGroupName { get; set; }

        [ProtoMember(14)] public int Clock { get; set; }

        [ProtoMember(15)] public int Update { get; set; }

        [ProtoMember(16)] public int DataBlock { get; set; }

        [ProtoMember(17)] public int Offset { get; set; }

        [ProtoMember(18)] public byte BitOfByte { get; set; }

        [ProtoMember(19)] public string MemoryAddress { get; set; }

        [ProtoMember(20)] public int WordLenId { get; set; }

        [ProtoMember(21)] public string WordLenName { get; set; }

        [ProtoMember(22)] public int AreaId { get; set; }

        [ProtoMember(23)] public string AreaName { get; set; }

        #endregion

        public AllTagGroupConnection() { }

        public AllTagGroupConnection(
            Guid id,
            string tagName,
            Guid connectionId,
            string connectionName,
            int automationTypeId,
            string automationName,
            string ip,
            bool writeEnable,
            string inputOutput,
            string analogDigitalSignal,
            bool invoke,
            Guid tagGroupId,
            string tagGroupName,
            int clock,
            int update,
            int dataBlock,
            int offset,
            byte bitOfByte,
            string memoryAddress,
            int wordLenId,
            string wordLenName,
            int areaId,
            string areaName
        )
        {
            Id = id;
            TagName = tagName;
            ConnectionId = connectionId;
            ConnectionName = connectionName;
            AutomationTypeId = automationTypeId;
            AutomationName = automationName;
            Ip = ip;
            WriteEnable = writeEnable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            Invoke = invoke;
            TagGroupId = tagGroupId;
            TagGroupName = tagGroupName;
            Clock = clock;
            Update = update;
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            MemoryAddress = memoryAddress;
            WordLenId = wordLenId;
            WordLenName = wordLenName;
            AreaId = areaId;
            AreaName = areaName;
        }
    }
}