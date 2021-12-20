using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Logix.List.GridView;

//[ServiceContract(Name = "Com.Query.Logix.List.GridView", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    Srv.Dto.Logix.List.GridView.LogixConnection LogixConnection(CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    Srv.Dto.Logix.List.GridView.LogixTag LogixTag(CallContext context = default);
}