using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7
{
    [ProtoContract]
    public class S7Connection : IAppDtoObject<
        App.Dto.Req.Remove.S7.S7Connection,
        App.Dto.Req.Add.S7.S7Connection,
        App.Dto.Req.Update.S7.S7Connection,
        App.Dto.Req.Copy.S7.S7Connection>
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] [Browsable(false)] public int AutomationTypeId { get; set; }

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
            short? rack,
            short? slot, int? connectionTypeId
        )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
        }

        public App.Dto.Req.Remove.S7.S7Connection GetRemoveReq()
        {
            return new App.Dto.Req.Remove.S7.S7Connection(Id);
        }

        public App.Dto.Req.Add.S7.S7Connection GetAddReq()
        {
            return new App.Dto.Req.Add.S7.S7Connection(AutomationTypeId, Name, Ip, Enable, WriteEnable, CpuTypeId, Rack,
                Slot, ConnectionTypeId);
        }

        public App.Dto.Req.Update.S7.S7Connection GetUpdateReq()
        {
            return new App.Dto.Req.Update.S7.S7Connection(Id, AutomationTypeId, Name, Ip, Enable, WriteEnable,
                CpuTypeId, Rack, Slot, ConnectionTypeId);
        }

        public App.Dto.Req.Copy.S7.S7Connection GetCopyReq()
        {
            return new App.Dto.Req.Copy.S7.S7Connection(AutomationTypeId, Name, Ip, Enable, WriteEnable, CpuTypeId,
                Rack, Slot, ConnectionTypeId);
        }
    }
}