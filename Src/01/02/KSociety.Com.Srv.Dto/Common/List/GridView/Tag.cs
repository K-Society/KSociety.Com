using System;
using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List.GridView
{
    [ProtoContract]
    public class Tag : KbList<Common.Tag>
    {
        [ProtoMember(1)]
        public KbListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(3)]
        public KbListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(4)]
        public KbListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(5)]
        public KbListKeyValuePair<Guid, string> ConnectionId { get; set; }

        public Tag() { }

        public Tag
        (
            List<Common.Tag> tags,
            List<KbKeyValuePair<int, string>> automationTypeId,
            List<KbKeyValuePair<string, string>> analogDigitalSignal,
            List<KbKeyValuePair<Guid, string>> tagGroupId,
            List<KbKeyValuePair<string, string>> inputOutput,
            List<KbKeyValuePair<Guid, string>> connectionId
        )
        {
            List = tags;
            AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new KbListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new KbListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new KbListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
        }
    }
}
