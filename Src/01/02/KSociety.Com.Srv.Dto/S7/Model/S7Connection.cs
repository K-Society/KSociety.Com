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
        public ListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public ListKeyValuePair<int, string> ConnectionTypeId { get; set; }

        [ProtoMember(4)]
        public ListKeyValuePair<int, string> CpuTypeId { get; set; }

        public S7Connection()
        {

        }

        public S7Connection(
            S7.S7Connection s7Connection,
            List<Base.Srv.Dto.KeyValuePair<int, string>> automationTypeId,
            List<Base.Srv.Dto.KeyValuePair<int, string>> connectionTypeId,
            List<Base.Srv.Dto.KeyValuePair<int, string>> cpuTypeId
        )
        {
            S7ConnectionDto = s7Connection;
            AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
            ConnectionTypeId = new ListKeyValuePair<int, string>(connectionTypeId);
            CpuTypeId = new ListKeyValuePair<int, string>(cpuTypeId);
        }
    }
}
