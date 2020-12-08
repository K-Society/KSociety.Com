using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.Common
{
    [ProtoContract]
    public class Connection : IRequest
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public int AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public string Name { get; set; }

        [ProtoMember(4)]
        public string Ip { get; set; }

        [ProtoMember(5)]
        public bool Enable { get; set; }

        [ProtoMember(6)]
        public bool WriteEnable { get; set; }

        public Connection() { }

        public Connection(
            Guid id,
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable
        )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }
    }
}
