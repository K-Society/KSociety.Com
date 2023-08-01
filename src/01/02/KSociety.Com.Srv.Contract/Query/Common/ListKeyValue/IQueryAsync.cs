using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.ListKeyValue;

[Service]
public interface IQueryAsync
{
    [Operation]
    ValueTask<ListKeyValuePair<int, string>> AutomationTypeIdAsync(CallContext context = default);

    [Operation]
    ValueTask<ListKeyValuePair<string, string>> InputOutputAsync(CallContext context = default);

    [Operation]
    ValueTask<ListKeyValuePair<string, string>> AnalogDigitalSignalAsync(CallContext context = default);

    [Operation]
    ValueTask<ListKeyValuePair<Guid, string>> ConnectionIdAsync(CallContext context = default);

    [Operation]
    ValueTask<ListKeyValuePair<Guid, string>> TagGroupIdAsync(CallContext context = default);

    [Operation]
    ValueTask<ListKeyValuePair<byte, string>> BitOfByteAsync(CallContext context = default);
}