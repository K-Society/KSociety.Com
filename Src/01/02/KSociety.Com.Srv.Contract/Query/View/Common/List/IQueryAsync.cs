using System.Threading.Tasks;
using KSociety.Com.Srv.Dto.View.Common.List;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.View.Common.List;

[Service]
public interface IQueryAsync
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<TagGroupReady> TagGroupReadyAsync(CallContext context = default);
}