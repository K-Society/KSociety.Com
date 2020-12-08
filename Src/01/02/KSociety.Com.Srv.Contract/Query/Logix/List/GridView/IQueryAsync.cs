using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Logix.List.GridView
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<Srv.Dto.Logix.List.GridView.LogixConnection> LogixConnectionAsync(CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<Srv.Dto.Logix.List.GridView.LogixTag> LogixTagAsync(CallContext context = default);
    }
}
