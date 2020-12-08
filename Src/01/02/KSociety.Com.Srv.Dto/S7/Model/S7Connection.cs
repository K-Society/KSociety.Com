using System.Collections.Generic;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.Model
{
    [ProtoContract]
    public class S7Connection : IObject
    {
        [ProtoMember(1)]
        public S7.S7Connection S7ConnectionDto { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public KbListKeyValuePair<int, string> ConnectionTypeId { get; set; }

        [ProtoMember(4)]
        public KbListKeyValuePair<int, string> CpuTypeId { get; set; }

        public S7Connection()
        {

        }

        public S7Connection(
            S7.S7Connection s7Connection,
            List<KbKeyValuePair<int, string>> automationTypeId,
            List<KbKeyValuePair<int, string>> connectionTypeId,
            List<KbKeyValuePair<int, string>> cpuTypeId
        )
        {
            S7ConnectionDto = s7Connection;
            AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
            ConnectionTypeId = new KbListKeyValuePair<int, string>(connectionTypeId);
            CpuTypeId = new KbListKeyValuePair<int, string>(cpuTypeId);
        }
    }
}
