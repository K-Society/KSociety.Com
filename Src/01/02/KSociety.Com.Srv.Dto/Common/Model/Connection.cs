using System.Collections.Generic;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.Model
{
    [ProtoContract]
    public class Connection : IObject
    {
        [ProtoMember(1)]
        public Common.Connection ConnectionDto { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<int, string> AutomationTypeId { get; set; }

        public Connection()
        {
        }

        public Connection(
            Common.Connection connection,
            List<KbKeyValuePair<int, string>> automationTypeId
        )
        {
            ConnectionDto = connection;
            AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
        }
    }
}
