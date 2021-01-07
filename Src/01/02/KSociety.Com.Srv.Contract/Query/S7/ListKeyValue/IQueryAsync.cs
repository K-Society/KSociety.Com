using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.ListKeyValue
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<ListKeyValuePair<int, string>> ConnectionTypeIdAsync(CallContext context = default);

        [Operation]
        ValueTask<ListKeyValuePair<int, string>> CpuTypeIdAsync(CallContext context = default);

        [Operation]
        ValueTask<ListKeyValuePair<int, string>> AreaIdAsync(CallContext context = default);

        [Operation]
        ValueTask<ListKeyValuePair<int, string>> WordLenIdAsync(CallContext context = default);

        [Operation]
        ValueTask<ListKeyValuePair<Guid, string>> S7ConnectionIdAsync(CallContext context = default);
    }
}
