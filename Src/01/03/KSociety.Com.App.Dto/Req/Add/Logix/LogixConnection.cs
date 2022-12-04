using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Add.Logix
{
    [ProtoContract]
    public class LogixConnection : IRequest
    {
        [ProtoMember(1)] public int AutomationTypeId { get; set; }

        [ProtoMember(2)] public string Name { get; set; }

        [ProtoMember(3)] public string Ip { get; set; }

        [ProtoMember(4)] public bool Enable { get; set; }

        [ProtoMember(5)] public bool WriteEnable { get; set; }

        [ProtoMember(6)] public byte[] Path { get; set; }

        public LogixConnection() { }

        public LogixConnection(
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable,
            byte[] path

        )
        {
            AutomationTypeId = 2; //automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            Path = path;
        }
    }
}