using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using KSociety.Com.Srv.Dto.View.Common.List.GridView;

namespace KSociety.Com.Srv.Contract.Query.View.Common.List.GridView;

[Service]
public interface IQueryAsync
{
    [Operation]
    ValueTask<TagGroupReady> TagGroupReadyAsync(CallContext context = default);
}