using System;
using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Update.Logix
{
    [ProtoContract]
    public class LogixConnection : IRequest
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

        [ProtoMember(7)]
        public byte[] Path { get; set; }
        
        public LogixConnection() { }

        public LogixConnection(
            Guid id,
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable,
            byte[] path

        )
        {
            Id = id;
            AutomationTypeId = 2; //automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            Path = path;
        }
    }
}
