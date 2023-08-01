using KSociety.Com.Srv.Dto.View.Joined.List.GridView;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.View.Joined.List.GridView;

//[ServiceContract(Name = "Com.Query.View.Joined.List.GridView", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    AllTagGroupAllConnection AllTagGroupAllConnection(CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    AllConnection AllConnection(CallContext context = default);
}