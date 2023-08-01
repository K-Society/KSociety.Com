using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.List.GridView;

[Service]
public interface IQuery
{
    [Operation]
    Srv.Dto.S7.List.GridView.S7Connection S7Connection(CallContext context = default);

    [Operation]
    Srv.Dto.S7.List.GridView.S7Tag S7Tag(CallContext context = default);
}