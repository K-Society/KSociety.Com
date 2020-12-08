using System;
using System.Collections.Generic;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.Model
{
    [ProtoContract]
    public class S7Tag : IObject
    {
        [ProtoMember(1)]
        public S7.S7Tag S7TagDto { get; set; }

        [ProtoMember(2)]
        public KbListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public KbListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(4)]
        public KbListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(5)]
        public KbListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(6)]
        public KbListKeyValuePair<Guid, string> ConnectionId { get; set; }

        //
        [ProtoMember(7)]
        public KbListKeyValuePair<int, string> AreaId { get; set; }

        [ProtoMember(8)]
        public KbListKeyValuePair<int, string> WordLenId { get; set; }

        [ProtoMember(9)]
        public KbListKeyValuePair<byte, string> BitOfByte { get; set; }

        public S7Tag()
        {
        }

        public S7Tag(
            S7.S7Tag s7Tag,
            List<KbKeyValuePair<int, string>> automationTypeId,
            List<KbKeyValuePair<string, string>> analogDigitalSignal,
            List<KbKeyValuePair<Guid, string>> tagGroupId,
            List<KbKeyValuePair<string, string>> inputOutput,
            List<KbKeyValuePair<Guid, string>> connectionId,
            List<KbKeyValuePair<int, string>> areaId,
            List<KbKeyValuePair<int, string>> wordLenId,
            List<KbKeyValuePair<byte, string>> bitOfByte
        )
        {
            S7TagDto = s7Tag;
            AutomationTypeId = new KbListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new KbListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new KbListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new KbListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new KbListKeyValuePair<Guid, string>(connectionId);
            AreaId = new KbListKeyValuePair<int, string>(areaId);
            WordLenId = new KbListKeyValuePair<int, string>(wordLenId);
            BitOfByte = new KbListKeyValuePair<byte, string>(bitOfByte);
        }
    }
}
