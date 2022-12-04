using System;
using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List.GridView
{
    [ProtoContract]
    public class Tag : ObjectList<Common.Tag>
    {
        [ProtoMember(1)] public ListKeyValuePair<int, string> AutomationTypeId { get; set; }

        [ProtoMember(2)] public ListKeyValuePair<string, string> AnalogDigitalSignal { get; set; }

        [ProtoMember(3)] public ListKeyValuePair<Guid, string> TagGroupId { get; set; }

        [ProtoMember(4)] public ListKeyValuePair<string, string> InputOutput { get; set; }

        [ProtoMember(5)] public ListKeyValuePair<Guid, string> ConnectionId { get; set; }

        public Tag() { }

        public Tag
        (
            List<Common.Tag> tags,
            List<Base.Srv.Dto.KeyValuePair<int, string>> automationTypeId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> analogDigitalSignal,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> tagGroupId,
            List<Base.Srv.Dto.KeyValuePair<string, string>> inputOutput,
            List<Base.Srv.Dto.KeyValuePair<Guid, string>> connectionId
        )
        {
            List = tags;
            AutomationTypeId = new ListKeyValuePair<int, string>(automationTypeId);
            AnalogDigitalSignal = new ListKeyValuePair<string, string>(analogDigitalSignal);
            TagGroupId = new ListKeyValuePair<Guid, string>(tagGroupId);
            InputOutput = new ListKeyValuePair<string, string>(inputOutput);
            ConnectionId = new ListKeyValuePair<Guid, string>(connectionId);
        }
    }
}