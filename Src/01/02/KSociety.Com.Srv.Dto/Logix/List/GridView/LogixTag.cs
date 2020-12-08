using System;
using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix.List.GridView
{
    [ProtoContract]
    public class LogixTag : KbList<Logix.LogixTag>
    {
        [ProtoMember(1)]
        public KbListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(3)]
        public KbListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(4)]
        public KbListKeyValuePair<Guid, string> ConnectionId { get; set; }

        [ProtoMember(5)]
        public KbListKeyValuePair<byte, string> BitOfByte { get; set; }

        public LogixTag() { }

        public LogixTag(
            List<Logix.LogixTag> tags,
            //List<KbKeyValuePair<Guid, string>> stdTagId,
            //List<KbKeyValuePair<Guid, string>> connectionId,
            //List<KbKeyValuePair<int, string>> automationTypeId,
            List<KbKeyValuePair<string, string>> analogDigitalSignal,
            List<KbKeyValuePair<Guid, string>> tagGroupId,
            List<KbKeyValuePair<string, string>> inputOutput,
            List<KbKeyValuePair<Guid, string>> connectionId,
            //List<KbKeyValuePair<int, string>> areaId,
            //List<KbKeyValuePair<int, string>> wordLenId,
            List<KbKeyValuePair<byte, string>> bitOfByte
        )
        {
            List = tags;
            //StdTagId = new KbListKeyValuePair<Guid, string>(stdTagId);
            //ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
            //AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new KbListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new KbListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new KbListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
            //AreaId = new KbListKeyValuePair<int, string>(areaId);
            //WordLenId = new KbListKeyValuePair<int, string>(wordLenId);
            BitOfByte = new KbListKeyValuePair<byte, string>(bitOfByte);
        }
    }
}
