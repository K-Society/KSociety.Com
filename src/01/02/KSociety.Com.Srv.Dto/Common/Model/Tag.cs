using System;
using System.Collections.Generic;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.Model
{
    [ProtoContract]
    public class Tag : IObject
    {
        [ProtoMember(1)] public Common.Tag TagDto { get; set; }

        [ProtoMember(2)] public ListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(3)] public ListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(4)] public ListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(5)] public ListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(6)] public ListKeyValuePair<Guid, string> ConnectionId { get; set; }

        public Tag()
        {
        }

        public Tag(
            Common.Tag tag,
            List<Base.Srv.Dto.KeyValuePair<int, string>> automationTypeId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> analogDigitalSignal,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> tagGroupId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> inputOutput,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> connectionId
        )
        {
            TagDto = tag;
            AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new ListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new ListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new ListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
        }
    }
}