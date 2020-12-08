using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List.GridView
{
    [ProtoContract]
    public class S7Connection : KbList<S7.S7Connection>
    {
        //[DataMember]
        //public KbListKeyValuePair<Guid, string> ConnectionId { get; set; }


        [ProtoMember(1)]
        public KbListKeyValuePair<int, string> ConnectionTypeId { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<int, string> CpuTypeId { get; set; }

        public S7Connection()
        {
        }

        public S7Connection(
            List<S7.S7Connection> connections,
            //List<KbKeyValuePair<Guid, string>> connectionId,
            List<KbKeyValuePair<int, string>> connectionTypes,
            List<KbKeyValuePair<int, string>> cpuTypes
        )
        {
            List = connections;
            //ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
            ConnectionTypeId = new KbListKeyValuePair<int, string>(connectionTypes);
            CpuTypeId = new KbListKeyValuePair<int, string>(cpuTypes);
        }
    }
}
