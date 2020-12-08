using System;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.ListKeyValue
{
    [Service]
    public interface IQuery
    {
        [Operation]
        KbListKeyValuePair<int, string> ConnectionTypeId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<int, string> CpuTypeId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<int, string> AreaId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<int, string> WordLenId(CallContext context = default);

        [Operation]
        KbListKeyValuePair<Guid, string> S7ConnectionId(CallContext context = default);
    }
}
