using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.List.GridView;

[Service]
public interface IQuery
{
    [Operation]
    Srv.Dto.Common.List.GridView.Tag Tag(CallContext context = default);

    [Operation]
    Srv.Dto.Common.List.GridView.TagGroup TagGroup(CallContext context = default);

    [Operation]
    Srv.Dto.Common.List.GridView.Connection Connection(CallContext context = default);
}