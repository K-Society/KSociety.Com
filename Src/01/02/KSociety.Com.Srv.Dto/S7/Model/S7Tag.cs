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
        public ListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(3)]
        public ListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(4)]
        public ListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(5)]
        public ListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(6)]
        public ListKeyValuePair<Guid, string> ConnectionId { get; set; }

        //
        [ProtoMember(7)]
        public ListKeyValuePair<int, string> AreaId { get; set; }

        [ProtoMember(8)]
        public ListKeyValuePair<int, string> WordLenId { get; set; }

        [ProtoMember(9)]
        public ListKeyValuePair<byte, string> BitOfByte { get; set; }

        public S7Tag()
        {
        }

        public S7Tag(
            S7.S7Tag s7Tag,
            List<Base.Srv.Dto.KeyValuePair<int, string>> automationTypeId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> analogDigitalSignal,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> tagGroupId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> inputOutput,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> connectionId,
            List<Base.Srv.Dto.KeyValuePair<int, string>> areaId,
            List<Base.Srv.Dto.KeyValuePair<int, string>> wordLenId,
            List<Base.Srv.Dto.KeyValuePair<byte, string>> bitOfByte
        )
        {
            S7TagDto = s7Tag;
            AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new ListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new ListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new ListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
            AreaId = new ListKeyValuePair<int, string>(areaId);
            WordLenId = new ListKeyValuePair<int, string>(wordLenId);
            BitOfByte = new ListKeyValuePair<byte, string>(bitOfByte);
        }
    }
}
