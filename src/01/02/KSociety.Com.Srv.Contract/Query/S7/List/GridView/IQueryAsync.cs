using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.List.GridView;

[Service]
public interface IQueryAsync
{
    [Operation]
    ValueTask<Srv.Dto.S7.List.GridView.S7Connection> S7ConnectionAsync(CallContext context = default);

    [Operation]
    ValueTask<Srv.Dto.S7.List.GridView.S7Tag> S7TagAsync(CallContext context = default);
}