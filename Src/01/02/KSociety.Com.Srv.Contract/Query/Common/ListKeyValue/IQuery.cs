using System;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.ListKeyValue
{
    [Service]
    public interface IQuery
    {
        [Operation]
        KbListKeyValuePair<int, string> AutomationTypeId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<string, string> InputOutput(CallContext context = default);

        [Operation]
        KbListKeyValuePair<string, string> AnalogDigitalSignal(CallContext context = default);

        [Operation]
        KbListKeyValuePair<Guid, string> ConnectionId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<Guid, string> TagGroupId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<byte, string> BitOfByte(CallContext context = default);
    }
}
