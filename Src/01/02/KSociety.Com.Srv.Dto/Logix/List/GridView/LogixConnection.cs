using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix.List.GridView
{
    [ProtoContract]
    public class LogixConnection : ObjectList<Logix.LogixConnection>
    {
        public LogixConnection()
        {
        }

        public LogixConnection(
            List<Logix.LogixConnection> connections
            //List<KeyValuePair<Guid, string>> connectionId,
            //List<KeyValuePair<int, string>> connectionTypes,
            //List<KeyValuePair<int, string>> cpuTypes
        )
        {
            List = connections;
            //ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
            //ConnectionTypeId = new ListKeyValuePair<int, string>(connectionTypes);
            //CpuTypeId = new ListKeyValuePair<int, string>(cpuTypes);
        }
    }
}
