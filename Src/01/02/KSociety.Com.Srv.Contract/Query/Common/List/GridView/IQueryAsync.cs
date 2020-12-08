using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.List.GridView
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.Common.List.GridView.Tag> TagAsync(CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.List.GridView.TagGroup> TagGroupAsync(CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.List.GridView.Connection> ConnectionAsync(CallContext context = default);
    }
}
