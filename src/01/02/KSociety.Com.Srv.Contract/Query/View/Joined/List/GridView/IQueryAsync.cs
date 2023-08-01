using System.Threading.Tasks;
using KSociety.Com.Srv.Dto.View.Joined.List.GridView;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.View.Joined.List.GridView;

[Service]
public interface IQueryAsync
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<AllTagGroupAllConnection> AllTagGroupAllConnectionAsync(CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<AllConnection> AllConnectionAsync(CallContext context = default);
}