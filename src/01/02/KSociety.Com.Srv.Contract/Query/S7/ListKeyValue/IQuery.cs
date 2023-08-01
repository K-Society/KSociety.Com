using System;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.ListKeyValue;

[Service]
public interface IQuery
{
    [Operation]
    ListKeyValuePair<int, string> ConnectionTypeId(CallContext context = default);

    [Operation]
    ListKeyValuePair<int, string> CpuTypeId(CallContext context = default);

    [Operation]
    ListKeyValuePair<int, string> AreaId(CallContext context = default);

    [Operation]
    ListKeyValuePair<int, string> WordLenId(CallContext context = default);

    [Operation]
    ListKeyValuePair<Guid, string> S7ConnectionId(CallContext context = default);
}