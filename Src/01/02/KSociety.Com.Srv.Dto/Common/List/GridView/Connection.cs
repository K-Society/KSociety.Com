using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List.GridView;

[ProtoContract]
public class Connection : ObjectList<Common.Connection>
{
    [ProtoMember(1)]
    public ListKeyValuePair<int, string> AutomationTypeId { get; set; }

    public Connection()
    {
    }

    public Connection(
        List<Common.Connection> connections,
        List<Base.Srv.Dto.KeyValuePair<int, string>> automationTypeId
    )
    {
        List = connections;
        AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
    }
}