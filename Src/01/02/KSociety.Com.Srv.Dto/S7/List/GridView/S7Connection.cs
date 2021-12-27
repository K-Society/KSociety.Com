using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List.GridView;

[ProtoContract]
public class S7Connection : ObjectList<S7.S7Connection>
{
    //[DataMember]
    //public ListKeyValuePair<Guid, string> ConnectionId { get; set; }


    [ProtoMember(1)]
    public ListKeyValuePair<int, string> ConnectionTypeId { get; set; }

    [ProtoMember(2)]
    public ListKeyValuePair<int, string> CpuTypeId { get; set; }

    public S7Connection()
    {
    }

    public S7Connection(
        List<S7.S7Connection> connections,
        //List<KeyValuePair<Guid, string>> connectionId,
        List<Base.Srv.Dto.KeyValuePair<int, string>> connectionTypes,
        List<Base.Srv.Dto.KeyValuePair<int, string>> cpuTypes
    )
    {
        List = connections;
        //ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
        ConnectionTypeId = new ListKeyValuePair<int, string>(connectionTypes);
        CpuTypeId = new ListKeyValuePair<int, string>(cpuTypes);
    }
}