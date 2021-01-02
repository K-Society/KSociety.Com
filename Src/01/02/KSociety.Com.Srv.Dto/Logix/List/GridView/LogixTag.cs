using System;
using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix.List.GridView
{
    [ProtoContract]
    public class LogixTag : ObjectList<Logix.LogixTag>
    {
        [ProtoMember(1)]
        public ListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(2)]
        public ListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(3)]
        public ListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(4)]
        public ListKeyValuePair<Guid, string> ConnectionId { get; set; }

        [ProtoMember(5)]
        public ListKeyValuePair<byte, string> BitOfByte { get; set; }

        public LogixTag() { }

        public LogixTag(
            List<Logix.LogixTag> tags,
            //List<KeyValuePair<Guid, string>> stdTagId,
            //List<KeyValuePair<Guid, string>> connectionId,
            //List<KeyValuePair<int, string>> automationTypeId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> analogDigitalSignal,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> tagGroupId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> inputOutput,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> connectionId,
            //List<KeyValuePair<int, string>> areaId,
            //List<KeyValuePair<int, string>> wordLenId,
            List<Base.Srv.Dto.KeyValuePair<byte, string>> bitOfByte
        )
        {
            List = tags;
            //StdTagId = new ListKeyValuePair<Guid, string>(stdTagId);
            //ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
            //AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new ListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new ListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new ListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
            //AreaId = new ListKeyValuePair<int, string>(areaId);
            //WordLenId = new ListKeyValuePair<int, string>(wordLenId);
            BitOfByte = new ListKeyValuePair<byte, string>(bitOfByte);
        }
    }
}
