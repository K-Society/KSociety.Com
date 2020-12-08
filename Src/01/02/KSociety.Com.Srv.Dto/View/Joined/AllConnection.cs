using System;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined
{
    [ProtoContract]
    public class AllConnection : IObject
    {
        #region [Propery]

        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public int AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public string AutomationName { get; set; }

        [ProtoMember(4)]
        public string ConnectionName { get; set; }

        [ProtoMember(5)]
        public string Ip { get; set; }

        [ProtoMember(6)]
        public bool WriteEnable { get; set; }

        [ProtoMember(7)]
        public byte[] Path { get; set; }

        [ProtoMember(8)]
        public int CpuTypeId { get; set; }

        [ProtoMember(9)]
        public string CpuTypeName { get; set; }

        [ProtoMember(10)]
        public int Rack { get; set; }

        [ProtoMember(11)]
        public int Slot { get; set; }

        [ProtoMember(12)]
        public int ConnectionTypeId { get; set; }

        [ProtoMember(13)]
        public string ConnectionTypeName { get; set; }


        #endregion

        public AllConnection() { }

        public AllConnection(
            Guid id,
            int automationTypeId,
            string automationName,
            string connectionName,           
            string ip,
            bool writeEnable,
            byte[] path,
            int cpuTypeId,
            string cpuTypeName,
            int rack,
            int slot,
            int connectionTypeId,
            string connectionTypeName
            
            )
        {
            
            Id = id;
            AutomationTypeId = automationTypeId;
            AutomationName = automationName;
            ConnectionName = connectionName;
            Ip = ip;
            WriteEnable = writeEnable;     
            Path = path;
            CpuTypeId = cpuTypeId;
            CpuTypeName = cpuTypeName;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
            ConnectionTypeName = connectionTypeName;
            
        }
    }
}
