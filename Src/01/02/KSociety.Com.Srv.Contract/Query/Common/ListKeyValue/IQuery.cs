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
        ListKeyValuePair<int, string> AutomationTypeId(CallContext context = default);

        [Operation]
        ListKeyValuePair<string, string> InputOutput(CallContext context = default);

        [Operation]
        ListKeyValuePair<string, string> AnalogDigitalSignal(CallContext context = default);

        [Operation]
        ListKeyValuePair<Guid, string> ConnectionId(CallContext context = default);

        [Operation]
        ListKeyValuePair<Guid, string> TagGroupId(CallContext context = default);

        [Operation]
        ListKeyValuePair<byte, string> BitOfByte(CallContext context = default);
    }
}
