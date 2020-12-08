using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List.GridView
{
    [ProtoContract]
    public class Connection : KbList<Common.Connection>
    {
        [ProtoMember(1)]
        public KbListKeyValuePair<int, string> AutomationTypeId { get; set; }

        public Connection()
        {
        }

        public Connection(
            List<Common.Connection> connections,
            List<KbKeyValuePair<int, string>> automationTypeId
        )
        {
            List = connections;
            AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
        }
    }
}
