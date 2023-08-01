using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using KSociety.Com.Srv.Dto.View.Common.List;

namespace KSociety.Com.Srv.Contract.Query.View.Common.List;

//[ServiceContract(Name = "Com.Query.View.Common.List", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    TagGroupReady TagGroupReady(CallContext context = default);
}