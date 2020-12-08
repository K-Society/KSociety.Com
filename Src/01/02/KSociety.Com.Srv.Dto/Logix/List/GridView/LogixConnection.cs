using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix.List.GridView
{
    [ProtoContract]
    public class LogixConnection : KbList<Logix.LogixConnection>
    {
        public LogixConnection()
        {
        }

        public LogixConnection(
            List<Logix.LogixConnection> connections
            //List<KbKeyValuePair<Guid, string>> connectionId,
            //List<KbKeyValuePair<int, string>> connectionTypes,
            //List<KbKeyValuePair<int, string>> cpuTypes
        )
        {
            List = connections;
            //ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
            //ConnectionTypeId = new KbListKeyValuePair<int, string>(connectionTypes);
            //CpuTypeId = new KbListKeyValuePair<int, string>(cpuTypes);
        }
    }
}
